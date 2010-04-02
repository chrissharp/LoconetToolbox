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
    public partial class ServoProgrammerStep3 : UserControl
    {
        public event EventHandler Continue;

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServoProgrammerStep3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Go to next state
        /// </summary>
        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (Continue != null)
            {
                Continue(this, EventArgs.Empty);
            }
        }
    }
}
