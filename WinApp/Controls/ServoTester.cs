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
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class ServoTester : Form
    {
        private readonly Action<Request> execute;

        /// <summary>
        /// Designer ctor
        /// </summary>
        public ServoTester() : this(null)
        {
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServoTester(Action<Request> execute)
        {
            this.execute = execute;
            InitializeComponent();
        }

        /// <summary>
        /// Go left.
        /// </summary>
        private void cmdLeft_Click(object sender, EventArgs e)
        {
            execute(new SwitchRequest()
            {
                Address = (int)udAddress.Value - 1,
                Direction = true,
                Output = true
            });
        }

        /// <summary>
        /// Go right
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            execute(new SwitchRequest()
            {
                Address = (int)udAddress.Value - 1,
                Direction = false,
                Output = true
            });
        }
    }
}
