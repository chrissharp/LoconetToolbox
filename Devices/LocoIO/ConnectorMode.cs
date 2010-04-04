using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Devices.LocoIO
{
    /// <summary>
    /// Mode for a single connector (8 pins)
    /// </summary>
    public sealed partial class ConnectorMode 
    {
        private readonly PinMode[] pins;

        /// <summary>
        /// Default ctor
        /// </summary>
        private ConnectorMode(string name, params PinMode[] pins)
        {
            if ((pins.Length < 1) || (pins.Length > 8))
            {
                throw new ArgumentException("Invalid number of pins");
            }
            this.pins = pins;
            this.Name = name;
        }

        /// <summary>
        /// Human readable name of this mode.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the number of pins used in this mode.
        /// </summary>
        public int PinCount { get { return pins.Length; } }

        /// <summary>
        /// Gets all pin modes.
        /// </summary>
        public IEnumerable<PinMode> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// Gets the name
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}
