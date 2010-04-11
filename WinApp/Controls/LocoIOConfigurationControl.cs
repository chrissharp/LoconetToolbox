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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Devices.LocoIO;
using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOConfigurationControl : UserControl
    {
        private LocoIOConfig config;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConfigurationControl()
        {
            InitializeComponent();
            connector1.FirstPin = 1;
            connector1.Advanced = true;
            connector2.FirstPin = 9;
            connector2.Advanced = true;
        }

        /// <summary>
        /// Connect to the given config
        /// </summary>
        public void Connect(LocoIOConfig config)
        {
            this.config = config;
            connector1.Connect(config.ConnectorA);
            connector2.Connect(config.ConnectorB);
        }

        /// <summary>
        /// Read all settings
        /// </summary>
        internal void ReadAll(LocoBuffer lb, LocoNetAddress address)
        {
            // Create a set of all SV's that are relevant
            /*var configs = LocoIOConfig.GetAllSVs();

            // Create the programmer
            var programmer = new Programmer(lb, address);

            // Read all SV's
            programmer.Read(configs);

            // Get all properly read configs
            var validConfigs = configs.Where(x => x.Valid).ToArray();
            */



        }
    }
}
