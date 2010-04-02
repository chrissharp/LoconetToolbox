using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOConfigurationControl : UserControl
    {
        private readonly LocoIOPortConfigurationControl[] portControls;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConfigurationControl()
        {
            InitializeComponent();
            this.portControls = new LocoIOPortConfigurationControl[] {
                cfgPort1, cfgPort2, cfgPort3, cfgPort4, cfgPort5, cfgPort6, cfgPort7, cfgPort8, 
                cfgPort9, cfgPort10, cfgPort11, cfgPort12, cfgPort13, cfgPort14, cfgPort15, cfgPort16
            };
            foreach (var ctr in portControls)
            {
                ctr.Enabled = true;
            }
        }

        /// <summary>
        /// Read all settings
        /// </summary>
        internal void ReadAll(LocoBuffer lb, LocoNetAddress address)
        {
            foreach (var ctr in portControls)
            {
                ctr.ReadAll(lb, address);
            }
        }
    }
}
