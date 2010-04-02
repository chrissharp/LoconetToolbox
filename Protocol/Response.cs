using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public abstract class Response : Message
    {
        private static readonly Func<byte[], Response>[] DECODERS = new Func<byte[], Response>[] { 
            InputReport.TryDecode,
            SwitchReport.TryDecode,
            PeerXferResponse.TryDecode
        };

        /// <summary>
        /// Create a response object if the given data is recognized.
        /// </summary>
        internal static Response Decode(byte[] data)
        {
            foreach (var decoder in DECODERS)
            {
                var result = decoder(data);
                if (result != null) { return result; }
            }
            return null;
        }
    }
}
