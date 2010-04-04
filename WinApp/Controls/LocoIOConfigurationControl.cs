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

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOConfigurationControl : UserControl
    {
        private readonly LocoIOPinConfigurationControl[] portControls;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConfigurationControl()
        {
            InitializeComponent();
            this.portControls = new LocoIOPinConfigurationControl[] {
                cfgPort1, cfgPort2, cfgPort3, cfgPort4, cfgPort5, cfgPort6, cfgPort7, cfgPort8, 
                cfgPort9, cfgPort10, cfgPort11, cfgPort12, cfgPort13, cfgPort14, cfgPort15, cfgPort16
            };
            foreach (var ctr in portControls)
            {
                ctr.Enabled = true;
            }
        }

        /// <summary>
        /// Read all settings
        /// </summary>
        internal void ReadAll(LocoBuffer lb, LocoNetAddress address)
        {
            foreach (var ctr in portControls)
            {
                ctr.ReadAll(lb, address);
            }
        }
    }
}
