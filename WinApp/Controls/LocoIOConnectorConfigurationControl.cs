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
    public partial class LocoIOConnectorConfigurationControl : UserControl
    {
        private bool advanced = false;
        private readonly Label[] labels;
        private readonly NumericUpDown[] addresses;
        private readonly LocoIOPinConfigurationControl[] pins;
        private ConnectorConfig config;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConnectorConfigurationControl()
        {
            InitializeComponent();

            labels = new Label[] { lbPin1, lbPin2, lbPin3, lbPin4, lbPin5, lbPin6, lbPin7, lbPin8 };
            addresses = new NumericUpDown[] { tbAddr1, tbAddr2, tbAddr3, tbAddr4, tbAddr5, tbAddr6, tbAddr7, tbAddr8 };
            pins = new LocoIOPinConfigurationControl[] { cfgPort1, cfgPort2, cfgPort3, cfgPort4, cfgPort5, cfgPort6, cfgPort7, cfgPort8 };

            for (int i = 0; i < 8; i++)
            {
                var tbAddr = addresses[i];
                var pin = pins[i];
                var index = i;
                tbAddr.GotFocus += (s, x) => tbAddr.Select(0, tbAddr.Value.ToString().Length);
                tbAddr.ValueChanged += (s, x) => OnAddressChanged(tbAddr, index);
            }

            this.FirstPin = 1;
            lvModes.Items.AddRange(ConnectorMode.All.Select(x => new ListViewItem(x.Name) { Tag = x }).ToArray());
            UpdateUI();
        }

        /// <summary>
        /// Connect this control to the given configuration
        /// </summary>
        public void Connect(ConnectorConfig config)
        {
            this.config = config;
            for (int i = 0; i < 8; i++)
            {
                var pinConfig = config.Pins[i];
                var tbAddr = addresses[i];
                tbAddr.Value = pinConfig.Address;
                pins[i].Connect(pinConfig);
                pinConfig.AddressChanged += (s, x) => this.PostOnGuiThread(() => tbAddr.Value = pinConfig.Address);
            }
        }

        /// <summary>
        /// Sets the pin number of the first pin.
        /// </summary>
        public int FirstPin
        {
            set
            {
                for (int i = 0; i < 8; i++)
                {
                    labels[i].Text = (value + i).ToString();
                }
            }
        }

        /// <summary>
        /// Is this control showing advanced mode?
        /// </summary>
        public bool Advanced
        {
            get { return advanced; }
            set { if (advanced != value) { advanced = value; UpdateUI(); } }
        }

        /// <summary>
        /// Update the ui controls
        /// </summary>
        private void UpdateUI()
        {
            tlpMain.ColumnStyles[2] = new ColumnStyle(advanced ? SizeType.Percent : SizeType.AutoSize, 100);
            tlpMain.ColumnStyles[3] = new ColumnStyle(advanced ? SizeType.AutoSize : SizeType.Percent, 100);
            foreach (var pin in pins) { pin.Visible = advanced; }
            lvModes.Visible = !advanced;
            lbConfigAdvCaption.Visible = advanced;
            lbConfigCaption.Visible = !advanced;
        }

        /// <summary>
        /// Forward address to pin configuration
        /// </summary>
        private void OnAddressChanged(NumericUpDown tbAddr, int index)
        {
            if (config != null)
            {
                var pinConfig = config.Pins[index];
                pinConfig.Address = (int)tbAddr.Value;
            }
        }

        /// <summary>
        /// Selected connector mode has changed.
        /// </summary>
        private void lvModes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
