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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.btRotateLeft = new System.Windows.Forms.Button();
            this.dgHashes = new System.Windows.Forms.DataGridView();
            this.hash_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRotateRight = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btProcessarImagem = new System.Windows.Forms.Button();
            this.btManterImagem = new System.Windows.Forms.Button();
            this.btMetaCancel = new System.Windows.Forms.Button();
            this.btMetaSave = new System.Windows.Forms.Button();
            this.btCancelaImagem = new System.Windows.Forms.Button();
            this.btMetaUpdate = new System.Windows.Forms.Button();
            this.txTags = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txClassification = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txFriendlyName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btRetornar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txProcessStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHashes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "HASH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Arquivos";
            // 
            // pBox
            // 
            this.pBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox.Location = new System.Drawing.Point(5, 3);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(524, 627);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox.TabIndex = 4;
            this.pBox.TabStop = false;
            // 
            // btRotateLeft
            // 
            this.btRotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRotateLeft.Location = new System.Drawing.Point(5, 641);
            this.btRotateLeft.Name = "btRotateLeft";
            this.btRotateLeft.Size = new System.Drawing.Size(93, 32);
            this.btRotateLeft.TabIndex = 5;
            this.btRotateLeft.Text = "Girar Esquerda";
            this.btRotateLeft.UseVisualStyleBackColor = true;
            this.btRotateLeft.Click += new System.EventHandler(this.btRotateLeft_Click);
            // 
            // dgHashes
            // 
            this.dgHashes.AllowUserToAddRows = false;
            this.dgHashes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHashes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hash_id,
            this._id,
            this.contagem});
            this.dgHashes.Location = new System.Drawing.Point(12, 39);
            this.dgHashes.MultiSelect = false;
            this.dgHashes.Name = "dgHashes";
            this.dgHashes.ReadOnly = true;
            this.dgHashes.Size = new System.Drawing.Size(526, 187);
            this.dgHashes.TabIndex = 6;
            this.dgHashes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHashes_RowEnter);
            // 
            // hash_id
            // 
            this.hash_id.HeaderText = "Identificador";
            this.hash_id.Name = "hash_id";
            this.hash_id.ReadOnly = true;
            this.hash_id.Width = 150;
            // 
            // _id
            // 
            this._id.HeaderText = "Hash";
            this._id.Name = "_id";
            this._id.ReadOnly = true;
            this._id.Width = 225;
            // 
            // contagem
            // 
            this.contagem.HeaderText = "Ocorrencias";
            this.contagem.Name = "contagem";
            this.contagem.ReadOnly = true;
            this.contagem.Width = 75;
            // 
            // dgFiles
            // 
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filename,
            this.volume,
            this.status});
            this.dgFiles.Location = new System.Drawing.Point(3, 3);
            this.dgFiles.MultiSelect = false;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.ReadOnly = true;
            this.dgFiles.Size = new System.Drawing.Size(512, 115);
            this.dgFiles.TabIndex = 8;
            this.dgFiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_RowEnter);
            // 
            // filename
            // 
            this.filename.HeaderText = "Arquivo";
            this.filename.Name = "filename";
            this.filename.ReadOnly = true;
            this.filename.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.filename.Width = 350;
            // 
            // volume
            // 
            this.volume.HeaderText = "Volume";
            this.volume.Name = "volume";
            this.volume.ReadOnly = true;
            this.volume.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.volume.Width = 65;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.status.Width = 50;
            // 
            // btRotateRight
            // 
            this.btRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRotateRight.Location = new System.Drawing.Point(436, 641);
            this.btRotateRight.Name = "btRotateRight";
            this.btRotateRight.Size = new System.Drawing.Size(93, 32);
            this.btRotateRight.TabIndex = 9;
            this.btRotateRight.Text = "Girar Direita";
            this.btRotateRight.UseVisualStyleBackColor = true;
            this.btRotateRight.Click += new System.EventHandler(this.btRotateRight_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btProcessarImagem);
            this.panel1.Controls.Add(this.btManterImagem);
            this.panel1.Controls.Add(this.btMetaCancel);
            this.panel1.Controls.Add(this.btMetaSave);
            this.panel1.Controls.Add(this.dgFiles);
            this.panel1.Controls.Add(this.btCancelaImagem);
            this.panel1.Controls.Add(this.btMetaUpdate);
            this.panel1.Controls.Add(this.txTags);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txClassification);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txFriendlyName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 348);
            this.panel1.TabIndex = 10;
            // 
            // btProcessarImagem
            // 
            this.btProcessarImagem.Location = new System.Drawing.Point(432, 260);
            this.btProcessarImagem.Name = "btProcessarImagem";
            this.btProcessarImagem.Size = new System.Drawing.Size(83, 39);
            this.btProcessarImagem.TabIndex = 11;
            this.btProcessarImagem.Text = "Processar";
            this.btProcessarImagem.UseVisualStyleBackColor = true;
            this.btProcessarImagem.Click += new System.EventHandler(this.btProcessarImagem_Click);
            // 
            // btManterImagem
            // 
            this.btManterImagem.Location = new System.Drawing.Point(432, 170);
            this.btManterImagem.Name = "btManterImagem";
            this.btManterImagem.Size = new System.Drawing.Size(83, 39);
            this.btManterImagem.TabIndex = 10;
            this.btManterImagem.Text = "Manter Imagem";
            this.btManterImagem.UseVisualStyleBackColor = true;
            this.btManterImagem.Click += new System.EventHandler(this.btManterImagem_Click);
            // 
            // btMetaCancel
            // 
            this.btMetaCancel.Enabled = false;
            this.btMetaCancel.Location = new System.Drawing.Point(327, 305);
            this.btMetaCancel.Name = "btMetaCancel";
            this.btMetaCancel.Size = new System.Drawing.Size(62, 23);
            this.btMetaCancel.TabIndex = 9;
            this.btMetaCancel.Text = "Cancelar";
            this.btMetaCancel.UseVisualStyleBackColor = true;
            this.btMetaCancel.Click += new System.EventHandler(this.btMetaCancel_Click);
            // 
            // btMetaSave
            // 
            this.btMetaSave.Enabled = false;
            this.btMetaSave.Location = new System.Drawing.Point(103, 305);
            this.btMetaSave.Name = "btMetaSave";
            this.btMetaSave.Size = new System.Drawing.Size(62, 23);
            this.btMetaSave.TabIndex = 8;
            this.btMetaSave.Text = "Salvar";
            this.btMetaSave.UseVisualStyleBackColor = true;
            this.btMetaSave.Click += new System.EventHandler(this.btMetaSave_Click);
            // 
            // btCancelaImagem
            // 
            this.btCancelaImagem.Location = new System.Drawing.Point(432, 215);
            this.btCancelaImagem.Name = "btCancelaImagem";
            this.btCancelaImagem.Size = new System.Drawing.Size(83, 39);
            this.btCancelaImagem.TabIndex = 7;
            this.btCancelaImagem.Text = "Excluir Imagem";
            this.btCancelaImagem.UseVisualStyleBackColor = true;
            this.btCancelaImagem.Click += new System.EventHandler(this.btCancelaImagem_Click);
            // 
            // btMetaUpdate
            // 
            this.btMetaUpdate.Location = new System.Drawing.Point(432, 125);
            this.btMetaUpdate.Name = "btMetaUpdate";
            this.btMetaUpdate.Size = new System.Drawing.Size(83, 39);
            this.btMetaUpdate.TabIndex = 6;
            this.btMetaUpdate.Text = "Atualizar metadados";
            this.btMetaUpdate.UseVisualStyleBackColor = true;
            this.btMetaUpdate.Click += new System.EventHandler(this.btMetaUpdate_Click);
            // 
            // txTags
            // 
            this.txTags.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txTags.Enabled = false;
            this.txTags.Location = new System.Drawing.Point(103, 178);
            this.txTags.Multiline = true;
            this.txTags.Name = "txTags";
            this.txTags.Size = new System.Drawing.Size(286, 98);
            this.txTags.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tags";
            // 
            // txClassification
            // 
            this.txClassification.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txClassification.Enabled = false;
            this.txClassification.Location = new System.Drawing.Point(103, 152);
            this.txClassification.Name = "txClassification";
            this.txClassification.Size = new System.Drawing.Size(286, 20);
            this.txClassification.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Classificação";
            // 
            // txFriendlyName
            // 
            this.txFriendlyName.Enabled = false;
            this.txFriendlyName.Location = new System.Drawing.Point(103, 126);
            this.txFriendlyName.Name = "txFriendlyName";
            this.txFriendlyName.Size = new System.Drawing.Size(286, 20);
            this.txFriendlyName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 129);
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
            this.panel2.Controls.Add(this.pBox);
            this.panel2.Controls.Add(this.btRotateLeft);
            this.panel2.Controls.Add(this.btRotateRight);
            this.panel2.Location = new System.Drawing.Point(574, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 693);
            this.panel2.TabIndex = 11;
            // 
            // btRetornar
            // 
            this.btRetornar.Location = new System.Drawing.Point(12, 680);
            this.btRetornar.Name = "btRetornar";
            this.btRetornar.Size = new System.Drawing.Size(86, 32);
            this.btRetornar.TabIndex = 10;
            this.btRetornar.Text = "Retornar";
            this.btRetornar.UseVisualStyleBackColor = true;
            this.btRetornar.Click += new System.EventHandler(this.btRetornar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 630);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status";
            // 
            // txProcessStatus
            // 
            this.txProcessStatus.Location = new System.Drawing.Point(340, 630);
            this.txProcessStatus.Name = "txProcessStatus";
            this.txProcessStatus.Size = new System.Drawing.Size(198, 20);
            this.txProcessStatus.TabIndex = 13;
            // 
            // Organizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 724);
            this.Controls.Add(this.txProcessStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btRetornar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgHashes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Organizer";
            this.Text = "Tags";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHashes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button btRotateLeft;
        private System.Windows.Forms.DataGridView dgHashes;
        private System.Windows.Forms.DataGridViewTextBoxColumn hash_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn contagem;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.Button btRotateRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txFriendlyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btMetaUpdate;
        private System.Windows.Forms.TextBox txTags;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txClassification;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCancelaImagem;
        private System.Windows.Forms.Button btMetaCancel;
        private System.Windows.Forms.Button btMetaSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btRetornar;
        private System.Windows.Forms.Button btProcessarImagem;
        private System.Windows.Forms.Button btManterImagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txProcessStatus;
    }
}