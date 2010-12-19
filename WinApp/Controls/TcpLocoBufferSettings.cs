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
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.WinApp.Preferences;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class TcpLocoBufferSettings : UserControl
    {
        private Protocol.TcpLocoBuffer locoBuffer;
        private bool initialized = false;

        /// <summary>
        /// Default ctor
        /// </summary>
        public TcpLocoBufferSettings()
        {
            InitializeComponent();

            // First ports
            initialized = true;
        }

        /// <summary>
        /// Set data
        /// </summary>
        internal Protocol.TcpLocoBuffer LocoBuffer
        {
            set
            {
                if (this.locoBuffer != null)
                {
                    this.locoBuffer.Closed -= new EventHandler(locoBuffer_Closed);
                    this.locoBuffer.Opened -= new EventHandler(locoBuffer_Opened);
                }
                this.locoBuffer = value;
                if (value != null)
                {
                    tbIpAddress.Text = value.IpAddress;
                    tbPort.Text = value.Port.ToString();
                }
                Save();
                if (this.locoBuffer != null)
                {
                    this.locoBuffer.Closed += new EventHandler(locoBuffer_Closed);
                    this.locoBuffer.Opened += new EventHandler(locoBuffer_Opened);
                }
            }
        }

        void locoBuffer_Opened(object sender, EventArgs e)
        {
            this.Enabled = false;
        }

        void locoBuffer_Closed(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        /// <summary>
        /// Save settings into lb.
        /// </summary>
        private void Save()
        {
            var lb = this.locoBuffer;
            if (lb != null) {
                // Close first
                lb.Close();
                // copy settings to lb.
                lb.IpAddress = tbIpAddress.Text.Trim();
                lb.Port = int.Parse(tbPort.Text);
            }
        }

        private void tbIpAddress_Validated(object sender, EventArgs e)
        {
            Save();
        }

        private void tbPort_Validated(object sender, EventArgs e)
        {
            Save();
        }

        private void tbIpAddress_Validating(object sender, CancelEventArgs e)
        {
            var text = tbIpAddress.Text;
            IPAddress addr;
            if (!IPAddress.TryParse(text, out addr))
                e.Cancel = true;
        }

        private void tbPort_Validating(object sender, CancelEventArgs e)
        {
            var text = tbPort.Text;
            int port;
            if (!int.TryParse(text, out port))
                e.Cancel = true;
        }
    }
}
