using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class ServoTester : Form
    {
        private readonly Action<Request> execute;

        /// <summary>
        /// Designer ctor
        /// </summary>
        public ServoTester() : this(null)
        {
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServoTester(Action<Request> execute)
        {
            this.execute = execute;
            InitializeComponent();
        }

        /// <summary>
        /// Go left.
        /// </summary>
        private void cmdLeft_Click(object sender, EventArgs e)
        {
            execute(new SwitchRequest()
            {
                Address = (int)udAddress.Value - 1,
                Direction = true,
                Output = true
            });
        }

        /// <summary>
        /// Go right
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            execute(new SwitchRequest()
            {
                Address = (int)udAddress.Value - 1,
                Direction = false,
                Output = true
            });
        }
    }
}
