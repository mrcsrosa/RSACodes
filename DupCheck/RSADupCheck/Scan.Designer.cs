namespace RSADupCheck
{
    partial class Scan
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
            this.pnlScan = new System.Windows.Forms.Panel();
            this.pnlStatusProc = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblFilesInProc = new System.Windows.Forms.Label();
            this.lblNFIles = new System.Windows.Forms.Label();
            this.lblNSubFolders = new System.Windows.Forms.Label();
            this.lblNFolders = new System.Windows.Forms.Label();
            this.pBarSubFolders = new System.Windows.Forms.ProgressBar();
            this.pBarFolders = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ckbMoveFiles = new System.Windows.Forms.CheckBox();
            this.btOut = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txFileType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkSubFolder = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ckbFolders = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLogicalDrives = new System.Windows.Forms.ComboBox();
            this.btHash = new System.Windows.Forms.Button();
            this.pnlScan.SuspendLayout();
            this.pnlStatusProc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScan
            // 
            this.pnlScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScan.Controls.Add(this.pnlStatusProc);
            this.pnlScan.Controls.Add(this.label15);
            this.pnlScan.Controls.Add(this.ckbMoveFiles);
            this.pnlScan.Controls.Add(this.btOut);
            this.pnlScan.Controls.Add(this.label10);
            this.pnlScan.Controls.Add(this.txFileType);
            this.pnlScan.Controls.Add(this.label9);
            this.pnlScan.Controls.Add(this.chkSubFolder);
            this.pnlScan.Controls.Add(this.label8);
            this.pnlScan.Controls.Add(this.ckbFolders);
            this.pnlScan.Controls.Add(this.label7);
            this.pnlScan.Controls.Add(this.cbLogicalDrives);
            this.pnlScan.Controls.Add(this.btHash);
            this.pnlScan.Location = new System.Drawing.Point(12, 12);
            this.pnlScan.Name = "pnlScan";
            this.pnlScan.Size = new System.Drawing.Size(746, 470);
            this.pnlScan.TabIndex = 15;
            // 
            // pnlStatusProc
            // 
            this.pnlStatusProc.Controls.Add(this.label12);
            this.pnlStatusProc.Controls.Add(this.label13);
            this.pnlStatusProc.Controls.Add(this.label14);
            this.pnlStatusProc.Controls.Add(this.lblFilesInProc);
            this.pnlStatusProc.Controls.Add(this.lblNFIles);
            this.pnlStatusProc.Controls.Add(this.lblNSubFolders);
            this.pnlStatusProc.Controls.Add(this.lblNFolders);
            this.pnlStatusProc.Controls.Add(this.pBarSubFolders);
            this.pnlStatusProc.Controls.Add(this.pBarFolders);
            this.pnlStatusProc.Controls.Add(this.label11);
            this.pnlStatusProc.Location = new System.Drawing.Point(17, 330);
            this.pnlStatusProc.Name = "pnlStatusProc";
            this.pnlStatusProc.Size = new System.Drawing.Size(722, 124);
            this.pnlStatusProc.TabIndex = 23;
            this.pnlStatusProc.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Pastas";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Subpastas";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 25;
            this.label14.Text = "Arquivos";
            // 
            // lblFilesInProc
            // 
            this.lblFilesInProc.AutoSize = true;
            this.lblFilesInProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesInProc.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFilesInProc.Location = new System.Drawing.Point(328, 96);
            this.lblFilesInProc.Name = "lblFilesInProc";
            this.lblFilesInProc.Size = new System.Drawing.Size(0, 17);
            this.lblFilesInProc.TabIndex = 31;
            // 
            // lblNFIles
            // 
            this.lblNFIles.AutoSize = true;
            this.lblNFIles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNFIles.Location = new System.Drawing.Point(640, 92);
            this.lblNFIles.Name = "lblNFIles";
            this.lblNFIles.Size = new System.Drawing.Size(0, 17);
            this.lblNFIles.TabIndex = 30;
            // 
            // lblNSubFolders
            // 
            this.lblNSubFolders.AutoSize = true;
            this.lblNSubFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNSubFolders.Location = new System.Drawing.Point(640, 63);
            this.lblNSubFolders.Name = "lblNSubFolders";
            this.lblNSubFolders.Size = new System.Drawing.Size(0, 17);
            this.lblNSubFolders.TabIndex = 29;
            // 
            // lblNFolders
            // 
            this.lblNFolders.AutoSize = true;
            this.lblNFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNFolders.Location = new System.Drawing.Point(640, 34);
            this.lblNFolders.Name = "lblNFolders";
            this.lblNFolders.Size = new System.Drawing.Size(0, 17);
            this.lblNFolders.TabIndex = 28;
            // 
            // pBarSubFolders
            // 
            this.pBarSubFolders.Location = new System.Drawing.Point(105, 63);
            this.pBarSubFolders.Name = "pBarSubFolders";
            this.pBarSubFolders.Size = new System.Drawing.Size(520, 23);
            this.pBarSubFolders.TabIndex = 26;
            // 
            // pBarFolders
            // 
            this.pBarFolders.Location = new System.Drawing.Point(105, 34);
            this.pBarFolders.Name = "pBarFolders";
            this.pBarFolders.Size = new System.Drawing.Size(520, 23);
            this.pBarFolders.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(250, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Processamento";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "Mover arquivos";
            // 
            // ckbMoveFiles
            // 
            this.ckbMoveFiles.AutoSize = true;
            this.ckbMoveFiles.Location = new System.Drawing.Point(158, 292);
            this.ckbMoveFiles.Name = "ckbMoveFiles";
            this.ckbMoveFiles.Size = new System.Drawing.Size(15, 14);
            this.ckbMoveFiles.TabIndex = 25;
            this.ckbMoveFiles.UseVisualStyleBackColor = true;
            // 
            // btOut
            // 
            this.btOut.Location = new System.Drawing.Point(626, 68);
            this.btOut.Name = "btOut";
            this.btOut.Size = new System.Drawing.Size(113, 30);
            this.btOut.TabIndex = 24;
            this.btOut.Text = "Exit";
            this.btOut.UseVisualStyleBackColor = true;
            this.btOut.Click += new System.EventHandler(this.btOut_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Padrao de arquivo";
            // 
            // txFileType
            // 
            this.txFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFileType.Location = new System.Drawing.Point(158, 254);
            this.txFileType.Name = "txFileType";
            this.txFileType.Size = new System.Drawing.Size(129, 22);
            this.txFileType.TabIndex = 12;
            this.txFileType.Text = "*.jpg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Subpastas";
            // 
            // chkSubFolder
            // 
            this.chkSubFolder.AutoSize = true;
            this.chkSubFolder.Location = new System.Drawing.Point(158, 232);
            this.chkSubFolder.Name = "chkSubFolder";
            this.chkSubFolder.Size = new System.Drawing.Size(15, 14);
            this.chkSubFolder.TabIndex = 19;
            this.chkSubFolder.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Pastas";
            // 
            // ckbFolders
            // 
            this.ckbFolders.FormattingEnabled = true;
            this.ckbFolders.Location = new System.Drawing.Point(158, 51);
            this.ckbFolders.Name = "ckbFolders";
            this.ckbFolders.Size = new System.Drawing.Size(386, 169);
            this.ckbFolders.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Unidade de disco";
            // 
            // cbLogicalDrives
            // 
            this.cbLogicalDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLogicalDrives.FormattingEnabled = true;
            this.cbLogicalDrives.Location = new System.Drawing.Point(158, 18);
            this.cbLogicalDrives.Name = "cbLogicalDrives";
            this.cbLogicalDrives.Size = new System.Drawing.Size(228, 24);
            this.cbLogicalDrives.TabIndex = 15;
            this.cbLogicalDrives.SelectedIndexChanged += new System.EventHandler(this.cbLogicalDrives_SelectedIndexChanged);
            // 
            // btHash
            // 
            this.btHash.Location = new System.Drawing.Point(626, 18);
            this.btHash.Name = "btHash";
            this.btHash.Size = new System.Drawing.Size(113, 30);
            this.btHash.TabIndex = 0;
            this.btHash.Text = "Process Hash";
            this.btHash.UseVisualStyleBackColor = true;
            this.btHash.Click += new System.EventHandler(this.btHash_Click);
            // 
            // Scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 494);
            this.Controls.Add(this.pnlScan);
            this.Name = "Scan";
            this.Text = "RSASoluções - Organizador de disco - Localizador de arquivos";
            this.pnlScan.ResumeLayout(false);
            this.pnlScan.PerformLayout();
            this.pnlStatusProc.ResumeLayout(false);
            this.pnlStatusProc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScan;
        private System.Windows.Forms.Panel pnlStatusProc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFilesInProc;
        private System.Windows.Forms.Label lblNFIles;
        private System.Windows.Forms.Label lblNSubFolders;
        private System.Windows.Forms.Label lblNFolders;
        private System.Windows.Forms.ProgressBar pBarSubFolders;
        private System.Windows.Forms.ProgressBar pBarFolders;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckbMoveFiles;
        private System.Windows.Forms.Button btOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txFileType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSubFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox ckbFolders;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLogicalDrives;
        private System.Windows.Forms.Button btHash;
    }
}