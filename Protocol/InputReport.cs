using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class InputReport : Response
    {
        /// <summary>
        /// Message ctor
        /// </summary>
        internal InputReport(byte[] data)
        {
            var low = data[1] & 0x7F;
            var high = data[2] & 0x0F;
            var bit0 = (data[2] & 0x20) >> 5;
            this.Address = (low << 1) | (high << 8) | bit0;
        }


        /// <summary>
        /// Create a response object if the given data is recognized.
        /// </summary>
        internal static Response TryDecode(byte[] data)
        {
            if (data[0] == 0xB2) { return new InputReport(data); }
            return null;
        }

        /// <summary>
        /// Address
        /// </summary>
        public int Address { get; set; }

        public override string ToString()
        {
            return string.Format("INPUT_REP addr:{0}", Address);
        }
    }
}
