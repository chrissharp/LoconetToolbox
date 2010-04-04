namespace LocoNetToolBox.WinApp.Controls
{
    partial class LocoIOList
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
            this.components = new System.ComponentModel.Container();
            this.lbModules = new System.Windows.Forms.ListView();
            this.chAddress = new System.Windows.Forms.ColumnHeader();
            this.chVersion = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbModules
            // 
            this.lbModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAddress,
            this.chVersion});
            this.lbModules.ContextMenuStrip = this.contextMenuStrip1;
            this.lbModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbModules.FullRowSelect = true;
            this.lbModules.Location = new System.Drawing.Point(0, 0);
            this.lbModules.Name = "lbModules";
            this.lbModules.Size = new System.Drawing.Size(150, 150);
            this.lbModules.TabIndex = 0;
            this.lbModules.UseCompatibleStateImageBehavior = false;
            this.lbModules.View = System.Windows.Forms.View.Details;
            this.lbModules.ItemActivate += new System.EventHandler(this.lbModules_ItemActivate);
            this.lbModules.SelectedIndexChanged += new System.EventHandler(this.lbModules_SelectedIndexChanged);
            // 
            // chAddress
            // 
            this.chAddress.Text = "Address";
            // 
            // chVersion
            // 
            this.chVersion.Text = "Version";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxProgram});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 26);
            // 
            // ctxProgram
            // 
            this.ctxProgram.Name = "ctxProgram";
            this.ctxProgram.Size = new System.Drawing.Size(120, 22);
            this.ctxProgram.Text = "Program";
            // 
            // LocoIOList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbModules);
            this.Name = "LocoIOList";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader chAddress;
        private System.Windows.Forms.ColumnHeader chVersion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxProgram;
        private System.Windows.Forms.ListView lbModules;
    }
}
