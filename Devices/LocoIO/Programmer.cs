using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.Devices.LocoIO
{
    /// <summary>
    /// LocoIO programmer
    /// </summary>
    public class Programmer
    {
        private readonly LocoBuffer lb;
        private readonly LocoNetAddress address;
        private readonly int timeout;

        /// <summary>
        /// Default ctor
        /// </summary>
        internal Programmer(LocoBuffer lb, LocoNetAddress address)
        {
            this.lb = lb;
            this.address = address;
            this.timeout = 500;
        }

        /// <summary>
        /// Read the given set of SV values into configs.
        /// </summary>
        public void Read(IEnumerable<SVConfig> configs)
        {
            var list = configs.ToList();
            list.Sort();

            foreach (var config in configs)
            {
                var cmd = new PeerXferRequest1()
                {
                    Command = PeerXferRequest.Commands.Read,
                    SvAddress = config.Index,
                    DestinationLow = address.Address,
                    SubAddress = address.SubAddress,
                };

                config.Valid = false;
                var result = cmd.ExecuteAndWaitForResponse<PeerXferResponse>(lb, x => {
                    return (address.Equals(x.Source) && x.SvAddress == config.Index);
                }, timeout);
                if (result != null)
                {
                    config.Value = result.Data1;
                    config.Valid = true;
                }
            }
        }

        /// <summary>
        /// Write the given set of SV values
        /// </summary>
        public void Write(IEnumerable<SVConfig> configs)
        {
            var list = configs.ToList();
            list.Sort();

            foreach (var config in configs)
            {
                var cmd = new PeerXferRequest1()
                {
                    Command = PeerXferRequest.Commands.Write,
                    SvAddress = config.Index,
                    DestinationLow = address.Address,
                    SubAddress = address.SubAddress,
                    Data1 = (byte)config.Value,
                };
                cmd.Execute(lb);
            }
        }
    }
}
