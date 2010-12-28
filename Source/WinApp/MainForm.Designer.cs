namespace LocoNetToolBox.WinApp
{
    partial class MainForm
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
            this.locoBufferView1 = new LocoNetToolBox.WinApp.Controls.LocoBufferView();
            this.commandControl1 = new LocoNetToolBox.WinApp.Controls.CommandControl();
            this.locoIOList1 = new LocoNetToolBox.WinApp.Controls.LocoIOList();
            this.locoNetMonitor = new LocoNetToolBox.WinApp.Controls.LocoNetMonitor();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.locoBufferView1, 0, 0);
            this.tlpMain.Controls.Add(this.commandControl1, 1, 0);
            this.tlpMain.Controls.Add(this.locoIOList1, 2, 0);
            this.tlpMain.Controls.Add(this.locoNetMonitor, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(737, 437);
            this.tlpMain.TabIndex = 0;
            // 
            // locoBufferView1
            // 
            this.locoBufferView1.AutoSize = true;
            this.locoBufferView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.locoBufferView1.Location = new System.Drawing.Point(3, 3);
            this.locoBufferView1.Name = "locoBufferView1";
            this.locoBufferView1.Size = new System.Drawing.Size(287, 106);
            this.locoBufferView1.TabIndex = 0;
            this.locoBufferView1.LocoBufferChanged += new System.EventHandler(this.LocoBufferView1LocoBufferChanged);
            // 
            // commandControl1
            // 
            this.commandControl1.AutoSize = true;
            this.commandControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandControl1.Location = new System.Drawing.Point(296, 3);
            this.commandControl1.Name = "commandControl1";
            this.commandControl1.Size = new System.Drawing.Size(144, 223);
            this.commandControl1.TabIndex = 1;
            // 
            // locoIOList1
            // 
            this.locoIOList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.locoIOList1.Location = new System.Drawing.Point(446, 3);
            this.locoIOList1.Name = "locoIOList1";
            this.locoIOList1.Size = new System.Drawing.Size(288, 331);
            this.locoIOList1.TabIndex = 2;
            // 
            // locoNetMonitor
            // 
            this.tlpMain.SetColumnSpan(this.locoNetMonitor, 3);
            this.locoNetMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locoNetMonitor.Location = new System.Drawing.Point(3, 340);
            this.locoNetMonitor.Name = "locoNetMonitor";
            this.locoNetMonitor.Size = new System.Drawing.Size(731, 94);
            this.locoNetMonitor.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 437);
            this.Controls.Add(this.tlpMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MGV LocoNet ToolBox";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private LocoNetToolBox.WinApp.Controls.LocoBufferView locoBufferView1;
        private LocoNetToolBox.WinApp.Controls.CommandControl commandControl1;
        private LocoNetToolBox.WinApp.Controls.LocoIOList locoIOList1;
        private LocoNetToolBox.WinApp.Controls.LocoNetMonitor locoNetMonitor;
    }
}

