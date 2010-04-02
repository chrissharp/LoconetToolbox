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
using System.Threading;

using LocoNetToolBox.Protocol;
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class ServoProgrammerStep4 : UserControl
    {
        private Devices.MgvServo.ServoProgrammer programmer;

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServoProgrammerStep4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        internal void Initialize(Devices.MgvServo.ServoProgrammer programmer)
        {
            this.programmer = programmer;
            programmer.Turnout = turnoutSelection.Turnout;
        }

        /// <summary>
        /// Set left position
        /// </summary>
        private void cmdSetLeft_Click(object sender, EventArgs e)
        {
            programmer.SetLeftDegrees((int)udLeft.Value);
        }

        /// <summary>
        /// Set right position
        /// </summary>
        private void cmdSetRight_Click(object sender, EventArgs e)
        {
            programmer.SetRightDegrees((int)udRight.Value);
        }

        /// <summary>
        /// Update target
        /// </summary>
        private void turnoutSelection_TurnoutChanged(object sender, EventArgs e)
        {
            programmer.Turnout = turnoutSelection.Turnout;
            programmer.SetTarget();
        }

        /// <summary>
        /// Set turnout speed
        /// </summary>
        private void cmdSetSpeed_Click(object sender, EventArgs e)
        {
            programmer.SetSpeed((int)udSpeed.Value);
        }

        private void cmdSetRelay_Click(object sender, EventArgs e)
        {
            programmer.SetRelaisPosition(cbLeftLSB.Checked);
        }
    }
}
