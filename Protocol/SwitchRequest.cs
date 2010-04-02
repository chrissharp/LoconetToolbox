using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class SwitchRequest : Request
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public SwitchRequest()
        {
        }

        /// <summary>
        /// Address
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// True for closed/Green, False for Thrown/Red
        /// </summary>
        public bool Direction { get; set; }

        /// <summary>
        /// True for on, false for off
        /// </summary>
        public bool Output { get; set; }

        /// <summary>
        /// Convert to readable string
        /// </summary>
        public override string ToString()
        {
            return string.Format("SW_REQ addr:{0}, dir:{1}, output:{2}", Address, Direction, Output);
        }

        /// <summary>
        /// Create the byte level message
        /// </summary>
        private byte[] CreateMessage()
        {
            var dir = Direction ? 0x20 : 0x00;
            var output = Output ? 0x10 : 0x00;
            var msg = new byte[4];
            msg[0] = 0xB0; // Opcode
            msg[1] = (byte)(Address & 0x7F);
            msg[2] = (byte)(((Address >> 7) & 0x0F) | dir | output);
            UpdateChecksum(msg, msg.Length);
            return msg;
        }

        /// <summary>
        /// Execute the message on the given buffer
        /// </summary>
        internal override void Execute(LocoBuffer lb)
        {
            using (var registration = lb.AddHandler(HandleMessage))
            {
                lb.Send(CreateMessage());
            }
        }

        /// <summary>
        /// Receive handler.
        /// </summary>
        private bool HandleMessage(byte[] msg)
        {
            return false;
        }
    }
}
