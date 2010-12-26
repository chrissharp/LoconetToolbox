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
using System.Linq;
using System.Windows.Forms;

using LocoNetToolBox.Devices.LocoIO;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOConnectorConfigurationControl : UserControl
    {
        private readonly Label[] labels;
        private readonly NumericUpDown[] addressControls;
        private readonly AddressList addresses;
        private Connector connector;
        private int oldAddress;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConnectorConfigurationControl()
        {
            InitializeComponent();

            labels = new[] { lbPin1, lbPin2, lbPin3, lbPin4, lbPin5, lbPin6, lbPin7, lbPin8 };
            addressControls = new[] { tbAddr1, tbAddr2, tbAddr3, tbAddr4, tbAddr5, tbAddr6, tbAddr7, tbAddr8 };
            addresses = new AddressList(8);         

            for (int i = 0; i < 8; i++)
            {
                var tbAddr = addressControls[i];
                tbAddr.Value = addresses[i];
                var index = i;
                tbAddr.GotFocus += (s, x) => { 
                    tbAddr.Select(0, tbAddr.Value.ToString().Length);
                    oldAddress = (int)tbAddr.Value;
                };
                tbAddr.ValueChanged += (s, x) => {
                    addresses[index] = (int) tbAddr.Value;
                    var newAddress = (int)tbAddr.Value;
                    var tbNextAddr = (index + 1 < 8) ? addressControls[index + 1] : null;
                    if ((tbNextAddr != null) && (tbNextAddr.Value == oldAddress +1))
                    {
                        // Adjust next address
                        oldAddress = (int)tbNextAddr.Value;
                        tbNextAddr.Value = newAddress + 1;
                    }
                };
            }

            Connector = Connector.First;
            lvModes.Items.AddRange(ConnectorMode.All.Select(x => new ListViewItem(x.Name) { Tag = x }).ToArray());
            UpdateUI();
        }

        /// <summary>
        /// Create a configuration from the settings found in this control.
        /// </summary>
        public ConnectorConfig CreateConfig()
        {
            var mode = SelectedMode ?? ConnectorMode.None;
            return mode.CreateConfig(connector, addresses);
        }

        /// <summary>
        /// Connect this control to the given configuration
        /// </summary>
        public void Connect(ConnectorConfig config)
        {
        }

        /// <summary>
        /// Sets the connector, used to set the pins.
        /// </summary>
        public Connector Connector
        {
            set
            {
                var firstPin = (value == Connector.First) ? 1 : 9;
                for (int i = 0; i < 8; i++)
                {
                    labels[i].Text = (firstPin + i).ToString();
                }
            }
        }

        /// <summary>
        /// Gets the currently selected connector mode.
        /// </summary>
        private ConnectorMode SelectedMode
        {
            get 
            { 
                if (lvModes.SelectedItems.Count == 0)
                    return null;
                var selection = lvModes.SelectedItems[0];
                return (ConnectorMode) selection.Tag;
            }
        }

        /// <summary>
        /// Update the ui controls
        /// </summary>
        private void UpdateUI()
        {
            var selection = SelectedMode;
            var addressCount = (selection != null) ? selection.AddressCount : 0;
            for (int i = 0; i < 8; i++ )
            {
                var visible = (i < addressCount);
                labels[i].Enabled = visible;
                addressControls[i].Enabled = visible;
            }
        }

        /// <summary>
        /// Selected connector mode has changed.
        /// </summary>
        private void lvModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
