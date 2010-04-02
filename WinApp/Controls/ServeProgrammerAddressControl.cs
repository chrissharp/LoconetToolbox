using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class ServeProgrammerAddressControl : UserControl
    {
        /// <summary>
        /// On of the address settings has changed.
        /// </summary>
        public event EventHandler AddressChanged;

        /// <summary>
        /// Default ctor
        /// </summary>
        public ServeProgrammerAddressControl()
        {
            InitializeComponent();
        }

        public int Address1 { get { return (int)udAddress1.Value; } }
        public int Address2 { get { return (int)udAddress2.Value; } }
        public int Address3 { get { return (int)udAddress3.Value; } }
        public int Address4 { get { return (int)udAddress4.Value; } }


        private void udAddress1_ValueChanged(object sender, EventArgs e)
        {
            udAddress2.Value = udAddress1.Value + 1;
            if (AddressChanged != null) { AddressChanged(this, EventArgs.Empty); }
        }

        private void udAddress2_ValueChanged(object sender, EventArgs e)
        {
            udAddress3.Value = udAddress2.Value + 1;
            if (AddressChanged != null) { AddressChanged(this, EventArgs.Empty); }
        }

        private void udAddress3_ValueChanged(object sender, EventArgs e)
        {
            udAddress4.Value = udAddress3.Value + 1;
            if (AddressChanged != null) { AddressChanged(this, EventArgs.Empty); }
        }

        private void udAddress4_ValueChanged(object sender, EventArgs e)
        {
            if (AddressChanged != null) { AddressChanged(this, EventArgs.Empty); }
        }
    }
}
