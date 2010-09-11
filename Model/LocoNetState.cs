using System;
using System.Threading;
using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.Model
{
    /// <summary>
    /// Maintains the state of all inputs and switches in the loconet.
    /// </summary>
    public class LocoNetState : IDisposable
    {
        public event EventHandler<StateMessage> StateChanged;

        private readonly AddressStateMap<SwitchState> switches = new AddressStateMap<SwitchState>();
        private readonly object stateLock = new object();
        private readonly LocoBuffer lb;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="lb"></param>
        internal LocoNetState(LocoBuffer lb)
        {
            this.lb = lb;
            lb.PreviewMessage += ProcessMessage;
        }

        /// <summary>
        /// Wait for the switch with the given address to have the given direction.
        /// </summary>
        /// <param name="address">Loconet address of the switch</param>
        /// <param name="direction">Intended direction</param>
        /// <param name="timeout">Timeout in ms</param>
        /// <returns>True if state is correct, false on timeout</returns>
        public bool WaitForSwitchDirection(int address, bool direction, int timeout)
        {
            lock (stateLock)
            {
                var sw = GetSwitch(address);
                var start = Environment.TickCount;
                while (true)
                {
                    if (sw.Direction == direction)
                        return true;
                    if (!Monitor.Wait(stateLock, timeout))
                        return false;
                    var now = Environment.TickCount;
                    timeout -= (now - start);
                    if (sw.Direction == direction)
                        return true;
                    if (timeout <= 0)
                        return false;
                    start = now;
                }
            }
        }

        /// <summary>
        /// Process a loconet message and update the state accordingly.
        /// </summary>
        private bool ProcessMessage(byte[] message, Message decoded)
        {
            var response = Response.Decode(message);

            SwitchState sw = null;
            lock (stateLock)
            {
                var inpRep = response as InputReport;
                var swRep = response as SwitchReport;
                if (inpRep != null)
                {
                    //var item = GetItem(inpRep.Address);
                }
                else if (swRep != null)
                {
                    sw = GetSwitch(swRep.Address);
                    if (sw.Direction != swRep.Direction)
                    {
                        // State change
                        sw.Direction = swRep.Direction;
                        Monitor.PulseAll(stateLock);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // Notify listeners
            if (sw != null) 
                StateChanged.Fire(this, new StateMessage(sw));
            return false;
        }

        /// <summary>
        /// Get or create a switch state.
        /// </summary>
        private SwitchState GetSwitch(int address)
        {
            return switches.GetOrCreateItem(address, x => new SwitchState(x));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            StateChanged = null;
            lock (stateLock)
            {
                Monitor.PulseAll(stateLock);
            }
            lb.PreviewMessage -= ProcessMessage;
        }
    }
}
