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

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOPortOutputConfigControl : UserControl
    {
        /// <summary>
        /// Fired when settings are changed.
        /// </summary>
        public event EventHandler Changed;
        private PortConfig config;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOPortOutputConfigControl()
        {
            InitializeComponent();
        }

        internal void Initialize(PortConfig config)
        {
            this.config = null;
            cbLowAtStartup.Checked = config.LowAtStartup;
            cbHWReset.Checked = config.HardwareReset;
            cbPulseContact.Checked = config.PulseContact;
            cbFlash.Checked = config.Flash;
            cbMulti.Checked = config.Multi;
            cbBlockDetector.Checked = config.BlockDetector;
            this.config = config;
        }

        /// <summary>
        /// Checkbox has changed.
        /// </summary>
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (config != null)
            {
                config.LowAtStartup = cbLowAtStartup.Checked;
                config.HardwareReset = cbHWReset.Checked;
                config.PulseContact = cbPulseContact.Checked;
                config.Flash = cbFlash.Checked;
                config.Multi = cbMulti.Checked;
                config.BlockDetector = cbBlockDetector.Checked;
                Changed.Fire(this);
            }
        }
    }
}
