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

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp
{
    public partial class MainForm : Form
    {
        private readonly LocoBuffer lb;

        /// <summary>
        /// Default ctor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this.lb = new LocoBuffer();
            locoBufferView1.LocoBuffer = lb;
            commandControl1.LocoBuffer = lb;
            locoIOList1.LocoBuffer = lb;

            locoIOList1.SelectionChanged += new EventHandler(locoIOList1_SelectionChanged);
            locoIOList1.ProgramSelectedAddress += new EventHandler(locoIOList1_ProgramSelectedAddress);
        }

        /// <summary>
        /// Program selected address
        /// </summary>
        private void locoIOList1_ProgramSelectedAddress(object sender, EventArgs e)
        {
            commandControl1.ProgramLocoIO();
        }

        /// <summary>
        /// Selected Loconet address changed
        /// </summary>
        private void locoIOList1_SelectionChanged(object sender, EventArgs e)
        {
            commandControl1.CurrentAddress = locoIOList1.SelectedAddress;
        }

        /// <summary>
        /// Close locobuffer on form close
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            lb.Close();
            base.OnFormClosing(e);
        }
    }
}
