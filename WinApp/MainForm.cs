using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp
{
    public partial class MainForm : Form
    {
        private readonly LocoBuffer lb;

        /// <summary>
        /// Default ctor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this.lb = new LocoBuffer();
            locoBufferView1.LocoBuffer = lb;
            commandControl1.LocoBuffer = lb;
            locoIOList1.LocoBuffer = lb;
        }

        /// <summary>
        /// Close locobuffer on form close
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            lb.Close();
            base.OnFormClosing(e);
        }
    }
}
