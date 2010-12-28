namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIODebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.configControl = new LocoNetToolBox.WinApp.Controls.LocoIOPinConfigurationControl();
            this.SuspendLayout();
            // 
            // configControl
            // 
            this.configControl.AutoSize = true;
            this.configControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.configControl.Location = new System.Drawing.Point(0, 0);
            this.configControl.Name = "configControl";
            this.configControl.Size = new System.Drawing.Size(712, 102);
            this.configControl.TabIndex = 0;
            // 
            // LocoIOPortDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 182);
            this.Controls.Add(this.configControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocoIOPortDebugForm";
            this.Text = "Loco IO Port Debug Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocoIOPinConfigurationControl configControl;
    }
}