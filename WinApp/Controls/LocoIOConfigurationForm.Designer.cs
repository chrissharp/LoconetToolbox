namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIOConfigurationForm
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmdWriteAll = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdReadAll = new System.Windows.Forms.Button();
            this.readWorker = new System.ComponentModel.BackgroundWorker();
            this.configurationControl = new LocoNetToolBox.WinApp.Controls.LocoIOConfigurationControl();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.cmdWriteAll, 1, 1);
            this.tlpMain.Controls.Add(this.configurationControl, 0, 0);
            this.tlpMain.Controls.Add(this.cmdClose, 3, 1);
            this.tlpMain.Controls.Add(this.cmdReadAll, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(631, 345);
            this.tlpMain.TabIndex = 0;
            // 
            // cmdWriteAll
            // 
            this.cmdWriteAll.Location = new System.Drawing.Point(102, 317);
            this.cmdWriteAll.Name = "cmdWriteAll";
            this.cmdWriteAll.Size = new System.Drawing.Size(93, 25);
            this.cmdWriteAll.TabIndex = 2;
            this.cmdWriteAll.Text = "&Write all";
            this.cmdWriteAll.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(535, 317);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(93, 25);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdCloseClick);
            // 
            // cmdReadAll
            // 
            this.cmdReadAll.Location = new System.Drawing.Point(3, 317);
            this.cmdReadAll.Name = "cmdReadAll";
            this.cmdReadAll.Size = new System.Drawing.Size(93, 25);
            this.cmdReadAll.TabIndex = 4;
            this.cmdReadAll.Text = "&Read all";
            this.cmdReadAll.UseVisualStyleBackColor = true;
            // 
            // readWorker
            // 
            this.readWorker.WorkerSupportsCancellation = true;
            // 
            // configurationControl
            // 
            this.tlpMain.SetColumnSpan(this.configurationControl, 4);
            this.configurationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationControl.Location = new System.Drawing.Point(3, 3);
            this.configurationControl.Name = "configurationControl";
            this.configurationControl.Size = new System.Drawing.Size(625, 308);
            this.configurationControl.TabIndex = 0;
            this.configurationControl.BusyChanged += new System.EventHandler(this.ConfigurationControlBusyChanged);
            // 
            // LocoIOConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 345);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocoIOConfigurationForm";
            this.Text = "MGV50 Configuration";
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private LocoIOConfigurationControl configurationControl;
        private System.Windows.Forms.Button cmdWriteAll;
        private System.Windows.Forms.Button cmdClose;
        private System.ComponentModel.BackgroundWorker readWorker;
        private System.Windows.Forms.Button cmdReadAll;

    }
}