using System;
using System.Windows.Forms;
using LocoNetToolBox.Configuration;
using LocoNetToolBox.Model;
using LocoNetToolBox.Protocol;
using LocoNetToolBox.WinApp.Communications;
using LocoNetToolBox.WinApp.Preferences;

namespace LocoNetToolBox.WinApp
{
    /// <summary>
    /// State of the application.
    /// </summary>
    internal sealed class AppState : IDisposable
    {
        public event EventHandler LocoBufferChanged;
        public event EventHandler PathChanged;

        private readonly Control ui;
        private LocoNetConfiguration configuration = new LocoNetConfiguration();
        private LocoBuffer lb;
        private AsyncLocoBuffer asyncLb;
        private LocoNetState lnState;

        /// <summary>
        /// Default ctor
        /// </summary>
        internal AppState(Control ui)
        {
            this.ui = ui;
        }

        /// <summary>
        /// Gets the current configuration.
        /// </summary>
        internal LocoNetConfiguration Configuration { get { return configuration; } }

        /// <summary>
        /// Gets the synchronous locobuffer
        /// </summary>
        internal LocoBuffer ConfiguredLocoBuffer { get { return lb; } }

        /// <summary>
        /// Gets the locobuffer communicator
        /// </summary>
        internal AsyncLocoBuffer LocoBuffer { get { return asyncLb; } }

        /// <summary>
        /// Gets the active state
        /// </summary>
        internal LocoNetState LocoNetState { get { return lnState; } }

        /// <summary>
        /// Pass the given locobuffer on to all components.
        /// </summary>
        internal void SetLocoBuffer(LocoBuffer lb)
        {
            if (this.lb != lb)
            {
                CloseLocoBuffer();
                this.lb = lb;
                asyncLb = new AsyncLocoBuffer(ui, lb);
                lnState = new LocoNetState(lb);
                LocoBufferChanged.Fire(this);
            }
        }

        /// <summary>
        /// Close any active locobuffer connection
        /// </summary>
        private void CloseLocoBuffer()
        {
            if (asyncLb != null)
            {
                asyncLb.Dispose();
                asyncLb = null;
            }
            if (lnState != null)
            {
                lnState.Dispose();
                lnState = null;
            }
            if (lb != null)
            {
                lb.Close();
                lb = null;
            }
        }

        /// <summary>
        /// Open a configuration from the given path.
        /// </summary>
        internal void OpenConfiguration(string path)
        {
            try
            {
                // Open
                var tmp = LocoNetConfiguration.Load(path);

                // Can we close?
                if (SaveConfigurationIfDirty())
                {
                    configuration = tmp;
                    UserPreferences.Preferences.LocoNetConfigurationPath = configuration.Path;
                    UserPreferences.SaveNow();
                    PathChanged.Fire(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Save the current configuration if it is dirty.
        /// </summary>
        /// <returns>True if it is save to overwrite the current configuration.</returns>
        internal bool SaveConfigurationIfDirty()
        {
            if ((configuration == null) || (!configuration.Dirty))
                return true;

            // Save configuration
            switch (MessageBox.Show("Save the loconet configuration now?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    return SaveConfiguration();
                case DialogResult.No:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Save the current configuration.
        /// </summary>
        internal bool SaveConfiguration()
        {
            if (string.IsNullOrEmpty(configuration.Path))
                return SaveConfigurationAs();
            try
            {
                configuration.Save(configuration.Path);
                UserPreferences.Preferences.LocoNetConfigurationPath = configuration.Path;
                UserPreferences.SaveNow();
                PathChanged.Fire(this);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Save the current configuration.
        /// </summary>
        internal bool SaveConfigurationAs()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Save loconet configuration as";
                dialog.DefaultExt = Constants.LocoNetConfigurationExt;
                dialog.Filter = Constants.LocoNetConfigurationFilter;
                if (dialog.ShowDialog() != DialogResult.OK)
                    return false;
                configuration.Path = dialog.FileName;
            }
            return SaveConfiguration();
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        public void Dispose()
        {
            CloseLocoBuffer();
        }
    }
}
