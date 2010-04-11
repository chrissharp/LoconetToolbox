namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIOConfigurationControl
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
            this.connector1 = new LocoNetToolBox.WinApp.Controls.LocoIOConnectorConfigurationControl();
            this.connector2 = new LocoNetToolBox.WinApp.Controls.LocoIOConnectorConfigurationControl();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.connector1, 0, 0);
            this.tlpMain.Controls.Add(this.connector2, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(829, 290);
            this.tlpMain.TabIndex = 0;
            // 
            // connector1
            // 
            this.connector1.Advanced = false;
            this.connector1.AutoSize = true;
            this.connector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.connector1.Location = new System.Drawing.Point(3, 3);
            this.connector1.Name = "connector1";
            this.connector1.Size = new System.Drawing.Size(408, 284);
            this.connector1.TabIndex = 0;
            // 
            // connector2
            // 
            this.connector2.Advanced = false;
            this.connector2.AutoSize = true;
            this.connector2.Dock = System.Windows.Forms.DockStyle.Top;
            this.connector2.Location = new System.Drawing.Point(417, 3);
            this.connector2.Name = "connector2";
            this.connector2.Size = new System.Drawing.Size(409, 284);
            this.connector2.TabIndex = 1;
            // 
            // LocoIOConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoIOConfigurationControl";
            this.Size = new System.Drawing.Size(829, 359);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private LocoIOConnectorConfigurationControl connector1;
        private LocoIOConnectorConfigurationControl connector2;

    }
}
