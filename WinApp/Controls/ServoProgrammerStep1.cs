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
    public partial class ServoProgrammerStep1 : UserControl
    {
        public event EventHandler Continue;

        private Devices.MgvServo.ServoProgrammer programmer;

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServoProgrammerStep1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        internal void Initialize(Devices.MgvServo.ServoProgrammer programmer)
        {
            this.programmer = programmer;
            address_AddressChanged(null, null);
        }

        /// <summary>
        /// Address settings have changed.
        /// </summary>
        private void address_AddressChanged(object sender, EventArgs e)
        {
            programmer.Address1 = address.Address1 - 1;
            programmer.Address2 = address.Address2 - 1;
            programmer.Address3 = address.Address3 - 1;
            programmer.Address4 = address.Address4 - 1;
        }

        /// <summary>
        /// Set all bits to 0.
        /// </summary>
        private void cmdReset_Click(object sender, EventArgs e)
        {
            programmer.BitsToZero();
            if (Continue != null)
            {
                Continue(this, EventArgs.Empty);
            }
        }
    }
}
