namespace LocoNetToolBox.WinApp.Controls
{
    partial class CommandControl
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
            this.cmdQuery = new System.Windows.Forms.Button();
            this.cmdGpOn = new System.Windows.Forms.Button();
            this.cmdGpOff = new System.Windows.Forms.Button();
            this.lbFunctions = new System.Windows.Forms.Label();
            this.cmdAdvanced = new System.Windows.Forms.Button();
            this.cmdServoProgrammer = new System.Windows.Forms.Button();
            this.cmdServoTester = new System.Windows.Forms.Button();
            this.cmdProgramLocoIO = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.cmdQuery, 0, 4);
            this.tlpMain.Controls.Add(this.cmdGpOn, 0, 0);
            this.tlpMain.Controls.Add(this.cmdGpOff, 1, 0);
            this.tlpMain.Controls.Add(this.lbFunctions, 0, 2);
            this.tlpMain.Controls.Add(this.cmdAdvanced, 0, 10);
            this.tlpMain.Controls.Add(this.cmdServoProgrammer, 1, 8);
            this.tlpMain.Controls.Add(this.cmdServoTester, 0, 8);
            this.tlpMain.Controls.Add(this.cmdProgramLocoIO, 1, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 11;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(376, 359);
            this.tlpMain.TabIndex = 4;
            // 
            // cmdQuery
            // 
            this.cmdQuery.Location = new System.Drawing.Point(3, 87);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(133, 45);
            this.cmdQuery.TabIndex = 11;
            this.cmdQuery.Text = "Find all MGV50\'s";
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // cmdGpOn
            // 
            this.cmdGpOn.Location = new System.Drawing.Point(3, 3);
            this.cmdGpOn.Name = "cmdGpOn";
            this.cmdGpOn.Size = new System.Drawing.Size(133, 45);
            this.cmdGpOn.TabIndex = 8;
            this.cmdGpOn.Text = "Global Power On";
            this.cmdGpOn.UseVisualStyleBackColor = true;
            this.cmdGpOn.Click += new System.EventHandler(this.cmdGpOn_Click);
            // 
            // cmdGpOff
            // 
            this.cmdGpOff.Location = new System.Drawing.Point(191, 3);
            this.cmdGpOff.Name = "cmdGpOff";
            this.cmdGpOff.Size = new System.Drawing.Size(133, 45);
            this.cmdGpOff.TabIndex = 9;
            this.cmdGpOff.Text = "Global Power Off";
            this.cmdGpOff.UseVisualStyleBackColor = true;
            this.cmdGpOff.Click += new System.EventHandler(this.cmdGpOff_Click);
            // 
            // lbFunctions
            // 
            this.lbFunctions.AutoSize = true;
            this.lbFunctions.Location = new System.Drawing.Point(3, 71);
            this.lbFunctions.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.lbFunctions.Name = "lbFunctions";
            this.lbFunctions.Size = new System.Drawing.Size(53, 13);
            this.lbFunctions.TabIndex = 18;
            this.lbFunctions.Text = "Functions";
            // 
            // cmdAdvanced
            // 
            this.cmdAdvanced.Location = new System.Drawing.Point(3, 311);
            this.cmdAdvanced.Name = "cmdAdvanced";
            this.cmdAdvanced.Size = new System.Drawing.Size(133, 45);
            this.cmdAdvanced.TabIndex = 19;
            this.cmdAdvanced.Text = "Advanced";
            this.cmdAdvanced.UseVisualStyleBackColor = true;
            this.cmdAdvanced.Click += new System.EventHandler(this.cmdAdvanced_Click);
            // 
            // cmdServoProgrammer
            // 
            this.cmdServoProgrammer.Location = new System.Drawing.Point(191, 138);
            this.cmdServoProgrammer.Name = "cmdServoProgrammer";
            this.cmdServoProgrammer.Size = new System.Drawing.Size(133, 45);
            this.cmdServoProgrammer.TabIndex = 17;
            this.cmdServoProgrammer.Text = "Servo Configurator";
            this.cmdServoProgrammer.UseVisualStyleBackColor = true;
            this.cmdServoProgrammer.Click += new System.EventHandler(this.cmdServoProgrammer_Click);
            // 
            // cmdServoTester
            // 
            this.cmdServoTester.Location = new System.Drawing.Point(3, 138);
            this.cmdServoTester.Name = "cmdServoTester";
            this.cmdServoTester.Size = new System.Drawing.Size(133, 45);
            this.cmdServoTester.TabIndex = 20;
            this.cmdServoTester.Text = "Servo Tester";
            this.cmdServoTester.UseVisualStyleBackColor = true;
            this.cmdServoTester.Click += new System.EventHandler(this.cmdServoTester_Click);
            // 
            // cmdProgramLocoIO
            // 
            this.cmdProgramLocoIO.Location = new System.Drawing.Point(191, 87);
            this.cmdProgramLocoIO.Name = "cmdProgramLocoIO";
            this.cmdProgramLocoIO.Size = new System.Drawing.Size(133, 45);
            this.cmdProgramLocoIO.TabIndex = 21;
            this.cmdProgramLocoIO.Text = "Program MGV50";
            this.cmdProgramLocoIO.UseVisualStyleBackColor = true;
            this.cmdProgramLocoIO.Click += new System.EventHandler(this.cmdProgramLocoIO_Click);
            // 
            // CommandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "CommandControl";
            this.Size = new System.Drawing.Size(376, 359);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button cmdGpOn;
        private System.Windows.Forms.Button cmdGpOff;
        private System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.Button cmdServoProgrammer;
        private System.Windows.Forms.Label lbFunctions;
        private System.Windows.Forms.Button cmdAdvanced;
        private System.Windows.Forms.Button cmdServoTester;
        private System.Windows.Forms.Button cmdProgramLocoIO;
    }
}
