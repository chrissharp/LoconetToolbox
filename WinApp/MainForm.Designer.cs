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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.locoBufferView1 = new LocoNetToolBox.WinApp.Controls.LocoBufferView();
            this.commandControl1 = new LocoNetToolBox.WinApp.Controls.CommandControl();
            this.locoIOList1 = new LocoNetToolBox.WinApp.Controls.LocoIOList();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.locoBufferView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.commandControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.locoIOList1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // locoBufferView1
            // 
            this.locoBufferView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locoBufferView1.Location = new System.Drawing.Point(3, 3);
            this.locoBufferView1.Name = "locoBufferView1";
            this.locoBufferView1.Size = new System.Drawing.Size(287, 431);
            this.locoBufferView1.TabIndex = 0;
            this.locoBufferView1.LocoBufferChanged += new System.EventHandler(this.LocoBufferView1LocoBufferChanged);
            // 
            // commandControl1
            // 
            this.commandControl1.AutoSize = true;
            this.commandControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandControl1.Location = new System.Drawing.Point(296, 3);
            this.commandControl1.Name = "commandControl1";
            this.commandControl1.Size = new System.Drawing.Size(144, 431);
            this.commandControl1.TabIndex = 1;
            // 
            // locoIOList1
            // 
            this.locoIOList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locoIOList1.Location = new System.Drawing.Point(446, 3);
            this.locoIOList1.Name = "locoIOList1";
            this.locoIOList1.Size = new System.Drawing.Size(288, 431);
            this.locoIOList1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MGV LocoNet ToolBox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LocoNetToolBox.WinApp.Controls.LocoBufferView locoBufferView1;
        private LocoNetToolBox.WinApp.Controls.CommandControl commandControl1;
        private LocoNetToolBox.WinApp.Controls.LocoIOList locoIOList1;
    }
}

