﻿/*
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
    /// <summary>
    /// LocoIO Single port editor.
    /// </summary>
    public partial class LocoIOPinConfigurationControl : UserControl
    {
        private bool initialized = false;
        private PinConfig config;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOPinConfigurationControl()
        {
            InitializeComponent();
            initialized = true;
        }

        /// <summary>
        /// Connect this control to the given config.
        /// </summary>
        public void Connect(PinConfig config)
        {
            this.config = config;
            this.config.ModeChanged += (s, x) => this.PostOnGuiThread(UpdateFromConfig);
            this.config.AddressChanged += (s, x) => this.PostOnGuiThread(UpdateUI);
            UpdateFromConfig();
        }

        /// <summary>
        /// Update UI from config.
        /// </summary>
        public void UpdateFromConfig()
        {
            try
            {
                this.initialized = false;

                var mode = config.Mode;
                direction.IsInput = (mode != null) && mode.IsInput;
                direction.IsOutput = (mode != null) && mode.IsOutput;
                modeControl.Mode = mode;
            }
            finally
            {
                this.initialized = true;
                UpdateUI();
            }
        }

        /// <summary>
        /// Update the visibility of the UI components.
        /// </summary>
        private void UpdateUI()
        {
            if (initialized)
            {
                var addr = config.Address;
                var mode = config.Mode;
                tbConfig.Text = (mode != null) ? mode.GetConfig().ToString() : string.Empty;
                tbValue1.Text = (mode != null) ? mode.GetValue1(addr).ToString() : string.Empty;
                tbValue2.Text = (mode != null) ? mode.GetValue2(addr).ToString() : string.Empty;
            }
        }

        /// <summary>
        /// Store address.
        /// </summary>
        private void tbAddress_ValueChanged_(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Input settings have changed.
        /// </summary>
        private void OnConfigChanged(object sender, EventArgs e)
        {
            if ((config != null) && (initialized))
            {
                modeControl.Input = direction.IsInput;
                config.Mode = modeControl.Mode;
                UpdateUI();
            }
        }

        private void tbConfig_Validated(object sender, EventArgs e)
        {
            SetModeFromValues();
        }

        private void tbValue1_Validated(object sender, EventArgs e)
        {
            SetModeFromValues();
        }

        private void tbValue2_Validated(object sender, EventArgs e)
        {
            SetModeFromValues();
        }

        private void SetModeFromValues()
        {
            if ((this.config != null) && (initialized))
            {
                int config;
                int value1;
                int value2;

                if (int.TryParse(tbConfig.Text.Trim(), out config) &&
                    int.TryParse(tbValue1.Text.Trim(), out value1) &&
                    int.TryParse(tbValue2.Text.Trim(), out value2))
                {
                    this.config.Mode = PinMode.Find(config, value1, value2);
                }
            }
        }
    }
}