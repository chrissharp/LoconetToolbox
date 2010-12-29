/*
Loconet toolbox
Copyright (C) 2010 Modelspoorgroep Venlo, Ewout Prangsma

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
using System;
using System.Windows.Forms;
using LocoNetToolBox.Protocol;
using LocoNetToolBox.WinApp.Preferences;

namespace LocoNetToolBox.WinApp
{
    public partial class MainForm : Form
    {
        private readonly AppState state;

        /// <summary>
        /// Default ctor
        /// </summary>
        public MainForm()
        {
            state = new AppState(this);
            InitializeComponent();
            lbVersion.Text = string.Format("Version: {0}", GetType().Assembly.GetName().Version);
            state.SetLocoBuffer(new SerialPortLocoBuffer());

            locoBufferView1.AppState = state;
            commandControl1.AppState = state;
            locoIOList1.AppState = state;
            locoNetMonitor.AppState = state;
        }

        /// <summary>
        /// Load time initialization
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var prefs = UserPreferences.Preferences;
            var path = prefs.LocoNetConfigurationPath;
            if (!string.IsNullOrEmpty(path))
            {
                state.OpenConfiguration(path);
            }
        }

        /// <summary>
        /// Close locobuffer on form close
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!state.SaveConfigurationIfDirty())
            {
                e.Cancel = true;
                return;
            }
            state.Dispose();
            base.OnFormClosing(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustSizes();
        }

        /// <summary>
        /// Locobuffer has changed.
        /// </summary>
        private void LocoBufferView1LocoBufferChanged(object sender, EventArgs e)
        {
            state.SetLocoBuffer(locoBufferView1.ConfiguredLocoBuffer);
        }

        /// <summary>
        /// Fix size of controls
        /// </summary>
        private void AdjustSizes()
        {
            var height = Math.Max(locoBufferView1.Height, commandControl1.Height);
            locoIOList1.Height = height;
        }

        /// <summary>
        /// Open a new configuration.
        /// </summary>
        private void miOpen_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Open loconet configuration";
                dialog.DefaultExt = Constants.LocoNetConfigurationExt;
                dialog.Filter = Constants.LocoNetConfigurationFilter;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    state.OpenConfiguration(dialog.FileName);
                }
            }
        }

        /// <summary>
        /// Save configuration now.
        /// </summary>
        private void miSave_Click(object sender, EventArgs e)
        {
            state.SaveConfiguration();
        }

        /// <summary>
        /// Save configuration using different filename
        /// </summary>
        private void miSaveAs_Click(object sender, EventArgs e)
        {
            state.SaveConfigurationAs();
        }
    }
}
