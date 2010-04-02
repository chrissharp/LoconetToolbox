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
    public partial class LocoIOPortConfigurationControl : UserControl
    {
        private bool initialized = false;
        private int port = 1;
        private readonly PortConfig config = new PortConfig();

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOPortConfigurationControl()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Gets the port number (1-16)
        /// </summary>
        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                lbPort.Text = value.ToString();
            }
        }

        /// <summary>
        /// Read all settings
        /// </summary>
        internal void ReadAll(LocoBuffer lb, LocoNetAddress address)
        {

        }

        /// <summary>
        /// Update the visibility of the UI components.
        /// </summary>
        private void UpdateUI()
        {
            if (initialized)
            {
                inputControl.Visible = (config.Direction == PortConfig.Directions.Input);
                outputControl.Visible = (config.Direction == PortConfig.Directions.Output);
                tbConfig.Text = config.Config.ToString();
                tbValue1.Text = config.Value1.ToString();
                tbValue2.Text = config.Value2.ToString();
            }
        }

        /// <summary>
        /// Select input.
        /// </summary>
        private void rbInput_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInput.Checked) { config.Direction = PortConfig.Directions.Input; }
            UpdateUI();
        }

        /// <summary>
        /// Select output
        /// </summary>
        private void rbOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOutput.Checked) { config.Direction = PortConfig.Directions.Output; }
            UpdateUI();
        }

        /// <summary>
        /// Store address.
        /// </summary>
        private void tbAddress_ValueChanged(object sender, EventArgs e)
        {
            config.Address = (int)tbAddress.Value;
            UpdateUI();
        }

        /// <summary>
        /// Input settings have changed.
        /// </summary>
        private void OnConfigChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Put port config in controls
        /// </summary>
        private void Initialize()
        {
            initialized = false;
            try
            {
                inputControl.Initialize(config);
                outputControl.Initialize(config);
                rbInput.Checked = config.Direction == PortConfig.Directions.Input;
                rbOutput.Checked = config.Direction == PortConfig.Directions.Output;
                tbAddress.Value = config.Address;
            }
            finally
            {
                initialized = true;
                UpdateUI();
            }
        }

        private void tbConfig_Validated(object sender, EventArgs e)
        {
            byte value;
            if (byte.TryParse(tbConfig.Text.Trim(), out value))
            {
                config.Config = value;
                Initialize();
            }
        }

        private void tbValue1_Validated(object sender, EventArgs e)
        {
            byte value;
            if (byte.TryParse(tbValue1.Text.Trim(), out value))
            {
                config.Value1 = value;
                Initialize();
            }
        }

        private void tbValue2_Validated(object sender, EventArgs e)
        {
            byte value;
            if (byte.TryParse(tbValue2.Text.Trim(), out value))
            {
                config.Value2 = value;
                Initialize();
            }
        }
    }
}
