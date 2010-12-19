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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LocoNetToolBox.Model;
using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp
{
    public partial class MainForm : Form
    {
        private LocoBuffer lb;
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
            lnState.Dispose();
            lb.Close();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Locobuffer has changed.
        /// </summary>
        private void locoBufferView1_LocoBufferChanged(object sender, EventArgs e)
        {
            SetLocoBuffer(locoBufferView1.LocoBuffer);
        }

        /// <summary>
        /// Pass the given locobuffer on to all components.
        /// </summary>
        private void SetLocoBuffer(LocoBuffer lb)
        {
            if (this.lb != lb)
            {
                this.lb = lb;
                lnState = new LocoNetState(lb);
                locoBufferView1.LocoBuffer = lb;
                commandControl1.LocoBuffer = lb;
                commandControl1.LocoNetState = lnState;
                locoIOList1.LocoBuffer = lb;
            }
        }
    }
}
