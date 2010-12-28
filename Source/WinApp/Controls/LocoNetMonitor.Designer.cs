namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoNetMonitor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAddressMonitor = new System.Windows.Forms.TabPage();
            this.tabPageTrafficMonitor = new System.Windows.Forms.TabPage();
            this.lbInputs = new LocoNetToolBox.WinApp.Controls.InputStateView();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tabPageAddressMonitor.SuspendLayout();
            this.tabPageTrafficMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageAddressMonitor);
            this.tabControl.Controls.Add(this.tabPageTrafficMonitor);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(720, 466);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageAddressMonitor
            // 
            this.tabPageAddressMonitor.Controls.Add(this.lbInputs);
            this.tabPageAddressMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddressMonitor.Name = "tabPageAddressMonitor";
            this.tabPageAddressMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddressMonitor.Size = new System.Drawing.Size(712, 440);
            this.tabPageAddressMonitor.TabIndex = 0;
            this.tabPageAddressMonitor.Text = "Address monitor";
            this.tabPageAddressMonitor.UseVisualStyleBackColor = true;
            // 
            // tabPageTrafficMonitor
            // 
            this.tabPageTrafficMonitor.Controls.Add(this.lbLog);
            this.tabPageTrafficMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrafficMonitor.Name = "tabPageTrafficMonitor";
            this.tabPageTrafficMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrafficMonitor.Size = new System.Drawing.Size(712, 440);
            this.tabPageTrafficMonitor.TabIndex = 1;
            this.tabPageTrafficMonitor.Text = "Traffic monitor";
            this.tabPageTrafficMonitor.UseVisualStyleBackColor = true;
            // 
            // lbInputs
            // 
            this.lbInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInputs.Location = new System.Drawing.Point(3, 3);
            this.lbInputs.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lbInputs.Name = "lbInputs";
            this.lbInputs.Size = new System.Drawing.Size(706, 434);
            this.lbInputs.TabIndex = 4;
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.Location = new System.Drawing.Point(3, 3);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(706, 433);
            this.lbLog.TabIndex = 3;
            // 
            // LocoNetMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "LocoNetMonitor";
            this.Size = new System.Drawing.Size(720, 466);
            this.tabControl.ResumeLayout(false);
            this.tabPageAddressMonitor.ResumeLayout(false);
            this.tabPageTrafficMonitor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAddressMonitor;
        private InputStateView lbInputs;
        private System.Windows.Forms.TabPage tabPageTrafficMonitor;
        private System.Windows.Forms.ListBox lbLog;

    }
}
