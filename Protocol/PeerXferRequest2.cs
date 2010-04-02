using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class PeerXferRequest2 : PeerXferRequest
    {
        /// <summary>
        /// Create the byte level message
        /// </summary>
        private byte[] CreateMessage()
        {
            int sv_adrl = SvAddress & 0xFF;
            int sv_adrh = (SvAddress >> 2) & 0xFF;

            byte svx1 = (byte)(0x10 | GetBit7(sv_adrh, 3) | GetBit7(sv_adrl, 2) | GetBit7(DestinationHigh, 1) | GetBit7(DestinationLow, 0));
            byte svx2 = (byte)(0x10 | GetBit7(Data4, 3) | GetBit7(Data3, 2) | GetBit7(Data2, 1) | GetBit7(Data1, 0));
            var msg = new byte[16];
            msg[0] = 0xE5; // Opcode
            msg[1] = 0x10; // Message length
            msg[2] = 0x50; // Source address low (PC os 01 80)
            msg[3] = (byte)Command;
            msg[4] = 0x02; // SV_TYPE
            msg[5] = svx1;
            msg[6] = (byte)(DestinationLow & 0x7F);
            msg[7] = (byte)(DestinationHigh & 0x7F);
            msg[8] = (byte)(sv_adrl & 0x7F);
            msg[9] = (byte)(sv_adrh & 0x7F);
            msg[10] = svx2;
            msg[11] = (byte)(Data1 & 0x7F);
            msg[12] = (byte)(Data1 & 0x7F);
            msg[13] = (byte)(Data1 & 0x7F);
            msg[14] = (byte)(Data1 & 0x7F);
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
