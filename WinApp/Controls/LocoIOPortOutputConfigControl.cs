using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Devices.LocoIO;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOPortOutputConfigControl : UserControl
    {
        /// <summary>
        /// Fired when settings are changed.
        /// </summary>
        public event EventHandler Changed;
        private PortConfig config;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOPortOutputConfigControl()
        {
            InitializeComponent();
        }

        internal void Initialize(PortConfig config)
        {
            this.config = null;
            cbLowAtStartup.Checked = config.LowAtStartup;
            cbHWReset.Checked = config.HardwareReset;
            cbPulseContact.Checked = config.PulseContact;
            cbFlash.Checked = config.Flash;
            cbMulti.Checked = config.Multi;
            cbBlockDetector.Checked = config.BlockDetector;
            this.config = config;
        }

        /// <summary>
        /// Checkbox has changed.
        /// </summary>
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (config != null)
            {
                config.LowAtStartup = cbLowAtStartup.Checked;
                config.HardwareReset = cbHWReset.Checked;
                config.PulseContact = cbPulseContact.Checked;
                config.Flash = cbFlash.Checked;
                config.Multi = cbMulti.Checked;
                config.BlockDetector = cbBlockDetector.Checked;
                Changed.Fire(this);
            }
        }
    }
}
