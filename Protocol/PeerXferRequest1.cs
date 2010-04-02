using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class PeerXferRequest1 : PeerXferRequest
    {
        public PeerXferRequest1()
        {
            DestinationHigh = 1;
        }

        /// <summary>
        /// Create the byte level message
        /// </summary>
        private byte[] CreateMessage()
        {
            int sv_adrl = SvAddress & 0xFF;
            int sv_adrh = (SvAddress >> 2) & 0xFF;

            var msg = new byte[16];
            msg[0] = 0xE5; // Opcode
            msg[1] = 0x10; // Message length
            msg[2] = PC_ADDRESS; // Source address low (PC os 01 80)
            msg[3] = (byte)DestinationLow;
            msg[4] = (byte)DestinationHigh;
            //msg[5] = pxct1;
            msg[6] = (byte)Command;
            msg[7] = (byte)SvAddress;
            msg[8] = 0;
            msg[9] = (byte)Data1;
            //msg[10] = pxct2;
            msg[11] = 0;
            msg[12] = 0;
            msg[13] = 0;
            msg[14] = 0;

            int pxct1 = 0;
            int pxct2 = 0;
            for (int i = 0; i < 4; i++)
            {
                if ((msg[6 + i] & 0x80) != 0)
                {
                    pxct1 |= 1 << i;
                    msg[6 + i] &= 0x7F;
                }
                if ((msg[11 + i] & 0x80) != 0)
                {
                    pxct2 |= 1 << i;
                    msg[11 + i] &= 0x7F;
                }
            }
            msg[5] = (byte)pxct1;
            msg[10] = (byte)pxct2;

            // Remaining all null
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
