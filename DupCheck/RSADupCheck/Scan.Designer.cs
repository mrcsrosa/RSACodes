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
            this.btHash = new System.Windows.Forms.Button();
            this.cbLogicalDrives = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ckbFolders = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSubFolder = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txFileType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btOut = new System.Windows.Forms.Button();
            this.pnlStatusProc = new System.Windows.Forms.Panel();
            this.lbFilename = new System.Windows.Forms.Label();
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
            this.pnlImportar = new System.Windows.Forms.Panel();
            this.lblGira = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btImportar = new System.Windows.Forms.Button();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btFolderBrowsing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txForImporting = new System.Windows.Forms.TextBox();
            this.fldrBrowsing = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txFileTypeForImport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txTagsForImport = new System.Windows.Forms.TextBox();
            this.pbProcessamento = new System.Windows.Forms.ProgressBar();
            this.pnlStatusProc.SuspendLayout();
            this.pnlImportar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // ckbFolders
            // 
            this.ckbFolders.FormattingEnabled = true;
            this.ckbFolders.Location = new System.Drawing.Point(158, 51);
            this.ckbFolders.Name = "ckbFolders";
            this.ckbFolders.Size = new System.Drawing.Size(386, 169);
            this.ckbFolders.TabIndex = 17;
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
            // chkSubFolder
            // 
            this.chkSubFolder.AutoSize = true;
            this.chkSubFolder.Location = new System.Drawing.Point(158, 232);
            this.chkSubFolder.Name = "chkSubFolder";
            this.chkSubFolder.Size = new System.Drawing.Size(15, 14);
            this.chkSubFolder.TabIndex = 19;
            this.chkSubFolder.UseVisualStyleBackColor = true;
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
            // txFileType
            // 
            this.txFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFileType.Location = new System.Drawing.Point(158, 254);
            this.txFileType.Name = "txFileType";
            this.txFileType.Size = new System.Drawing.Size(129, 22);
            this.txFileType.TabIndex = 12;
            this.txFileType.Text = "*.jpg";
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
            // pnlStatusProc
            // 
            this.pnlStatusProc.Controls.Add(this.lbFilename);
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
            this.pnlStatusProc.Location = new System.Drawing.Point(17, 287);
            this.pnlStatusProc.Name = "pnlStatusProc";
            this.pnlStatusProc.Size = new System.Drawing.Size(722, 124);
            this.pnlStatusProc.TabIndex = 23;
            this.pnlStatusProc.Visible = false;
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilename.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbFilename.Location = new System.Drawing.Point(104, 91);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(0, 18);
            this.lbFilename.TabIndex = 32;
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
            this.lblFilesInProc.Location = new System.Drawing.Point(333, 128);
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
            // pnlImportar
            // 
            this.pnlImportar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImportar.Controls.Add(this.lblGira);
            this.pnlImportar.Controls.Add(this.pnlStatusProc);
            this.pnlImportar.Controls.Add(this.btOut);
            this.pnlImportar.Controls.Add(this.label10);
            this.pnlImportar.Controls.Add(this.txFileType);
            this.pnlImportar.Controls.Add(this.label9);
            this.pnlImportar.Controls.Add(this.chkSubFolder);
            this.pnlImportar.Controls.Add(this.label8);
            this.pnlImportar.Controls.Add(this.ckbFolders);
            this.pnlImportar.Controls.Add(this.label7);
            this.pnlImportar.Controls.Add(this.cbLogicalDrives);
            this.pnlImportar.Controls.Add(this.btHash);
            this.pnlImportar.Location = new System.Drawing.Point(12, 221);
            this.pnlImportar.Name = "pnlImportar";
            this.pnlImportar.Size = new System.Drawing.Size(746, 422);
            this.pnlImportar.TabIndex = 15;
            // 
            // lblGira
            // 
            this.lblGira.AutoSize = true;
            this.lblGira.Location = new System.Drawing.Point(660, 232);
            this.lblGira.Name = "lblGira";
            this.lblGira.Size = new System.Drawing.Size(9, 13);
            this.lblGira.TabIndex = 25;
            this.lblGira.Text = "|";
            this.lblGira.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbProcessamento);
            this.groupBox1.Controls.Add(this.txTagsForImport);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txFileTypeForImport);
            this.groupBox1.Controls.Add(this.btImportar);
            this.groupBox1.Controls.Add(this.cmbClassification);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btFolderBrowsing);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txForImporting);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 203);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Importar Pasta";
            // 
            // btImportar
            // 
            this.btImportar.Image = global::RSADupCheck.Properties.Resources.Database;
            this.btImportar.Location = new System.Drawing.Point(9, 158);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(79, 39);
            this.btImportar.TabIndex = 15;
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // cmbClassification
            // 
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(146, 76);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(369, 21);
            this.cmbClassification.TabIndex = 14;
            this.cmbClassification.Text = "<<classificar>>";
            this.cmbClassification.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClassification_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Classificação";
            // 
            // btFolderBrowsing
            // 
            this.btFolderBrowsing.Image = global::RSADupCheck.Properties.Resources.Folder;
            this.btFolderBrowsing.Location = new System.Drawing.Point(477, 19);
            this.btFolderBrowsing.Name = "btFolderBrowsing";
            this.btFolderBrowsing.Size = new System.Drawing.Size(38, 31);
            this.btFolderBrowsing.TabIndex = 2;
            this.btFolderBrowsing.UseVisualStyleBackColor = true;
            this.btFolderBrowsing.Click += new System.EventHandler(this.btFolderBrowsing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pasta para importar";
            // 
            // txForImporting
            // 
            this.txForImporting.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txForImporting.Location = new System.Drawing.Point(146, 24);
            this.txForImporting.Name = "txForImporting";
            this.txForImporting.Size = new System.Drawing.Size(330, 20);
            this.txForImporting.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Padrao de arquivo";
            // 
            // txFileTypeForImport
            // 
            this.txFileTypeForImport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txFileTypeForImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFileTypeForImport.Location = new System.Drawing.Point(146, 50);
            this.txFileTypeForImport.Name = "txFileTypeForImport";
            this.txFileTypeForImport.Size = new System.Drawing.Size(129, 20);
            this.txFileTypeForImport.TabIndex = 22;
            this.txFileTypeForImport.Text = "*.JPG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tags";
            // 
            // txTagsForImport
            // 
            this.txTagsForImport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txTagsForImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTagsForImport.Location = new System.Drawing.Point(146, 103);
            this.txTagsForImport.Multiline = true;
            this.txTagsForImport.Name = "txTagsForImport";
            this.txTagsForImport.Size = new System.Drawing.Size(369, 47);
            this.txTagsForImport.TabIndex = 25;
            // 
            // pbProcessamento
            // 
            this.pbProcessamento.Location = new System.Drawing.Point(146, 162);
            this.pbProcessamento.Name = "pbProcessamento";
            this.pbProcessamento.Size = new System.Drawing.Size(369, 26);
            this.pbProcessamento.TabIndex = 26;
            this.pbProcessamento.Visible = false;
            // 
            // Scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 659);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlImportar);
            this.Name = "Scan";
            this.Text = "RSASoluções - Organizador de disco - Localizador de arquivos";
            this.pnlStatusProc.ResumeLayout(false);
            this.pnlStatusProc.PerformLayout();
            this.pnlImportar.ResumeLayout(false);
            this.pnlImportar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btHash;
        private System.Windows.Forms.ComboBox cbLogicalDrives;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox ckbFolders;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSubFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txFileType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btOut;
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
        private System.Windows.Forms.Panel pnlImportar;
        private System.Windows.Forms.Label lblGira;
        private System.Windows.Forms.Label lbFilename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btFolderBrowsing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txForImporting;
        private System.Windows.Forms.FolderBrowserDialog fldrBrowsing;
        private System.Windows.Forms.ComboBox cmbClassification;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btImportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txFileTypeForImport;
        private System.Windows.Forms.TextBox txTagsForImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbProcessamento;
    }
}