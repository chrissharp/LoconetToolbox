using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LocoNetToolBox.Devices.LocoIO
{
    /// <summary>
    /// Configuration of an entire LocoIO.
    /// </summary>
    public class LocoIOConfig : IEnumerable<SVConfig>
    {
        private readonly SVConfig sv0;
        private readonly SVConfig sv1;
        private readonly SVConfig sv2;
        private PinConfigList pins;
        private ConnectorConfig[] connectors;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConfig()
        {
            var pins = new PinConfig[16];
            for (int i = 0; i < 16; i++)
            {
                pins[i] = new PinConfig(i + 1);
            }
            this.sv0 = new SVConfig(0);
            this.sv1 = new SVConfig(1);
            this.sv2 = new SVConfig(2);
            this.pins = new PinConfigList(pins);
            this.connectors = new ConnectorConfig[2];
            connectors[0] = new ConnectorConfig(pins.Take(8).ToArray());
            connectors[1] = new ConnectorConfig(pins.Skip(8).ToArray());
        }

        /// <summary>
        /// Gets all pins
        /// </summary>
        public PinConfigList Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// Gets the first connector
        /// </summary>
        public ConnectorConfig ConnectorA
        {
            get { return connectors[0]; }
        }

        /// <summary>
        /// Gets the second connector
        /// </summary>
        public ConnectorConfig ConnectorB
        {
            get { return connectors[1]; }
        }

        /// <summary>
        /// Gets all SV's of this LocoIO
        /// </summary>
        public IEnumerator<SVConfig> GetEnumerator()
        {
            yield return sv0;
            yield return sv1;
            yield return sv2;
            foreach (var pin in pins)
            {
                foreach (var sv in pin)
                {
                    yield return sv;
                }
            }
        }

        /// <summary>
        /// Gets all SV's of this LocoIO
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
