namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIOPortOutputConfigControl
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
            this.cbLowAtStartup = new System.Windows.Forms.CheckBox();
            this.cbHWReset = new System.Windows.Forms.CheckBox();
            this.cbPulseContact = new System.Windows.Forms.CheckBox();
            this.cbFlash = new System.Windows.Forms.CheckBox();
            this.cbMulti = new System.Windows.Forms.CheckBox();
            this.cbBlockDetector = new System.Windows.Forms.CheckBox();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.cbLowAtStartup, 0, 0);
            this.tlpMain.Controls.Add(this.cbHWReset, 0, 1);
            this.tlpMain.Controls.Add(this.cbPulseContact, 0, 2);
            this.tlpMain.Controls.Add(this.cbFlash, 0, 3);
            this.tlpMain.Controls.Add(this.cbMulti, 0, 4);
            this.tlpMain.Controls.Add(this.cbBlockDetector, 0, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.MinimumSize = new System.Drawing.Size(0, 22);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(221, 138);
            this.tlpMain.TabIndex = 0;
            // 
            // cbLowAtStartup
            // 
            this.cbLowAtStartup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLowAtStartup.AutoSize = true;
            this.cbLowAtStartup.Location = new System.Drawing.Point(3, 3);
            this.cbLowAtStartup.Name = "cbLowAtStartup";
            this.cbLowAtStartup.Size = new System.Drawing.Size(93, 17);
            this.cbLowAtStartup.TabIndex = 0;
            this.cbLowAtStartup.Text = "Low at startup";
            this.cbLowAtStartup.UseVisualStyleBackColor = true;
            this.cbLowAtStartup.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbHWReset
            // 
            this.cbHWReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbHWReset.AutoSize = true;
            this.cbHWReset.Location = new System.Drawing.Point(3, 26);
            this.cbHWReset.Name = "cbHWReset";
            this.cbHWReset.Size = new System.Drawing.Size(98, 17);
            this.cbHWReset.TabIndex = 1;
            this.cbHWReset.Text = "Hardware reset";
            this.cbHWReset.UseVisualStyleBackColor = true;
            this.cbHWReset.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbPulseContact
            // 
            this.cbPulseContact.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbPulseContact.AutoSize = true;
            this.cbPulseContact.Location = new System.Drawing.Point(3, 49);
            this.cbPulseContact.Name = "cbPulseContact";
            this.cbPulseContact.Size = new System.Drawing.Size(91, 17);
            this.cbPulseContact.TabIndex = 2;
            this.cbPulseContact.Text = "Pulse contact";
            this.cbPulseContact.UseVisualStyleBackColor = true;
            this.cbPulseContact.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbFlash
            // 
            this.cbFlash.AutoSize = true;
            this.cbFlash.Location = new System.Drawing.Point(3, 72);
            this.cbFlash.Name = "cbFlash";
            this.cbFlash.Size = new System.Drawing.Size(51, 17);
            this.cbFlash.TabIndex = 3;
            this.cbFlash.Text = "Flash";
            this.cbFlash.UseVisualStyleBackColor = true;
            this.cbFlash.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbMulti
            // 
            this.cbMulti.AutoSize = true;
            this.cbMulti.Location = new System.Drawing.Point(3, 95);
            this.cbMulti.Name = "cbMulti";
            this.cbMulti.Size = new System.Drawing.Size(48, 17);
            this.cbMulti.TabIndex = 4;
            this.cbMulti.Text = "Multi";
            this.cbMulti.UseVisualStyleBackColor = true;
            this.cbMulti.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // cbBlockDetector
            // 
            this.cbBlockDetector.AutoSize = true;
            this.cbBlockDetector.Location = new System.Drawing.Point(3, 118);
            this.cbBlockDetector.Name = "cbBlockDetector";
            this.cbBlockDetector.Size = new System.Drawing.Size(95, 17);
            this.cbBlockDetector.TabIndex = 5;
            this.cbBlockDetector.Text = "Block detector";
            this.cbBlockDetector.UseVisualStyleBackColor = true;
            this.cbBlockDetector.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // LocoIOPortOutputConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tlpMain);
            this.Name = "LocoIOPortOutputConfigControl";
            this.Size = new System.Drawing.Size(221, 166);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.CheckBox cbLowAtStartup;
        private System.Windows.Forms.CheckBox cbHWReset;
        private System.Windows.Forms.CheckBox cbPulseContact;
        private System.Windows.Forms.CheckBox cbFlash;
        private System.Windows.Forms.CheckBox cbMulti;
        private System.Windows.Forms.CheckBox cbBlockDetector;
    }
}
