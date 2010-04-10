/*
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LocoNetToolBox.Devices.LocoIO
{
    /// <summary>
    /// SV settings for a single port of a LocoIO module.
    /// </summary>
    public class PinConfig
    {
        // mode
        private PinMode mode;
        private int address;

        // SV values
        private byte config;
        private byte value1;
        private byte value2;

        /// <summary>
        /// Mode of the pin.
        /// </summary>
        [XmlIgnore]
        public PinMode Mode
        {
            get { return mode; }
            set { mode = value; UpdateValues(); }
        }

        /// <summary>
        /// Loconet address of this port.
        /// </summary>
        [XmlIgnore]
        public int Address
        {
            get { return address; }
            set { address = value; UpdateValues(); }
        }

        // SV values

        /// <summary>
        /// First SV for this pin.
        /// </summary>
        public byte Config
        {
            get { return config; }
            set { config = value; UpdateFunctionalSettings(); }
        }

        /// <summary>
        /// Second SV for this pin.
        /// </summary>
        public byte Value1
        {
            get { return value1; }
            set { value1 = value; UpdateFunctionalSettings(); }
        }

        /// <summary>
        /// Third SV for this pin.
        /// </summary>
        public byte Value2
        {
            get { return value2; }
            set { value2 = value; UpdateFunctionalSettings(); }
        }

        /// <summary>
        /// Update functional settings fom SV values
        /// </summary>
        private void UpdateFunctionalSettings()
        {
            this.mode = PinMode.Find(config, value1, value2);
            // TODO Address
        }

        /// <summary>
        /// Calculate config, value1 and value2 from functional settings.
        /// </summary>
        private void UpdateValues()
        {
            if (mode == null)
            {
                config = 0;
                value1 = 0;
                value2 = 0;
            }
            else
            {
                config = (byte)mode.GetConfig();
                value1 = (byte)mode.GetValue1(address);
                value2 = (byte)mode.GetValue2(address);
            }
        }
    }
}
