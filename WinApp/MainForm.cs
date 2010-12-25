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
using LocoNetToolBox.Model;
using LocoNetToolBox.Protocol;
using LocoNetToolBox.WinApp.Communications;

namespace LocoNetToolBox.WinApp
{
    public partial class MainForm : Form
    {
        private LocoBuffer lb;
        private AsyncLocoBuffer asyncLb;
        private LocoNetState lnState;

        /// <summary>
        /// Default ctor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            SetLocoBuffer(new SerialPortLocoBuffer());
        }

        /// <summary>
        /// Close locobuffer on form close
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseLb();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Locobuffer has changed.
        /// </summary>
        private void LocoBufferView1LocoBufferChanged(object sender, EventArgs e)
        {
            SetLocoBuffer(locoBufferView1.ConfiguredLocoBuffer);
        }

        /// <summary>
        /// Pass the given locobuffer on to all components.
        /// </summary>
        private void SetLocoBuffer(LocoBuffer lb)
        {
            if (this.lb != lb)
            {
                CloseLb();
                this.lb = lb;
                asyncLb = new AsyncLocoBuffer(this, lb);
                lnState = new LocoNetState(lb);
                locoBufferView1.ConfiguredLocoBuffer = lb;
                locoBufferView1.LocoBuffer = asyncLb;
                commandControl1.LocoBuffer = asyncLb;
                commandControl1.LocoNetState = lnState;
                locoIOList1.LocoBuffer = asyncLb;
            }
        }

        /// <summary>
        /// Close any active locobuffer connection
        /// </summary>
        private void CloseLb()
        {
            if (asyncLb != null)
            {
                asyncLb.Dispose();
                asyncLb = null;
            }
            if (lnState != null)
            {
                lnState.Dispose();
                lnState = null;
            }
            if (lb != null)
            {
                lb.Close();
                lb = null;
            }
        }
    }
}
