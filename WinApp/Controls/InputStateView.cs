using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class InputStateView : UserControl
    {
        private readonly Dictionary<int, InputItem> items = new Dictionary<int, InputItem>();

        /// <summary>
        /// Default ctor
        /// </summary>
        public InputStateView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Process the given response.
        /// </summary>
        internal void ProcessResponse(Response value)
        {
            var inpRep = value as InputReport;
            var swRep = value as SwitchReport;
            if (inpRep != null)
            {
                var item = GetItem(inpRep.Address);
            }
            else if (swRep != null)
            {
                var item = GetItem(swRep.Address);
                item.SubItems[1].Text = string.Format("dir:{0} out:{1}",
                    swRep.Direction ? "on " : "off",
                    swRep.Output ? "on " : "off");
            }
        }

        /// <summary>
        /// Gets or creates an item for the given address.
        /// </summary>
        private InputItem GetItem(int address)
        {
            InputItem item;
            if (!items.TryGetValue(address, out item))
            {
                item = new InputItem(address);
                items.Add(address, item);

                lvInputs.BeginUpdate();
                lvInputs.Items.Clear();
                lvInputs.Items.AddRange(items.Values.ToArray());
                lvInputs.EndUpdate();
            }
            return item;
        }

        /// <summary>
        /// Input for a specific address
        /// </summary>
        private class InputItem : ListViewItem
        {
            private readonly int address;

            /// <summary>
            /// Default ctor
            /// </summary>
            internal InputItem(int address) : base(address.ToString())
            {
                this.address = address;
                this.SubItems.Add(string.Empty);
            }
        }
    }
}
