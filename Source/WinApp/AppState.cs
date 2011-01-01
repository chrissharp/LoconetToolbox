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
        public event EventHandler LocoNetChanged;
        public event EventHandler PathChanged;

        private readonly Control ui;
        private LocoNet locoNet;
        private AsyncLocoBuffer asyncLb;
        private SyncLocoNetState syncLnState;

        /// <summary>
        /// Default ctor
        /// </summary>
        internal AppState(Control ui)
        {
            this.ui = ui;
        }

        /// <summary>
        /// Gets the current network
        /// </summary>
        internal LocoNet LocoNet { get { return locoNet; } }

        /// <summary>
        /// Gets the current configuration.
        /// </summary>
        internal LocoNetConfiguration Configuration { get { return (locoNet != null) ? locoNet.Configuration : null; } }

        /// <summary>
        /// Gets the synchronous locobuffer
        /// </summary>
        internal LocoBuffer ConfiguredLocoBuffer { get { return (locoNet != null) ? locoNet.LocoBuffer : null; } }

        /// <summary>
        /// Gets the locobuffer communicator
        /// </summary>
        internal AsyncLocoBuffer LocoBuffer { get { return asyncLb; } }

        /// <summary>
        /// Gets the active state
        /// </summary>
        internal ILocoNetState LocoNetState { get { return syncLnState; } }

        /// <summary>
        /// Pass the given locobuffer on to all components.
        /// </summary>
        internal void Setup(LocoBuffer lb, LocoNetConfiguration configuration)
        {
            // Allow for null arguments
            lb = lb ?? ConfiguredLocoBuffer;
            configuration = configuration ?? Configuration;

            if ((ConfiguredLocoBuffer != lb) || (Configuration != configuration))
            {
                CloseLocoBuffer();
                locoNet = new LocoNet(lb, configuration);
                asyncLb = new AsyncLocoBuffer(ui, lb);
                var asyncLnState = new LocoNetState(lb);
                syncLnState = new SyncLocoNetState(ui, asyncLnState);
                LocoNetChanged.Fire(this);
            }
        }

        /// <summary>
        /// Close any active locobuffer connection
        /// </summary>
        private void CloseLocoBuffer()
        {
            if (locoNet == null)
                return;

            if (asyncLb != null)
            {
                asyncLb.Dispose();
                asyncLb = null;
            }
            if (syncLnState != null)
            {
                syncLnState.Dispose();
                syncLnState = null;
            }
            if (locoNet != null)
            {
                locoNet.Dispose();
                locoNet = null;
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
                    Setup(null, tmp);
                    UserPreferences.Preferences.LocoNetConfigurationPath = path;
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
            var configuration = Configuration;
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
            var configuration = Configuration;
            if (configuration == null)
                return true;

            if (string.IsNullOrEmpty(configuration.Path))
            {
                return SaveConfigurationAs();
            }
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
            var configuration = Configuration;
            if (configuration == null)
                return true;

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
