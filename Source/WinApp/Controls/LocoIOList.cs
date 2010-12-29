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
using System.Windows.Forms;

using LocoNetToolBox.Protocol;
using LocoNetToolBox.WinApp.Communications;
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOList : UserControl
    {
        /// <summary>
        /// Selected address has changed.
        /// </summary>
        public event EventHandler SelectionChanged;

        private AppState appState;
        private AsyncLocoBuffer lb;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOList()
        {
            InitializeComponent();
            UpdateUI();
        }

        /// <summary>
        /// Attach to the given application.
        /// </summary>
        internal AppState AppState
        {
            set
            {
                if (appState != null)
                {
                    appState.LocoBufferChanged -= AppStateLocoBufferChanged;
                }
                appState = value;
                if (appState != null)
                {
                    appState.LocoBufferChanged += AppStateLocoBufferChanged;
                }
                AppStateLocoBufferChanged(null, null);
            }
        }

        private void AppStateLocoBufferChanged(object sender, EventArgs e)
        {
            if (lb != null)
            {
                lb.PreviewMessage -= LbPreviewMessage;
            }
            lb = (appState != null) ? appState.LocoBuffer : null;
            if (lb != null)
            {
                lb.PreviewMessage += LbPreviewMessage;
            }
        }

        /// <summary>
        /// Gets the selected address.
        /// Returns null if there is no selection.
        /// </summary>
        public LocoNetAddress SelectedAddress
        {
            get
            {
                if (lbModules.SelectedItems.Count > 0)
                {
                    var item = lbModules.SelectedItems[0];
                    return (LocoNetAddress)item.Tag;
                }
                return null;
            }
        }

        /// <summary>
        /// Listen to loconet message.
        /// Use results of Query requests to generate a list of locoio modules.
        /// </summary>
        private bool LbPreviewMessage(byte[] message, Message decoded)
        {
            var response = Response.Decode(message) as PeerXferResponse;
            if (response != null)
            {
                if (response.SvAddress == 0)
                {
                    if (response.IsSourcePC)
                    {
                        // Query request
                        lbModules.Items.Clear();
                    }
                    else
                    {
                        var item = new ListViewItem();
                        item.Text = response.Source.ToString();
                        item.Tag = response.Source;
                        item.SubItems.Add(string.Format("{0}.{1}", response.LocoIOVersion/100,
                                                        response.LocoIOVersion%100));
                        lbModules.Items.Add(item);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Selection has changed
        /// </summary>
        private void LbModulesSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
            SelectionChanged.Fire(this);
        }

        /// <summary>
        /// Program active address
        /// </summary>
        private void LbModulesItemActivate(object sender, EventArgs e)
        {
            CmdConfigureMgv50Click(sender, e);
        }

        /// <summary>
        /// Configure the selected MGV50.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdConfigureMgv50Click(object sender, EventArgs e)
        {
            var currentAddress = SelectedAddress;
            if (currentAddress != null)
            {
                var dialog = new LocoIOConfigurationForm();
                dialog.Initialize(lb, currentAddress);
                dialog.Show();
            }
        }

        /// <summary>
        /// Advanced MGV50 configuration
        /// </summary>
        private void CmdConfigMgv50AdvancedClick(object sender, EventArgs e)
        {
            var currentAddress = SelectedAddress;
            if (currentAddress != null)
            {
                var dialog = new LocoIOAdvancedConfigurationForm();
                dialog.Initialize(lb, currentAddress);
                dialog.Show();
            }
        }

        /// <summary>
        /// Update the controls
        /// </summary>
        private void UpdateUI()
        {
            var hasAddress = (SelectedAddress != null);
            cmdConfigureMgv50.Enabled = hasAddress;
            cmdConfigMgv50Advanced.Enabled = hasAddress;
        }
    }
}
