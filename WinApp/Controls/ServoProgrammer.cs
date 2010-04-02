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
    public partial class ServoProgrammer : Form
    {
        private LocoBuffer lb;
        private readonly Devices.MgvServo.ServoProgrammer programmer;

        /// <summary>
        /// Default ctor
        /// </summary>
        [Obsolete("Designer only")]
        public ServoProgrammer()
            : this(null)
        {
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        internal ServoProgrammer(LocoBuffer lb)
        {
            this.lb = lb;
            this.programmer = new Devices.MgvServo.ServoProgrammer(lb);
            InitializeComponent();
            step1.Initialize(programmer);
        }

        /// <summary>
        /// Exit programmer mode on close.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            programmer.ExitProgrammingMode();
            base.OnFormClosing(e);
        }

        private void step1_Continue(object sender, EventArgs e)
        {
            this.SuspendLayout();
            step1.Visible = false;
            step2.Visible = true;
            step2.Initialize(programmer);
            lbStep.Text = "Step 2/4";
            this.ResumeLayout(true);
        }

        private void step2_Continue(object sender, EventArgs e)
        {
            this.SuspendLayout();
            step2.Visible = false;
            step3.Visible = true;
            lbStep.Text = "Step 3/4";
            this.ResumeLayout(true);
        }

        private void step3_Continue(object sender, EventArgs e)
        {
            this.SuspendLayout();
            step3.Visible = false;
            step4.Visible = true;
            step4.Initialize(programmer);
            lbStep.Text = "Step 4/4";
            this.ResumeLayout(true);
        }
    }
}
