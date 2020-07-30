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
            this.pBox = new System.Windows.Forms.PictureBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotalImages = new System.Windows.Forms.Label();
            this.lbCurrentImage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btPreviousHash = new System.Windows.Forms.Button();
            this.btNextHash = new System.Windows.Forms.Button();
            this.btRetornar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.btRotateRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // txHash
            // 
            this.txHash.Enabled = false;
            this.txHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txHash.Location = new System.Drawing.Point(121, 49);
            this.txHash.Name = "txHash";
            this.txHash.Size = new System.Drawing.Size(496, 20);
            this.txHash.TabIndex = 14;
            // 
            // txFriendlyname
            // 
            this.txFriendlyname.Enabled = false;
            this.txFriendlyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFriendlyname.Location = new System.Drawing.Point(122, 75);
            this.txFriendlyname.Name = "txFriendlyname";
            this.txFriendlyname.Size = new System.Drawing.Size(495, 20);
            this.txFriendlyname.TabIndex = 15;
            // 
            // cmbClassification
            // 
            this.cmbClassification.Enabled = false;
            this.cmbClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(121, 19);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(495, 21);
            this.cmbClassification.TabIndex = 16;
            // 
            // txTags
            // 
            this.txTags.Enabled = false;
            this.txTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTags.Location = new System.Drawing.Point(121, 101);
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
            this.txProcessStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txProcessStatus.Location = new System.Drawing.Point(121, 204);
            this.txProcessStatus.Name = "txProcessStatus";
            this.txProcessStatus.Size = new System.Drawing.Size(495, 20);
            this.txProcessStatus.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btRotateRight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txProcessStatus);
            this.groupBox1.Controls.Add(this.txHash);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txFriendlyname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbClassification);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txTags);
            this.groupBox1.Location = new System.Drawing.Point(14, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 355);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTotalImages);
            this.groupBox2.Controls.Add(this.lbCurrentImage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btPreviousHash);
            this.groupBox2.Controls.Add(this.btNextHash);
            this.groupBox2.Location = new System.Drawing.Point(122, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 97);
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
            // 
            // btNextHash
            // 
            this.btNextHash.Image = global::RSADupCheck.Properties.Resources.Knob_Fast_Forward;
            this.btNextHash.Location = new System.Drawing.Point(153, 19);
            this.btNextHash.Name = "btNextHash";
            this.btNextHash.Size = new System.Drawing.Size(52, 40);
            this.btNextHash.TabIndex = 26;
            this.btNextHash.UseVisualStyleBackColor = true;
            this.btNextHash.Click += new System.EventHandler(this.btNextHash_Click);
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
            this.cmbFiltro.Location = new System.Drawing.Point(135, 37);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(495, 21);
            this.cmbFiltro.TabIndex = 24;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // btRotateRight
            // 
            this.btRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btRotateRight.Image = global::RSADupCheck.Properties.Resources.Knob_Refresh;
            this.btRotateRight.Location = new System.Drawing.Point(564, 276);
            this.btRotateRight.Name = "btRotateRight";
            this.btRotateRight.Size = new System.Drawing.Size(52, 40);
            this.btRotateRight.TabIndex = 26;
            this.btRotateRight.UseVisualStyleBackColor = true;
            this.btRotateRight.Click += new System.EventHandler(this.btRotateRight_Click);
            // 
            // CheckViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 575);
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
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}