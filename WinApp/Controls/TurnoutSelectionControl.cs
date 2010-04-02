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
    public partial class TurnoutSelectionControl : UserControl
    {
        /// <summary>
        /// Turnlout selection has changed
        /// </summary>
        public event EventHandler TurnoutChanged;

        /// <summary>
        /// Default ctor
        /// </summary>
        public TurnoutSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the selected turnout (1,2,3,4)
        /// </summary>
        public int Turnout
        {
            get
            {
                if (rb1.Checked) { return 1; }
                if (rb2.Checked) { return 2; }
                if (rb3.Checked) { return 3; }
                if (rb4.Checked) { return 4; }
                return 1;
            }
        }

        /// <summary>
        /// Selection has changed.
        /// </summary>
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            // No need to do anything now.
            if (TurnoutChanged != null) { TurnoutChanged(this, EventArgs.Empty); }
        }
    }
}
