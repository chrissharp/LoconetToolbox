using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class PeerXferResponse1 : PeerXferResponse
    {
        private readonly byte[] data;

        /// <summary>
        /// Default ctor
        /// </summary>
        public PeerXferResponse1(byte[] data)
            : base(data)
        {
            this.data = data;
        }

        /// <summary>
        /// Low byte source address
        /// </summary>
        protected override byte SourceLow { get { return data[2]; } }

        /// <summary>
        /// High byte source address
        /// </summary>
        protected override byte SourceHigh { get { return data[11]; } }

        /// <summary>
        /// Low byte of destination address
        /// </summary>
        protected override byte DestinationLow { get { return data[3]; } }

        /// <summary>
        /// High byte of destination address
        /// </summary>
        protected override byte DestinationHigh { get { return data[4]; } }

        /// <summary>
        /// Command to send
        /// </summary>
        public override PeerXferRequest.Commands OriginalCommand { get { return (PeerXferRequest.Commands)data[6]; } }

        /// <summary>
        /// 16-bit EEPROM address for read/write
        /// </summary>
        public override int SvAddress { get { return data[7]; } }

        public override int LocoIOVersion { get { return GetSplitValue(data[8], data[5], 2); }}

        /// <summary>
        /// D1
        /// </summary>
        public override byte Data1 { get { return GetSplitValue(data[12], data[10], 2); } }

        /// <summary>
        /// D2
        /// </summary>
        public override byte Data2 { get { return GetSplitValue(data[13], data[10], 1); } }

        /// <summary>
        /// D3
        /// </summary>
        public override byte Data3 { get { return GetSplitValue(data[14], data[10], 0); } }
    }
}
