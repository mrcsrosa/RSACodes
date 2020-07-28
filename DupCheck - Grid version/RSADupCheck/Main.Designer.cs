namespace RSADupCheck
{
     partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scanItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fldrBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanItem,
            this.organizeItem,
            this.viewItem,
            this.prefsItem,
            this.sairItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scanItem
            // 
            this.scanItem.Name = "scanItem";
            this.scanItem.Size = new System.Drawing.Size(44, 20);
            this.scanItem.Text = "Scan";
            this.scanItem.Click += new System.EventHandler(this.scanItem_Click);
            // 
            // organizeItem
            // 
            this.organizeItem.Name = "organizeItem";
            this.organizeItem.Size = new System.Drawing.Size(66, 20);
            this.organizeItem.Text = "Organize";
            this.organizeItem.Click += new System.EventHandler(this.organizeItem_Click);
            // 
            // viewItem
            // 
            this.viewItem.Name = "viewItem";
            this.viewItem.Size = new System.Drawing.Size(44, 20);
            this.viewItem.Text = "View";
            this.viewItem.Click += new System.EventHandler(this.viewItem_Click);
            // 
            // prefsItem
            // 
            this.prefsItem.Name = "prefsItem";
            this.prefsItem.Size = new System.Drawing.Size(45, 20);
            this.prefsItem.Text = "Prefs";
            this.prefsItem.Click += new System.EventHandler(this.prefsItem_Click);
            // 
            // sairItem
            // 
            this.sairItem.Name = "sairItem";
            this.sairItem.Size = new System.Drawing.Size(38, 20);
            this.sairItem.Text = "Sair";
            this.sairItem.Click += new System.EventHandler(this.sairItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(590, 256);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "RSASoluções - Organizador de disco - Arquivos duplicados";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem scanItem;
        private System.Windows.Forms.ToolStripMenuItem organizeItem;
        private System.Windows.Forms.ToolStripMenuItem viewItem;
        private System.Windows.Forms.ToolStripMenuItem prefsItem;
        private System.Windows.Forms.FolderBrowserDialog fldrBrowser;
        private System.Windows.Forms.ToolStripMenuItem sairItem;
    }
}

