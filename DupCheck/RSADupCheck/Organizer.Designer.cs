namespace RSADupCheck
{
    partial class Organizer
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbHash = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.btMetaCancel = new System.Windows.Forms.Button();
            this.btMetaSave = new System.Windows.Forms.Button();
            this.txTags = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btMetaUpdate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txFriendlyName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btNextImage = new System.Windows.Forms.Button();
            this.btPreviousImage = new System.Windows.Forms.Button();
            this.btRotateRight = new System.Windows.Forms.Button();
            this.lblCurrentImage = new System.Windows.Forms.Label();
            this.lblNumberOfImages = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txProcessStatus = new System.Windows.Forms.TextBox();
            this.ckAddProcessed = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotalRecord = new System.Windows.Forms.Label();
            this.lbNumRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btPreviousHash = new System.Windows.Forms.Button();
            this.btNextHash = new System.Windows.Forms.Button();
            this.btPurgeHash = new System.Windows.Forms.Button();
            this.btProcessarImagem = new System.Windows.Forms.Button();
            this.btRetornar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID interno";
            // 
            // lbHash
            // 
            this.lbHash.AutoSize = true;
            this.lbHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHash.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbHash.Location = new System.Drawing.Point(104, 16);
            this.lbHash.Name = "lbHash";
            this.lbHash.Size = new System.Drawing.Size(32, 13);
            this.lbHash.TabIndex = 2;
            this.lbHash.Text = "Hash";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmbClassification);
            this.panel1.Controls.Add(this.btMetaCancel);
            this.panel1.Controls.Add(this.btMetaSave);
            this.panel1.Controls.Add(this.txTags);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btMetaUpdate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 226);
            this.panel1.TabIndex = 10;
            // 
            // cmbClassification
            // 
            this.cmbClassification.Enabled = false;
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(103, 39);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(286, 21);
            this.cmbClassification.TabIndex = 12;
            this.cmbClassification.Text = "<<classificar>>";
            this.cmbClassification.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClassification_KeyPress);
            // 
            // btMetaCancel
            // 
            this.btMetaCancel.Enabled = false;
            this.btMetaCancel.Image = global::RSADupCheck.Properties.Resources.No;
            this.btMetaCancel.Location = new System.Drawing.Point(395, 124);
            this.btMetaCancel.Name = "btMetaCancel";
            this.btMetaCancel.Size = new System.Drawing.Size(40, 39);
            this.btMetaCancel.TabIndex = 9;
            this.btMetaCancel.UseVisualStyleBackColor = true;
            this.btMetaCancel.Click += new System.EventHandler(this.btMetaCancel_Click);
            // 
            // btMetaSave
            // 
            this.btMetaSave.Enabled = false;
            this.btMetaSave.Image = global::RSADupCheck.Properties.Resources.OK;
            this.btMetaSave.Location = new System.Drawing.Point(395, 82);
            this.btMetaSave.Name = "btMetaSave";
            this.btMetaSave.Size = new System.Drawing.Size(40, 39);
            this.btMetaSave.TabIndex = 8;
            this.btMetaSave.UseVisualStyleBackColor = true;
            this.btMetaSave.Click += new System.EventHandler(this.btMetaSave_Click);
            // 
            // txTags
            // 
            this.txTags.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txTags.Enabled = false;
            this.txTags.Location = new System.Drawing.Point(103, 65);
            this.txTags.Multiline = true;
            this.txTags.Name = "txTags";
            this.txTags.Size = new System.Drawing.Size(286, 98);
            this.txTags.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tags";
            // 
            // btMetaUpdate
            // 
            this.btMetaUpdate.Image = global::RSADupCheck.Properties.Resources.Modify;
            this.btMetaUpdate.Location = new System.Drawing.Point(395, 39);
            this.btMetaUpdate.Name = "btMetaUpdate";
            this.btMetaUpdate.Size = new System.Drawing.Size(40, 39);
            this.btMetaUpdate.TabIndex = 6;
            this.btMetaUpdate.UseVisualStyleBackColor = true;
            this.btMetaUpdate.Click += new System.EventHandler(this.btMetaUpdate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Classificação";
            // 
            // txFriendlyName
            // 
            this.txFriendlyName.Enabled = false;
            this.txFriendlyName.Location = new System.Drawing.Point(107, 43);
            this.txFriendlyName.Name = "txFriendlyName";
            this.txFriendlyName.Size = new System.Drawing.Size(286, 20);
            this.txFriendlyName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nome amigável";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.pBox);
            this.panel2.Location = new System.Drawing.Point(574, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 693);
            this.panel2.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblFilename);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btNextImage);
            this.groupBox1.Controls.Add(this.btPreviousImage);
            this.groupBox1.Controls.Add(this.btRotateRight);
            this.groupBox1.Controls.Add(this.lblCurrentImage);
            this.groupBox1.Controls.Add(this.lblNumberOfImages);
            this.groupBox1.Location = new System.Drawing.Point(3, 619);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 69);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Imagem";
            // 
            // lblFilename
            // 
            this.lblFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilename.AutoSize = true;
            this.lblFilename.ForeColor = System.Drawing.Color.Red;
            this.lblFilename.Location = new System.Drawing.Point(6, 49);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(41, 13);
            this.lblFilename.TabIndex = 16;
            this.lblFilename.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(124, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "de";
            // 
            // btNextImage
            // 
            this.btNextImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNextImage.Image = global::RSADupCheck.Properties.Resources.Knob_Forward;
            this.btNextImage.Location = new System.Drawing.Point(455, 13);
            this.btNextImage.Name = "btNextImage";
            this.btNextImage.Size = new System.Drawing.Size(45, 40);
            this.btNextImage.TabIndex = 14;
            this.btNextImage.UseVisualStyleBackColor = true;
            this.btNextImage.Click += new System.EventHandler(this.btNextImage_Click);
            // 
            // btPreviousImage
            // 
            this.btPreviousImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPreviousImage.Image = global::RSADupCheck.Properties.Resources.Knob_Left;
            this.btPreviousImage.Location = new System.Drawing.Point(404, 13);
            this.btPreviousImage.Name = "btPreviousImage";
            this.btPreviousImage.Size = new System.Drawing.Size(45, 40);
            this.btPreviousImage.TabIndex = 15;
            this.btPreviousImage.UseVisualStyleBackColor = true;
            this.btPreviousImage.Click += new System.EventHandler(this.btPreviousImage_Click);
            // 
            // btRotateRight
            // 
            this.btRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btRotateRight.Image = global::RSADupCheck.Properties.Resources.Knob_Refresh;
            this.btRotateRight.Location = new System.Drawing.Point(353, 13);
            this.btRotateRight.Name = "btRotateRight";
            this.btRotateRight.Size = new System.Drawing.Size(45, 40);
            this.btRotateRight.TabIndex = 9;
            this.btRotateRight.UseVisualStyleBackColor = true;
            this.btRotateRight.Click += new System.EventHandler(this.btRotateRight_Click);
            // 
            // lblCurrentImage
            // 
            this.lblCurrentImage.AutoSize = true;
            this.lblCurrentImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentImage.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentImage.Location = new System.Drawing.Point(79, 15);
            this.lblCurrentImage.Name = "lblCurrentImage";
            this.lblCurrentImage.Size = new System.Drawing.Size(39, 20);
            this.lblCurrentImage.TabIndex = 12;
            this.lblCurrentImage.Text = "999";
            // 
            // lblNumberOfImages
            // 
            this.lblNumberOfImages.AutoSize = true;
            this.lblNumberOfImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfImages.ForeColor = System.Drawing.Color.Blue;
            this.lblNumberOfImages.Location = new System.Drawing.Point(159, 14);
            this.lblNumberOfImages.Name = "lblNumberOfImages";
            this.lblNumberOfImages.Size = new System.Drawing.Size(39, 20);
            this.lblNumberOfImages.TabIndex = 13;
            this.lblNumberOfImages.Text = "999";
            // 
            // pBox
            // 
            this.pBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox.Location = new System.Drawing.Point(3, 3);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(524, 613);
            this.pBox.TabIndex = 4;
            this.pBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status";
            // 
            // txProcessStatus
            // 
            this.txProcessStatus.Enabled = false;
            this.txProcessStatus.Location = new System.Drawing.Point(107, 69);
            this.txProcessStatus.Name = "txProcessStatus";
            this.txProcessStatus.Size = new System.Drawing.Size(198, 20);
            this.txProcessStatus.TabIndex = 13;
            // 
            // ckAddProcessed
            // 
            this.ckAddProcessed.AutoSize = true;
            this.ckAddProcessed.Location = new System.Drawing.Point(418, 12);
            this.ckAddProcessed.Name = "ckAddProcessed";
            this.ckAddProcessed.Size = new System.Drawing.Size(117, 17);
            this.ckAddProcessed.TabIndex = 14;
            this.ckAddProcessed.Text = "Incluir processados";
            this.ckAddProcessed.UseVisualStyleBackColor = true;
            this.ckAddProcessed.Visible = false;
            this.ckAddProcessed.CheckStateChanged += new System.EventHandler(this.ckAddProcessed_CheckStateChanged);
            this.ckAddProcessed.EnabledChanged += new System.EventHandler(this.ckAddProcessed_EnabledChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTotalRecord);
            this.groupBox2.Controls.Add(this.lbNumRecord);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ckAddProcessed);
            this.groupBox2.Controls.Add(this.btPreviousHash);
            this.groupBox2.Controls.Add(this.lbHash);
            this.groupBox2.Controls.Add(this.btNextHash);
            this.groupBox2.Controls.Add(this.btPurgeHash);
            this.groupBox2.Controls.Add(this.txFriendlyName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txProcessStatus);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 157);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // lbTotalRecord
            // 
            this.lbTotalRecord.AutoSize = true;
            this.lbTotalRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecord.ForeColor = System.Drawing.Color.Blue;
            this.lbTotalRecord.Location = new System.Drawing.Point(410, 120);
            this.lbTotalRecord.Name = "lbTotalRecord";
            this.lbTotalRecord.Size = new System.Drawing.Size(39, 15);
            this.lbTotalRecord.TabIndex = 21;
            this.lbTotalRecord.Text = "9999";
            // 
            // lbNumRecord
            // 
            this.lbNumRecord.AutoSize = true;
            this.lbNumRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumRecord.ForeColor = System.Drawing.Color.Blue;
            this.lbNumRecord.Location = new System.Drawing.Point(340, 120);
            this.lbNumRecord.Name = "lbNumRecord";
            this.lbNumRecord.Size = new System.Drawing.Size(39, 15);
            this.lbNumRecord.TabIndex = 20;
            this.lbNumRecord.Text = "9999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(381, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "de";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Registro:";
            // 
            // btPreviousHash
            // 
            this.btPreviousHash.Image = global::RSADupCheck.Properties.Resources.Knob_Fast_Rewind;
            this.btPreviousHash.Location = new System.Drawing.Point(9, 111);
            this.btPreviousHash.Name = "btPreviousHash";
            this.btPreviousHash.Size = new System.Drawing.Size(45, 40);
            this.btPreviousHash.TabIndex = 16;
            this.btPreviousHash.UseVisualStyleBackColor = true;
            this.btPreviousHash.Click += new System.EventHandler(this.btPreviousHash_Click);
            // 
            // btNextHash
            // 
            this.btNextHash.Image = global::RSADupCheck.Properties.Resources.Knob_Fast_Forward;
            this.btNextHash.Location = new System.Drawing.Point(105, 111);
            this.btNextHash.Name = "btNextHash";
            this.btNextHash.Size = new System.Drawing.Size(45, 40);
            this.btNextHash.TabIndex = 17;
            this.btNextHash.UseVisualStyleBackColor = true;
            this.btNextHash.Click += new System.EventHandler(this.btNextHash_Click);
            // 
            // btPurgeHash
            // 
            this.btPurgeHash.Image = global::RSADupCheck.Properties.Resources.Knob_Remove_Red;
            this.btPurgeHash.Location = new System.Drawing.Point(472, 32);
            this.btPurgeHash.Name = "btPurgeHash";
            this.btPurgeHash.Size = new System.Drawing.Size(45, 40);
            this.btPurgeHash.TabIndex = 15;
            this.btPurgeHash.UseVisualStyleBackColor = true;
            this.btPurgeHash.Click += new System.EventHandler(this.btPurgeHash_Click);
            // 
            // btProcessarImagem
            // 
            this.btProcessarImagem.Image = global::RSADupCheck.Properties.Resources.Notes;
            this.btProcessarImagem.Location = new System.Drawing.Point(21, 450);
            this.btProcessarImagem.Name = "btProcessarImagem";
            this.btProcessarImagem.Size = new System.Drawing.Size(82, 59);
            this.btProcessarImagem.TabIndex = 11;
            this.btProcessarImagem.UseVisualStyleBackColor = true;
            this.btProcessarImagem.Click += new System.EventHandler(this.btProcessarImagem_Click);
            // 
            // btRetornar
            // 
            this.btRetornar.Image = global::RSADupCheck.Properties.Resources.Exit;
            this.btRetornar.Location = new System.Drawing.Point(366, 450);
            this.btRetornar.Name = "btRetornar";
            this.btRetornar.Size = new System.Drawing.Size(83, 59);
            this.btRetornar.TabIndex = 10;
            this.btRetornar.UseVisualStyleBackColor = true;
            this.btRetornar.Click += new System.EventHandler(this.btRetornar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 19);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Organizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 724);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btProcessarImagem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btRetornar);
            this.Name = "Organizer";
            this.Text = "Tags";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbHash;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button btRotateRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txFriendlyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btMetaUpdate;
        private System.Windows.Forms.TextBox txTags;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btMetaCancel;
        private System.Windows.Forms.Button btMetaSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btRetornar;
        private System.Windows.Forms.Button btProcessarImagem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txProcessStatus;
        private System.Windows.Forms.CheckBox ckAddProcessed;
        private System.Windows.Forms.Button btPurgeHash;
        private System.Windows.Forms.ComboBox cmbClassification;
        private System.Windows.Forms.Button btPreviousHash;
        private System.Windows.Forms.Button btNextHash;
        private System.Windows.Forms.Button btPreviousImage;
        private System.Windows.Forms.Button btNextImage;
        private System.Windows.Forms.Label lblNumberOfImages;
        private System.Windows.Forms.Label lblCurrentImage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTotalRecord;
        private System.Windows.Forms.Label lbNumRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}