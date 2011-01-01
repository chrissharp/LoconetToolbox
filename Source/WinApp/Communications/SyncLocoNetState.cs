using System;
using System.Windows.Forms;
using LocoNetToolBox.Model;

namespace LocoNetToolBox.WinApp.Communications
{
    /// <summary>
    /// Synchronization wrapper for loconet state.
    /// </summary>
    internal class SyncLocoNetState : ILocoNetState
    {
        /// <summary>
        /// Event is fired when an input or switch state has changed.
        /// </summary>
        public event EventHandler<StateMessage> StateChanged;

        /// <summary>
        /// Event is fired when a query for loco-io units is detected.
        /// </summary>
        public event EventHandler LocoIOQuery;

        /// <summary>
        /// Event is fired when a response from a loco-io unit on a query for such units is detected.
        /// </summary>
        public event EventHandler<LocoIOEventArgs> LocoIOFound;

        private readonly Control ui;
        private readonly LocoNetState lnState;

        /// <summary>
        /// Default ctor
        /// </summary>
        internal SyncLocoNetState(Control ui, LocoNetState lnState)
        {
            this.ui = ui;
            this.lnState = lnState;
            lnState.StateChanged += LnStateStateChanged;
            lnState.LocoIOQuery += LnStateLocoIoQuery;
            lnState.LocoIOFound += LnStateLocoIoFound;
        }

        private void LnStateLocoIoFound(object sender, LocoIOEventArgs e)
        {
            if (ui.InvokeRequired)
            {
                ui.BeginInvoke(new EventHandler<LocoIOEventArgs>(LnStateLocoIoFound), sender, e);
            }
            else
            {
                LocoIOFound.Fire(this, e);
            }
        }

        private void LnStateLocoIoQuery(object sender, EventArgs e)
        {
            if (ui.InvokeRequired)
            {
                ui.BeginInvoke(new EventHandler(LnStateLocoIoQuery), sender, e);
            }
            else
            {
                LocoIOQuery.Fire(this);
            }
        }

        private void LnStateStateChanged(object sender, StateMessage e)
        {
            if (ui.InvokeRequired)
            {
                ui.BeginInvoke(new EventHandler<StateMessage>(LnStateStateChanged), sender, e);
            }
            else
            {
                StateChanged.Fire(this, e);
            }
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
            return lnState.WaitForSwitchDirection(address, direction, timeout);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            lnState.StateChanged -= LnStateStateChanged;
            lnState.LocoIOQuery -= LnStateLocoIoQuery;
            lnState.LocoIOFound -= LnStateLocoIoFound;
            lnState.Dispose();
        }
    }
}
