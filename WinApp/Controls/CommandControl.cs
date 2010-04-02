using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class CommandControl : UserControl
    {
        private LocoBuffer lb;

        /// <summary>
        /// Default ctor
        /// </summary>
        public CommandControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect to locobuffer
        /// </summary>
        internal LocoBuffer LocoBuffer { set { lb = value; } }

        /// <summary>
        /// Execute the given request.
        /// </summary>
        private void Execute(Request request)
        {
            try
            {
                request.Execute(lb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdGpOn_Click(object sender, EventArgs e)
        {
            Execute(new GlobalPowerOn());
        }

        private void cmdGpOff_Click(object sender, EventArgs e)
        {
            Execute(new GlobalPowerOff());
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            Execute(new PeerXferRequest1()
            {
                Command = PeerXferRequest.Commands.Read,
                DestinationLow = 0,
               // DestinationHigh = 0,
                SvAddress = 0
            });
        }

        /// <summary>
        /// Open the servo programmer
        /// </summary>
        private void cmdServoProgrammer_Click(object sender, EventArgs e)
        {
            var dialog = new ServoProgrammer(this.lb);
            dialog.Show();
        }

        private void cmdServoTester_Click(object sender, EventArgs e)
        {
            var dialog = new ServoTester(this.Execute);
            dialog.Show();
        }

        private void cmdAdvanced_Click(object sender, EventArgs e)
        {
            using (var dialog = new LocoIOPortDebugForm())
            {
                dialog.ShowDialog();
            }
        }
    }
}
