namespace RSADupCheck
{
    partial class Prefs
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
            this.txBaseFolder = new System.Windows.Forms.TextBox();
            this.btFolderSelect = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btPrefsReturn = new System.Windows.Forms.Button();
            this.btPrefsSave = new System.Windows.Forms.Button();
            this.fldrBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txDbAdress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txDbPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txBaseFolder
            // 
            this.txBaseFolder.Location = new System.Drawing.Point(197, 22);
            this.txBaseFolder.Name = "txBaseFolder";
            this.txBaseFolder.Size = new System.Drawing.Size(283, 20);
            this.txBaseFolder.TabIndex = 2;
            // 
            // btFolderSelect
            // 
            this.btFolderSelect.Location = new System.Drawing.Point(502, 21);
            this.btFolderSelect.Name = "btFolderSelect";
            this.btFolderSelect.Size = new System.Drawing.Size(28, 24);
            this.btFolderSelect.TabIndex = 7;
            this.btFolderSelect.Text = "...";
            this.btFolderSelect.UseVisualStyleBackColor = true;
            this.btFolderSelect.Click += new System.EventHandler(this.btFolderSelect_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 17);
            this.label17.TabIndex = 8;
            this.label17.Text = "Pasta destino";
            // 
            // btPrefsReturn
            // 
            this.btPrefsReturn.Location = new System.Drawing.Point(554, 51);
            this.btPrefsReturn.Name = "btPrefsReturn";
            this.btPrefsReturn.Size = new System.Drawing.Size(94, 23);
            this.btPrefsReturn.TabIndex = 10;
            this.btPrefsReturn.Text = "Retornar";
            this.btPrefsReturn.UseVisualStyleBackColor = true;
            this.btPrefsReturn.Click += new System.EventHandler(this.btPrefsReturn_Click);
            // 
            // btPrefsSave
            // 
            this.btPrefsSave.Location = new System.Drawing.Point(554, 22);
            this.btPrefsSave.Name = "btPrefsSave";
            this.btPrefsSave.Size = new System.Drawing.Size(94, 23);
            this.btPrefsSave.TabIndex = 9;
            this.btPrefsSave.Text = "Salvar";
            this.btPrefsSave.UseVisualStyleBackColor = true;
            this.btPrefsSave.Click += new System.EventHandler(this.btPrefsSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Database endereco";
            // 
            // txDbAdress
            // 
            this.txDbAdress.Location = new System.Drawing.Point(197, 51);
            this.txDbAdress.Name = "txDbAdress";
            this.txDbAdress.Size = new System.Drawing.Size(283, 20);
            this.txDbAdress.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Database porta";
            // 
            // txDbPort
            // 
            this.txDbPort.Location = new System.Drawing.Point(197, 84);
            this.txDbPort.Name = "txDbPort";
            this.txDbPort.Size = new System.Drawing.Size(283, 20);
            this.txDbPort.TabIndex = 14;
            this.txDbPort.Text = "27017";
            // 
            // Prefs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 242);
            this.Controls.Add(this.txDbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txDbAdress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btPrefsReturn);
            this.Controls.Add(this.btPrefsSave);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btFolderSelect);
            this.Controls.Add(this.txBaseFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Prefs";
            this.Text = "Configurações do sistema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txBaseFolder;
        private System.Windows.Forms.Button btFolderSelect;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btPrefsReturn;
        private System.Windows.Forms.Button btPrefsSave;
        private System.Windows.Forms.FolderBrowserDialog fldrBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txDbAdress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txDbPort;
    }
}