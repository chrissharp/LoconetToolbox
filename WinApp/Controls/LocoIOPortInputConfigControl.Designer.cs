namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIOPortInputConfigControl
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
            this.cbActiveLow = new System.Windows.Forms.CheckBox();
            this.cbDelay = new System.Windows.Forms.CheckBox();
            this.cbDirect = new System.Windows.Forms.CheckBox();
            this.cbInputType = new System.Windows.Forms.ComboBox();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.cbActiveLow, 0, 0);
            this.tlpMain.Controls.Add(this.cbDelay, 0, 1);
            this.tlpMain.Controls.Add(this.cbDirect, 0, 2);
            this.tlpMain.Controls.Add(this.cbInputType, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.MinimumSize = new System.Drawing.Size(0, 22);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(221, 96);
            this.tlpMain.TabIndex = 0;
            // 
            // cbActiveLow
            // 
            this.cbActiveLow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbActiveLow.AutoSize = true;
            this.cbActiveLow.Location = new System.Drawing.Point(3, 3);
            this.cbActiveLow.Name = "cbActiveLow";
            this.cbActiveLow.Size = new System.Drawing.Size(75, 17);
            this.cbActiveLow.TabIndex = 0;
            this.cbActiveLow.Text = "Active low";
            this.cbActiveLow.UseVisualStyleBackColor = true;
            this.cbActiveLow.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbDelay
            // 
            this.cbDelay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDelay.AutoSize = true;
            this.cbDelay.Location = new System.Drawing.Point(3, 26);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.Size = new System.Drawing.Size(53, 17);
            this.cbDelay.TabIndex = 1;
            this.cbDelay.Text = "Delay";
            this.cbDelay.UseVisualStyleBackColor = true;
            this.cbDelay.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbDirect
            // 
            this.cbDirect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDirect.AutoSize = true;
            this.cbDirect.Location = new System.Drawing.Point(3, 49);
            this.cbDirect.Name = "cbDirect";
            this.cbDirect.Size = new System.Drawing.Size(54, 17);
            this.cbDirect.TabIndex = 2;
            this.cbDirect.Text = "Direct";
            this.cbDirect.UseVisualStyleBackColor = true;
            this.cbDirect.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbInputType
            // 
            this.cbInputType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbInputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputType.FormattingEnabled = true;
            this.cbInputType.Items.AddRange(new object[] {
            "None",
            "Sensor",
            "Button"});
            this.cbInputType.Location = new System.Drawing.Point(3, 72);
            this.cbInputType.Name = "cbInputType";
            this.cbInputType.Size = new System.Drawing.Size(121, 21);
            this.cbInputType.TabIndex = 3;
            this.cbInputType.SelectedIndexChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // LocoIOPortInputConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoIOPortInputConfigControl";
            this.Size = new System.Drawing.Size(221, 166);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.CheckBox cbActiveLow;
        private System.Windows.Forms.CheckBox cbDelay;
        private System.Windows.Forms.CheckBox cbDirect;
        private System.Windows.Forms.ComboBox cbInputType;
    }
}
