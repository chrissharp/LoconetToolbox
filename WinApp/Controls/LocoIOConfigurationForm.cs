using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoIOConfigurationForm : Form
    {
        private LocoBuffer lb;
        private LocoNetAddress address;

        /// <summary>
        /// Default ctor
        /// </summary>
        public LocoIOConfigurationForm()
        {
            InitializeComponent();
            cmdWriteAll.Enabled = false;
            cmdWriteChanges.Enabled = false;
        }

        /// <summary>
        /// Initialize for a specific module
        /// </summary>
        internal void Initialize(LocoBuffer lb, LocoNetAddress address)
        {
            this.lb = lb;
            this.address = address;
            if (lb != null)
            {
                readWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Read all settings.
        /// </summary>
        private void readWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            configurationControl.ReadAll(lb, address);
        }

        /// <summary>
        /// Enable now.
        /// </summary>
        private void readWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmdWriteAll.Enabled = true;
            cmdWriteChanges.Enabled = true;
        }
    }
}
