using System;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using RSACoreLib;
using System.Management;
using System.Security.AccessControl;

namespace RSADupCheck
{
    public partial class Main : Form
    {
        private System.Diagnostics.Process oProcess = new System.Diagnostics.Process();
        private RSACore oRSACore;
        private String _BaseFolderTmp;
        private String _StructuredFolderTmp;
        private String _DuplicatedFolderTmp;
        public Main()
        {
            InitializeComponent();
            oRSACore = RSACore.GetInstance();
            CheckSystem();

            // Sistema nao configurado, forcar modo de configuacao
            if (!oRSACore.HasConfigured)
            {
                prefsItem.PerformClick();
            }
            else
            // Referencia de sistema configurado, ajustar os caminhos de processamento
            {
                SetOutputFolder(oRSACore.BaseFolder, false);
                oRSACore.Connect(); //Connectar ao banco de dados (MongoDB)
                if (!oRSACore.IsConnected)
                {
                    MessageBox.Show("A base de dados está indisponível, \r\n reiniciar a aplicação !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CheckSystem()
        {
            //var _syspaths_ = Environment.GetEnvironmentVariables();
            //String sRSAFolderTag = _syspaths_["PUBLIC"].ToString().ToUpper() + @"\.RSASystems\";
            String sRSAFolderTag =  @"C:\.RSASystems\";
            if (!Directory.Exists(sRSAFolderTag))
            {
                DirectoryInfo oDirInfo = Directory.CreateDirectory(sRSAFolderTag);
                oDirInfo.Attributes = FileAttributes.Hidden;
            }
            // Leitura do arquivo de configuracao do sistema, para tentar encontrar
            // parametro de configuracao ja existente
            oRSACore.BaseFolder = ConfigurationSettings.AppSettings.Get("BaseFolder");
            oRSACore.DbAddress = ConfigurationSettings.AppSettings.Get("DbAddress");
            oRSACore.DbPort = ConfigurationSettings.AppSettings.Get("DbPort");
            oRSACore.HasConfigured = true;
            // Se nao localizar o parametro, ajusta para sistema nao configurado
            if (oRSACore.BaseFolder == null || oRSACore.BaseFolder == "")
            {
                oRSACore.HasConfigured = false;
                oRSACore.BaseFolder = "";
            }
            // caso contrario, ajusta como configurado
            if (oRSACore.DbAddress == null || oRSACore.DbAddress == "")
            {
                oRSACore.HasConfigured = false;
                oRSACore.DbAddress = "";
            }
            // caso contrario, ajusta como configurado
            if (oRSACore.DbPort == null || oRSACore.DbPort == "")
            {
                oRSACore.HasConfigured = false;
                oRSACore.DbPort = "";
            }
        }
        private void SetOutputFolder(String pFolder, Boolean pTemp)
        {
            //TODO: revisar o codigo para somente criar a pasta temporaria caso o parametro pTemp seja verdadeiro
            // Ajusta as variaveis temporarias para processamento
            _BaseFolderTmp = pFolder;  // Pasta base
            _StructuredFolderTmp = pFolder + @"\Structured\"; // pasta para receber arquivos estruturadas
            _DuplicatedFolderTmp = pFolder + @"\Duplicated\"; // pasta para receber arquivos duplicados

            // Se nao existe a pasta base, criar toda a estrutura
            if (!Directory.Exists(_BaseFolderTmp))
            {
                Directory.CreateDirectory(_BaseFolderTmp);
                Directory.CreateDirectory(_StructuredFolderTmp);
                Directory.CreateDirectory(_DuplicatedFolderTmp);
            }
            // se existe a pasta base, verifica as subpastas
            else
            {
                if (!Directory.Exists(_StructuredFolderTmp))
                {
                    Directory.CreateDirectory(_StructuredFolderTmp);
                }
                if (!Directory.Exists(_DuplicatedFolderTmp))
                {
                    Directory.CreateDirectory(_DuplicatedFolderTmp);
                }
            }
            // Se nao for criacao de pasta temporaria, ajuste para estrutura definitiva
            if (!pTemp)
            {
                oRSACore.BaseFolder = _BaseFolderTmp;
                oRSACore.StructuredFolder = _StructuredFolderTmp;
                oRSACore.DuplicatedFolder = _DuplicatedFolderTmp;
                //_DbConnParam = @"Data Source=" + oRSACore.BaseFolder + @"\DupCheckDb.sdf;Password=";
            }
        }
        private void scanItem_Click(object sender, EventArgs e)
        {
            oRSACore.Connect();  // garantir que o banco de dados esta conectado (MongoDb)
            if (oRSACore.IsConnected)
            {
                Scan oScan = new Scan();
                oScan.ShowDialog(this);
                oScan.Dispose();
                oScan = null;
            }
            else
            {
                MessageBox.Show("Banco de dados indisponível !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void organizeItem_Click(object sender, EventArgs e)
        {
            Organizer oOrganizer = new Organizer();
            oOrganizer.ShowDialog(this);
        }
        private void viewItem_Click(object sender, EventArgs e)
        {
            CheckViewer oCheckViewer = new CheckViewer();
            oCheckViewer.Enabled = true;
            oCheckViewer.ShowDialog(this);
        }
        private void prefsItem_Click(object sender, EventArgs e)
        {
            scanItem.Enabled = false;
            organizeItem.Enabled = false;
            viewItem.Enabled = false;
            prefsItem.Enabled = false;

            Prefs oPrefs = new Prefs();
            oPrefs.ShowDialog(this);

            if (oRSACore.HasConfigured)
            {
                CheckSystem();
                scanItem.Enabled = true;
                organizeItem.Enabled = true;
                viewItem.Enabled = true;
                prefsItem.Enabled = true;
                sairItem.Enabled = true;
            }
            else
            {
                prefsItem.Enabled = true;
            }
        }
        private void sairItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}