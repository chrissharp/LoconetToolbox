namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoBufferView
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.locoBufferSettings = new LocoNetToolBox.WinApp.Controls.LocoBufferSettings();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.lbInputs = new LocoNetToolBox.WinApp.Controls.InputStateView();
            this.lbTraffic = new System.Windows.Forms.Label();
            this.lvFeedbacks = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lbHeader, 0, 0);
            this.tlpMain.Controls.Add(this.locoBufferSettings, 0, 1);
            this.tlpMain.Controls.Add(this.lbLog, 0, 5);
            this.tlpMain.Controls.Add(this.lbInputs, 0, 3);
            this.tlpMain.Controls.Add(this.lbTraffic, 0, 4);
            this.tlpMain.Controls.Add(this.lvFeedbacks, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(396, 312);
            this.tlpMain.TabIndex = 0;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Location = new System.Drawing.Point(3, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(59, 13);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "LocoBuffer";
            // 
            // locoBufferSettings
            // 
            this.locoBufferSettings.AutoSize = true;
            this.locoBufferSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.locoBufferSettings.Location = new System.Drawing.Point(3, 16);
            this.locoBufferSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.locoBufferSettings.Name = "locoBufferSettings";
            this.locoBufferSettings.Size = new System.Drawing.Size(390, 73);
            this.locoBufferSettings.TabIndex = 1;
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(3, 226);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(390, 82);
            this.lbLog.TabIndex = 2;
            // 
            // lbInputs
            // 
            this.lbInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInputs.Location = new System.Drawing.Point(3, 125);
            this.lbInputs.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lbInputs.Name = "lbInputs";
            this.lbInputs.Size = new System.Drawing.Size(390, 65);
            this.lbInputs.TabIndex = 3;
            // 
            // lbTraffic
            // 
            this.lbTraffic.AutoSize = true;
            this.lbTraffic.Location = new System.Drawing.Point(3, 210);
            this.lbTraffic.Name = "lbTraffic";
            this.lbTraffic.Size = new System.Drawing.Size(134, 13);
            this.lbTraffic.TabIndex = 4;
            this.lbTraffic.Text = "LocoNet traffic (advanced)";
            // 
            // lvFeedbacks
            // 
            this.lvFeedbacks.AutoSize = true;
            this.lvFeedbacks.Location = new System.Drawing.Point(3, 109);
            this.lvFeedbacks.Name = "lvFeedbacks";
            this.lvFeedbacks.Size = new System.Drawing.Size(140, 13);
            this.lvFeedbacks.TabIndex = 5;
            this.lvFeedbacks.Text = "LocoNet Address Feedback";
            // 
            // LocoBufferView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoBufferView";
            this.Size = new System.Drawing.Size(396, 312);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbHeader;
        private LocoBufferSettings locoBufferSettings;
        private System.Windows.Forms.ListBox lbLog;
        private InputStateView lbInputs;
        private System.Windows.Forms.Label lbTraffic;
        private System.Windows.Forms.Label lvFeedbacks;
    }
}
