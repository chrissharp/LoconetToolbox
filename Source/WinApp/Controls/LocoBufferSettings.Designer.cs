namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoBufferSettings
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
            this.serialPortSettings = new LocoNetToolBox.WinApp.Controls.SerialPortLocoBufferSettings();
            this.rbSerialPort = new System.Windows.Forms.RadioButton();
            this.rbTcp = new System.Windows.Forms.RadioButton();
            this.tcpSettings = new LocoNetToolBox.WinApp.Controls.TcpLocoBufferSettings();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.serialPortSettings, 0, 1);
            this.tlpMain.Controls.Add(this.rbSerialPort, 0, 0);
            this.tlpMain.Controls.Add(this.rbTcp, 1, 0);
            this.tlpMain.Controls.Add(this.tcpSettings, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(299, 160);
            this.tlpMain.TabIndex = 0;
            // 
            // serialPortSettings
            // 
            this.serialPortSettings.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.serialPortSettings, 2);
            this.serialPortSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.serialPortSettings.Location = new System.Drawing.Point(3, 26);
            this.serialPortSettings.Name = "serialPortSettings";
            this.serialPortSettings.Size = new System.Drawing.Size(293, 73);
            this.serialPortSettings.TabIndex = 0;
            // 
            // rbSerialPort
            // 
            this.rbSerialPort.AutoSize = true;
            this.rbSerialPort.Checked = true;
            this.rbSerialPort.Location = new System.Drawing.Point(3, 3);
            this.rbSerialPort.Name = "rbSerialPort";
            this.rbSerialPort.Size = new System.Drawing.Size(72, 17);
            this.rbSerialPort.TabIndex = 1;
            this.rbSerialPort.TabStop = true;
            this.rbSerialPort.Text = "Serial port";
            this.rbSerialPort.UseVisualStyleBackColor = true;
            this.rbSerialPort.CheckedChanged += new System.EventHandler(this.OnChangeLocoBufferType);
            // 
            // rbTcp
            // 
            this.rbTcp.AutoSize = true;
            this.rbTcp.Location = new System.Drawing.Point(81, 3);
            this.rbTcp.Name = "rbTcp";
            this.rbTcp.Size = new System.Drawing.Size(97, 17);
            this.rbTcp.TabIndex = 2;
            this.rbTcp.TabStop = true;
            this.rbTcp.Text = "TCP (MGV101)";
            this.rbTcp.UseVisualStyleBackColor = true;
            this.rbTcp.CheckedChanged += new System.EventHandler(this.OnChangeLocoBufferType);
            // 
            // tcpSettings
            // 
            this.tcpSettings.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.tcpSettings, 2);
            this.tcpSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcpSettings.Location = new System.Drawing.Point(3, 105);
            this.tcpSettings.Name = "tcpSettings";
            this.tcpSettings.Size = new System.Drawing.Size(293, 52);
            this.tcpSettings.TabIndex = 3;
            // 
            // LocoBufferSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoBufferSettings";
            this.Size = new System.Drawing.Size(299, 193);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private SerialPortLocoBufferSettings serialPortSettings;
        private System.Windows.Forms.RadioButton rbSerialPort;
        private System.Windows.Forms.RadioButton rbTcp;
        private TcpLocoBufferSettings tcpSettings;

    }
}
