using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class LocoNetAddress
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoNetAddress(byte address, byte subAddress)
        {
            this.Address = address;
            this.SubAddress = subAddress;
        }

        /// <summary>
        /// Primary (also low) address
        /// </summary>
        public byte Address { get; private set; }

        /// <summary>
        /// Sub (also high) address
        /// </summary>
        public byte SubAddress { get; private set; }

        /// <summary>
        /// Compare to other address.
        /// </summary>
        public bool Equals(LocoNetAddress other)
        {
            return (other != null) && (other.Address == this.Address) && (other.SubAddress == this.SubAddress);
        }

        /// <summary>
        /// Compare to other address.
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as LocoNetAddress);
        }

        /// <summary>
        /// Convert to human readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}/{1}", Address, SubAddress);
        }

        /// <summary>
        /// Hashing
        /// </summary>
        public override int GetHashCode()
        {
            return Address ^ SubAddress;
        }
    }
}
