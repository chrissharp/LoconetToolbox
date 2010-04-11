namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIOPinConfigurationControl
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.modeControl = new LocoNetToolBox.WinApp.Controls.LocoIOPinModeControl();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.tbValue1 = new System.Windows.Forms.TextBox();
            this.tbValue2 = new System.Windows.Forms.TextBox();
            this.direction = new LocoNetToolBox.WinApp.Controls.DirectionControl();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 5;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpMain.Controls.Add(this.modeControl, 1, 0);
            this.tlpMain.Controls.Add(this.tbConfig, 2, 0);
            this.tlpMain.Controls.Add(this.tbValue1, 3, 0);
            this.tlpMain.Controls.Add(this.tbValue2, 4, 0);
            this.tlpMain.Controls.Add(this.direction, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(681, 27);
            this.tlpMain.TabIndex = 0;
            // 
            // modeControl
            // 
            this.modeControl.AutoSize = true;
            this.modeControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.modeControl.Location = new System.Drawing.Point(63, 3);
            this.modeControl.Mode = null;
            this.modeControl.Name = "modeControl";
            this.modeControl.Size = new System.Drawing.Size(518, 21);
            this.modeControl.TabIndex = 7;
            this.modeControl.Changed += new System.EventHandler(this.OnConfigChanged);
            // 
            // tbConfig
            // 
            this.tbConfig.Location = new System.Drawing.Point(587, 3);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(26, 20);
            this.tbConfig.TabIndex = 9;
            this.tbConfig.Validated += new System.EventHandler(this.tbConfig_Validated);
            // 
            // tbValue1
            // 
            this.tbValue1.Location = new System.Drawing.Point(619, 3);
            this.tbValue1.Name = "tbValue1";
            this.tbValue1.Size = new System.Drawing.Size(26, 20);
            this.tbValue1.TabIndex = 10;
            this.tbValue1.Validated += new System.EventHandler(this.tbValue1_Validated);
            // 
            // tbValue2
            // 
            this.tbValue2.Location = new System.Drawing.Point(651, 3);
            this.tbValue2.Name = "tbValue2";
            this.tbValue2.Size = new System.Drawing.Size(27, 20);
            this.tbValue2.TabIndex = 11;
            this.tbValue2.Validated += new System.EventHandler(this.tbValue2_Validated);
            // 
            // direction
            // 
            this.direction.Dock = System.Windows.Forms.DockStyle.Top;
            this.direction.IsInput = true;
            this.direction.IsOutput = false;
            this.direction.Location = new System.Drawing.Point(3, 3);
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(54, 21);
            this.direction.TabIndex = 12;
            this.direction.Changed += new System.EventHandler(this.OnConfigChanged);
            // 
            // LocoIOPinConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoIOPinConfigurationControl";
            this.Size = new System.Drawing.Size(681, 200);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private LocoIOPinModeControl modeControl;
        private System.Windows.Forms.TextBox tbValue2;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.TextBox tbValue1;
        private DirectionControl direction;
    }
}
