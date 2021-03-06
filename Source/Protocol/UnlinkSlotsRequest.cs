﻿/*
Loconet toolbox
Copyright (C) 2010 Modelspoorgroep Venlo, Ewout Prangsma

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
namespace LocoNetToolBox.Protocol
{
    /// <summary>
    /// OPC_LINK_SLOTS
    /// </summary>
    public class UnlinkSlotsRequest : Request
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public UnlinkSlotsRequest(int slot1, int slot2)
        {
            Slot1 = slot1;
            Slot2 = slot2;
        }

        /// <summary>
        /// Parse ctor
        /// </summary>
        public UnlinkSlotsRequest(byte[] msg)
        {
            Slot1 = msg[1];
            Slot2 = msg[2];
        }

        /// <summary>
        /// Accept a visit by the given visitor.
        /// </summary>
        public override TReturn Accept<TReturn, TData>(MessageVisitor<TReturn, TData> visitor, TData data)
        {
            return visitor.Visit(this, data);
        }

        /// <summary>
        /// Slot number 1
        /// </summary>
        public int Slot1 { get; set; }

        /// <summary>
        /// Slot number 2
        /// </summary>
        public int Slot2 { get; set; }

        /// <summary>
        /// Create the byte level message
        /// </summary>
        private byte[] CreateMessage()
        {
            var msg = new byte[4];
            msg[0] = 0xB8; // Opcode
            msg[1] = (byte)(Slot1 & 0x7F);
            msg[2] = (byte)(Slot2 & 0x7F);
            UpdateChecksum(msg, msg.Length);
            return msg;
        }

        /// <summary>
        /// Execute the message on the given buffer
        /// </summary>
        public override void Execute(LocoBuffer lb)
        {
            lb.Send(this, CreateMessage());
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        public override string ToString()
        {
            return string.Format("OPC_UNLINK_SLOTS sl1:{0} sl2:{1}", Slot1, Slot2);
        }
    }
}
