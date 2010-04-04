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
            this.lbPort = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.NumericUpDown();
            this.rbInput = new System.Windows.Forms.RadioButton();
            this.rbOutput = new System.Windows.Forms.RadioButton();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.tbValue1 = new System.Windows.Forms.TextBox();
            this.tbValue2 = new System.Windows.Forms.TextBox();
            this.inputControl = new LocoNetToolBox.WinApp.Controls.LocoIOPinInputConfigControl();
            this.outputControl = new LocoNetToolBox.WinApp.Controls.LocoIOPinOutputConfigControl();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 9;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpMain.Controls.Add(this.lbPort, 0, 0);
            this.tlpMain.Controls.Add(this.tbAddress, 1, 0);
            this.tlpMain.Controls.Add(this.rbInput, 2, 0);
            this.tlpMain.Controls.Add(this.rbOutput, 3, 0);
            this.tlpMain.Controls.Add(this.inputControl, 4, 0);
            this.tlpMain.Controls.Add(this.outputControl, 5, 0);
            this.tlpMain.Controls.Add(this.tbConfig, 6, 0);
            this.tlpMain.Controls.Add(this.tbValue1, 7, 0);
            this.tlpMain.Controls.Add(this.tbValue2, 8, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.Size = new System.Drawing.Size(681, 27);
            this.tlpMain.TabIndex = 0;
            // 
            // lbPort
            // 
            this.lbPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(3, 7);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(19, 13);
            this.lbPort.TabIndex = 4;
            this.lbPort.Text = "99";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(35, 3);
            this.tbAddress.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(64, 20);
            this.tbAddress.TabIndex = 6;
            this.tbAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbAddress.ValueChanged += new System.EventHandler(this.tbAddress_ValueChanged);
            // 
            // rbInput
            // 
            this.rbInput.AutoSize = true;
            this.rbInput.Location = new System.Drawing.Point(105, 3);
            this.rbInput.Name = "rbInput";
            this.rbInput.Size = new System.Drawing.Size(49, 17);
            this.rbInput.TabIndex = 0;
            this.rbInput.TabStop = true;
            this.rbInput.Text = "Input";
            this.rbInput.UseVisualStyleBackColor = true;
            this.rbInput.CheckedChanged += new System.EventHandler(this.rbInput_CheckedChanged);
            // 
            // rbOutput
            // 
            this.rbOutput.AutoSize = true;
            this.rbOutput.Location = new System.Drawing.Point(160, 3);
            this.rbOutput.Name = "rbOutput";
            this.rbOutput.Size = new System.Drawing.Size(57, 17);
            this.rbOutput.TabIndex = 1;
            this.rbOutput.TabStop = true;
            this.rbOutput.Text = "Output";
            this.rbOutput.UseVisualStyleBackColor = true;
            this.rbOutput.CheckedChanged += new System.EventHandler(this.rbOutput_CheckedChanged);
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
            // inputControl
            // 
            this.inputControl.AutoSize = true;
            this.inputControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputControl.Location = new System.Drawing.Point(223, 3);
            this.inputControl.Mode = null;
            this.inputControl.Name = "inputControl";
            this.inputControl.Size = new System.Drawing.Size(176, 21);
            this.inputControl.TabIndex = 7;
            this.inputControl.Changed += new System.EventHandler(this.OnConfigChanged);
            // 
            // outputControl
            // 
            this.outputControl.AutoSize = true;
            this.outputControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputControl.Location = new System.Drawing.Point(405, 3);
            this.outputControl.Mode = null;
            this.outputControl.Name = "outputControl";
            this.outputControl.Size = new System.Drawing.Size(176, 21);
            this.outputControl.TabIndex = 12;
            this.outputControl.Changed += new System.EventHandler(this.OnConfigChanged);
            // 
            // LocoIOPortConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoIOPortConfigurationControl";
            this.Size = new System.Drawing.Size(681, 200);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.RadioButton rbInput;
        private System.Windows.Forms.RadioButton rbOutput;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.NumericUpDown tbAddress;
        private LocoIOPinInputConfigControl inputControl;
        private LocoIOPinOutputConfigControl outputControl;
        private System.Windows.Forms.TextBox tbValue2;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.TextBox tbValue1;
    }
}
