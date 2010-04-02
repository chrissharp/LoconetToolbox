using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.WinApp.Preferences;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoBufferSettings : UserControl
    {
        private Protocol.LocoBuffer locoBuffer;
        private bool initialized = false;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoBufferSettings()
        {
            InitializeComponent();

            // First ports
            var ports = SerialPort.GetPortNames();
            cbPort.Items.AddRange(ports);
            if (ports.Length > 0) { cbPort.SelectedIndex = 0; }
            rbRate57K.Checked = true;

            var port = UserPreferences.Preferences.PortName;
            if (ports.Contains(port))
            {
                cbPort.SelectedItem = port;
            }
            initialized = true;
        }

        /// <summary>
        /// Set data
        /// </summary>
        internal Protocol.LocoBuffer LocoBuffer
        {
            set
            {
                if (this.locoBuffer != null)
                {
                    this.locoBuffer.Closed -= new EventHandler(locoBuffer_Closed);
                    this.locoBuffer.Opened -= new EventHandler(locoBuffer_Opened);
                }
                this.locoBuffer = value;
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
                // Baudrate
                if (rbRate57K.Checked) { lb.BaudRate = LocoNetToolBox.Protocol.BaudRate.Rate57K; }
                else if (rbRate19K.Checked) { lb.BaudRate = LocoNetToolBox.Protocol.BaudRate.Rate19K; }
                // Port
                if (cbPort.SelectedIndex >= 0)
                {
                    lb.PortName = (string)cbPort.SelectedItem;
                }
            }
        }

        /// <summary>
        /// Baudrate changed
        /// </summary>
        private void rbRate_CheckedChanged(object sender, EventArgs e)
        {
            Save();
        }

        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save();
            if (initialized)
            {
                var port = (string)cbPort.SelectedItem;
                if (port != null)
                {
                    UserPreferences.Preferences.PortName = port;
                    UserPreferences.SaveNow();
                }
            }
        }
    }
}
