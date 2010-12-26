using System.Collections.Generic;
using System.Linq;
using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.Devices.LocoIO
{
    /// <summary>
    /// LocoIO programmer
    /// </summary>
    public class Programmer
    {
        private readonly LocoNetAddress address;
        private readonly int timeout;

        /// <summary>
        /// Default ctor
        /// </summary>
        internal Programmer(LocoNetAddress address)
        {
            this.address = address;
            timeout = 500;
        }

        /// <summary>
        /// Read the given set of SV values into configs.
        /// </summary>
        internal void Read(LocoBuffer lb, IEnumerable<SVConfig> configs)
        {
            var list = configs.ToList();
            list.Sort();

            foreach (var iterator in configs)
            {
                var config = iterator;
                var cmd = new PeerXferRequest1
                              {
                    Command = PeerXferRequest.Commands.Read,
                    SvAddress = config.Index,
                    DestinationLow = address.Address,
                    SubAddress = address.SubAddress,
                };

                config.Valid = false;
                var result = cmd.ExecuteAndWaitForResponse<PeerXferResponse>(
                    lb, 
                    x => (address.Equals(x.Source) && x.SvAddress == config.Index),
                    timeout);
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
        internal void Write(LocoBuffer lb, IEnumerable<SVConfig> configs)
        {
            var list = configs.ToList();
            list.Sort();

            foreach (var config in configs)
            {
                var cmd = new PeerXferRequest1
                              {
                    Command = PeerXferRequest.Commands.Write,
                    SvAddress = config.Index,
                    DestinationLow = address.Address,
                    SubAddress = address.SubAddress,
                    Data1 = config.Value,
                };
                cmd.Execute(lb);
            }
        }
    }
}
