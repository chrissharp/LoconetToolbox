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
    public partial class ServoProgrammerStep2 : UserControl
    {
        public event EventHandler Continue;

        private Devices.MgvServo.ServoProgrammer programmer;

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServoProgrammerStep2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        internal void Initialize(Devices.MgvServo.ServoProgrammer programmer)
        {
            this.programmer = programmer;
        }

        /// <summary>
        /// Go into programming mode.
        /// </summary>
        private void cmdEnterProgramMode_Click(object sender, EventArgs e)
        {
            programmer.EnterProgrammingMode();
            if (Continue != null)
            {
                Continue(this, EventArgs.Empty);
            }
        }
    }
}
