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
    public partial class LocoIOPortInputConfigControl : UserControl
    {
        /// <summary>
        /// Fired when settings are changed.
        /// </summary>
        public event EventHandler Changed;

        private static readonly List<PortConfig.InputTypes> InputTypes = new List<PortConfig.InputTypes>() {
                                                                         PortConfig.InputTypes.None,
                                                                         PortConfig.InputTypes.Sensor,
                                                                         PortConfig.InputTypes.Button
                                                                     };
        private PortConfig config;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOPortInputConfigControl()
        {
            InitializeComponent();
        }

        internal void Initialize(PortConfig config)
        {
            this.config = null;
            cbActiveLow.Checked = config.ActiveLow;
            cbDelay.Checked = config.Delay;
            cbDirect.Checked = (config.InputMessage == PortConfig.InputMessages.Direct);
            cbInputType.SelectedIndex = InputTypes.IndexOf(config.InputType);
            this.config = config;
        }

        /// <summary>
        /// Checkbox has changed.
        /// </summary>
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (config != null)
            {
                config.ActiveLow = cbActiveLow.Checked;
                config.Delay = cbDelay.Checked;
                config.InputMessage = cbDirect.Checked ? PortConfig.InputMessages.Direct : PortConfig.InputMessages.Indirect;
                config.InputType = InputTypes[Math.Max(0, cbInputType.SelectedIndex)];
                Changed.Fire(this);
            }
        }
    }
}
