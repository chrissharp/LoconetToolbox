using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class SwitchReport : Response
    {
        /// <summary>
        /// Message ctor
        /// </summary>
        internal SwitchReport(byte[] data)
        {
            var low = data[1] & 0x7F;
            var high = data[2] & 0x0F;
            this.Address = (low | (high << 7)) + 1;
            this.Direction = ((data[2] & 0x20) != 0);
            this.Output = ((data[2] & 0x10) != 0);
        }


        /// <summary>
        /// Create a response object if the given data is recognized.
        /// </summary>
        internal static Response TryDecode(byte[] data)
        {
            if (data[0] == 0xB1) { return new SwitchReport(data); }
            return null;
        }

        /// <summary>
        /// Address
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// Direction: true = closed, false = thrown
        /// </summary>
        public bool Direction { get; set; }

        /// <summary>
        /// Output: true = on, false = off
        /// </summary>
        public bool Output { get; set; }

        public override string ToString()
        {
            return string.Format("SW_REP addr:{0}, dir:{1}, output:{2}", 
                Address,
                Direction ? "closed" : "thrown",
                Output ? "on" : "off");
        }
    }
}
