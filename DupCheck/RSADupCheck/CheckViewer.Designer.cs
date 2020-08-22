namespace RSADupCheck
{
    partial class CheckViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckViewer));
            this.txHash = new System.Windows.Forms.TextBox();
            this.txFriendlyname = new System.Windows.Forms.TextBox();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.txTags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txProcessStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btCommitAll = new System.Windows.Forms.Button();
            this.btReclassifyOne = new System.Windows.Forms.Button();
            this.btCommit = new System.Windows.Forms.Button();
            this.btReclassify = new System.Windows.Forms.Button();
            this.btEnableReclassify = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotalImages = new System.Windows.Forms.Label();
            this.lbCurrentImage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btRotateRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btPreviousHash = new System.Windows.Forms.Button();
            this.btNextHash = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tipRecycle = new System.Windows.Forms.ToolTip(this.components);
            this.btRetornar = new System.Windows.Forms.Button();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.webShowPDF = new System.Windows.Forms.WebBrowser();
            this.axMyplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMyplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // txHash
            // 
            this.txHash.Enabled = false;
            this.txHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txHash.Location = new System.Drawing.Point(108, 49);
            this.txHash.Name = "txHash";
            this.txHash.Size = new System.Drawing.Size(496, 20);
            this.txHash.TabIndex = 14;
            // 
            // txFriendlyname
            // 
            this.txFriendlyname.Enabled = false;
            this.txFriendlyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFriendlyname.Location = new System.Drawing.Point(109, 75);
            this.txFriendlyname.Name = "txFriendlyname";
            this.txFriendlyname.Size = new System.Drawing.Size(495, 20);
            this.txFriendlyname.TabIndex = 15;
            // 
            // cmbClassification
            // 
            this.cmbClassification.Enabled = false;
            this.cmbClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(108, 19);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(495, 21);
            this.cmbClassification.TabIndex = 16;
            this.cmbClassification.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClassification_KeyPress);
            // 
            // txTags
            // 
            this.txTags.Enabled = false;
            this.txTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTags.Location = new System.Drawing.Point(108, 101);
            this.txTags.Multiline = true;
            this.txTags.Name = "txTags";
            this.txTags.Size = new System.Drawing.Size(495, 87);
            this.txTags.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "ID interno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nome amigável";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Classificação";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tags";
            // 
            // txProcessStatus
            // 
            this.txProcessStatus.Enabled = false;
            this.txProcessStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txProcessStatus.Location = new System.Drawing.Point(108, 196);
            this.txProcessStatus.Name = "txProcessStatus";
            this.txProcessStatus.Size = new System.Drawing.Size(495, 20);
            this.txProcessStatus.TabIndex = 22;
            this.txProcessStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btEnableReclassify);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txProcessStatus);
            this.groupBox1.Controls.Add(this.txHash);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txFriendlyname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbClassification);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txTags);
            this.groupBox1.Location = new System.Drawing.Point(14, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 355);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btCommitAll);
            this.groupBox3.Controls.Add(this.btReclassifyOne);
            this.groupBox3.Controls.Add(this.btCommit);
            this.groupBox3.Controls.Add(this.btReclassify);
            this.groupBox3.Location = new System.Drawing.Point(311, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 94);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // btCommitAll
            // 
            this.btCommitAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCommitAll.Image = global::RSADupCheck.Properties.Resources.Trash;
            this.btCommitAll.Location = new System.Drawing.Point(235, 19);
            this.btCommitAll.Name = "btCommitAll";
            this.btCommitAll.Size = new System.Drawing.Size(52, 40);
            this.btCommitAll.TabIndex = 31;
            this.btCommitAll.UseVisualStyleBackColor = true;
            this.btCommitAll.Click += new System.EventHandler(this.btCommitAll_Click);
            this.btCommitAll.MouseHover += new System.EventHandler(this.btCommitAll_MouseHover);
            // 
            // btReclassifyOne
            // 
            this.btReclassifyOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btReclassifyOne.Image = global::RSADupCheck.Properties.Resources.Left_right;
            this.btReclassifyOne.Location = new System.Drawing.Point(6, 19);
            this.btReclassifyOne.Name = "btReclassifyOne";
            this.btReclassifyOne.Size = new System.Drawing.Size(52, 40);
            this.btReclassifyOne.TabIndex = 29;
            this.btReclassifyOne.UseVisualStyleBackColor = true;
            this.btReclassifyOne.Click += new System.EventHandler(this.btReclassifyOne_Click);
            this.btReclassifyOne.MouseHover += new System.EventHandler(this.btReclassifyOne_MouseHover);
            // 
            // btCommit
            // 
            this.btCommit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCommit.Image = global::RSADupCheck.Properties.Resources.Recycle1;
            this.btCommit.Location = new System.Drawing.Point(177, 19);
            this.btCommit.Name = "btCommit";
            this.btCommit.Size = new System.Drawing.Size(52, 40);
            this.btCommit.TabIndex = 30;
            this.btCommit.UseVisualStyleBackColor = true;
            this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
            this.btCommit.MouseHover += new System.EventHandler(this.btCommit_MouseHover);
            // 
            // btReclassify
            // 
            this.btReclassify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btReclassify.Image = global::RSADupCheck.Properties.Resources.Knob_Shuffle_On;
            this.btReclassify.Location = new System.Drawing.Point(64, 19);
            this.btReclassify.Name = "btReclassify";
            this.btReclassify.Size = new System.Drawing.Size(52, 40);
            this.btReclassify.TabIndex = 28;
            this.btReclassify.UseVisualStyleBackColor = true;
            this.btReclassify.Click += new System.EventHandler(this.btReclassify_Click);
            this.btReclassify.MouseHover += new System.EventHandler(this.btReclassify_MouseHover);
            // 
            // btEnableReclassify
            // 
            this.btEnableReclassify.Image = global::RSADupCheck.Properties.Resources.Modify;
            this.btEnableReclassify.Location = new System.Drawing.Point(608, 19);
            this.btEnableReclassify.Name = "btEnableReclassify";
            this.btEnableReclassify.Size = new System.Drawing.Size(40, 30);
            this.btEnableReclassify.TabIndex = 27;
            this.btEnableReclassify.UseVisualStyleBackColor = true;
            this.btEnableReclassify.Click += new System.EventHandler(this.btEnableReclassify_Click);
            this.btEnableReclassify.MouseHover += new System.EventHandler(this.btEnableReclassify_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTotalImages);
            this.groupBox2.Controls.Add(this.lbCurrentImage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btRotateRight);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btPreviousHash);
            this.groupBox2.Controls.Add(this.btNextHash);
            this.groupBox2.Location = new System.Drawing.Point(10, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 97);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // lbTotalImages
            // 
            this.lbTotalImages.AutoSize = true;
            this.lbTotalImages.ForeColor = System.Drawing.Color.Red;
            this.lbTotalImages.Location = new System.Drawing.Point(150, 73);
            this.lbTotalImages.Name = "lbTotalImages";
            this.lbTotalImages.Size = new System.Drawing.Size(28, 13);
            this.lbTotalImages.TabIndex = 30;
            this.lbTotalImages.Text = "999";
            // 
            // lbCurrentImage
            // 
            this.lbCurrentImage.AutoSize = true;
            this.lbCurrentImage.ForeColor = System.Drawing.Color.Red;
            this.lbCurrentImage.Location = new System.Drawing.Point(85, 73);
            this.lbCurrentImage.Name = "lbCurrentImage";
            this.lbCurrentImage.Size = new System.Drawing.Size(28, 13);
            this.lbCurrentImage.TabIndex = 29;
            this.lbCurrentImage.Text = "999";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "de";
            // 
            // btRotateRight
            // 
            this.btRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btRotateRight.Image = global::RSADupCheck.Properties.Resources.Knob_Refresh;
            this.btRotateRight.Location = new System.Drawing.Point(171, 19);
            this.btRotateRight.Name = "btRotateRight";
            this.btRotateRight.Size = new System.Drawing.Size(52, 40);
            this.btRotateRight.TabIndex = 26;
            this.btRotateRight.UseVisualStyleBackColor = true;
            this.btRotateRight.Click += new System.EventHandler(this.btRotateRight_Click);
            this.btRotateRight.MouseHover += new System.EventHandler(this.btRotateRight_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Imagem";
            // 
            // btPreviousHash
            // 
            this.btPreviousHash.Image = global::RSADupCheck.Properties.Resources.Knob_Fast_Rewind;
            this.btPreviousHash.Location = new System.Drawing.Point(26, 19);
            this.btPreviousHash.Name = "btPreviousHash";
            this.btPreviousHash.Size = new System.Drawing.Size(52, 40);
            this.btPreviousHash.TabIndex = 25;
            this.btPreviousHash.UseVisualStyleBackColor = true;
            this.btPreviousHash.Click += new System.EventHandler(this.btPreviousHash_Click);
            this.btPreviousHash.MouseHover += new System.EventHandler(this.btPreviousHash_MouseHover);
            // 
            // btNextHash
            // 
            this.btNextHash.Image = global::RSADupCheck.Properties.Resources.Knob_Fast_Forward;
            this.btNextHash.Location = new System.Drawing.Point(99, 19);
            this.btNextHash.Name = "btNextHash";
            this.btNextHash.Size = new System.Drawing.Size(52, 40);
            this.btNextHash.TabIndex = 26;
            this.btNextHash.UseVisualStyleBackColor = true;
            this.btNextHash.Click += new System.EventHandler(this.btNextHash_Click);
            this.btNextHash.MouseHover += new System.EventHandler(this.btNextHash_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Filtro";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(123, 37);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(495, 21);
            this.cmbFiltro.TabIndex = 24;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btRetornar
            // 
            this.btRetornar.Image = global::RSADupCheck.Properties.Resources.Exit;
            this.btRetornar.Location = new System.Drawing.Point(24, 440);
            this.btRetornar.Name = "btRetornar";
            this.btRetornar.Size = new System.Drawing.Size(52, 40);
            this.btRetornar.TabIndex = 24;
            this.btRetornar.UseVisualStyleBackColor = true;
            this.btRetornar.Click += new System.EventHandler(this.btRetornar_Click);
            // 
            // pBox
            // 
            this.pBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.pBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBox.Location = new System.Drawing.Point(674, 12);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(611, 540);
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            this.pBox.Click += new System.EventHandler(this.pBox_Click);
            // 
            // webShowPDF
            // 
            this.webShowPDF.Location = new System.Drawing.Point(674, 12);
            this.webShowPDF.MinimumSize = new System.Drawing.Size(20, 20);
            this.webShowPDF.Name = "webShowPDF";
            this.webShowPDF.Size = new System.Drawing.Size(250, 250);
            this.webShowPDF.TabIndex = 32;
            this.webShowPDF.Visible = false;
            // 
            // axMyplayer
            // 
            this.axMyplayer.Enabled = true;
            this.axMyplayer.Location = new System.Drawing.Point(679, 64);
            this.axMyplayer.Name = "axMyplayer";
            this.axMyplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMyplayer.OcxState")));
            this.axMyplayer.Size = new System.Drawing.Size(598, 416);
            this.axMyplayer.TabIndex = 33;
            this.axMyplayer.Visible = false;
            // 
            // CheckViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 575);
            this.Controls.Add(this.axMyplayer);
            this.Controls.Add(this.webShowPDF);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btRetornar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pBox);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckViewer";
            this.Text = "CheckViewer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMyplayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.TextBox txHash;
        private System.Windows.Forms.TextBox txFriendlyname;
        private System.Windows.Forms.ComboBox cmbClassification;
        private System.Windows.Forms.TextBox txTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txProcessStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btRetornar;
        private System.Windows.Forms.Button btPreviousHash;
        private System.Windows.Forms.Button btNextHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Button btRotateRight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTotalImages;
        private System.Windows.Forms.Label lbCurrentImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btReclassify;
        private System.Windows.Forms.Button btEnableReclassify;
        private System.Windows.Forms.Button btReclassifyOne;
        private System.Windows.Forms.Button btCommit;
        private System.Windows.Forms.ToolTip tipRecycle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btCommitAll;
        private System.Windows.Forms.WebBrowser webShowPDF;
        private AxWMPLib.AxWindowsMediaPlayer axMyplayer;
    }
}