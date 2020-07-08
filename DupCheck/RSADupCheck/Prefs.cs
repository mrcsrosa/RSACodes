using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using RSACoreLib;

namespace RSADupCheck
{
    public partial class Prefs : Form
    {
        private String _BaseFolderTmp;
        private String _StructuredFolderTmp;
        private String _DuplicatedFolderTmp;
        private RSACore oRSACore;
        private Boolean bHasChanged;
        public Prefs()
        {
            InitializeComponent();
            oRSACore = RSACore.GetInstance();
            txBaseFolder.Text = oRSACore.BaseFolder;
            txDbPort.Text = oRSACore.DbPort;
            txDbAdress.Text = oRSACore.DbAddress;
        }
        private void btFolderSelect_Click(object sender, EventArgs e)
        {
            String sSelectedFolder;
            // Exibe caixa de dialogo para selecao da pasta base
            DialogResult oFldrResult = fldrBrowser.ShowDialog(this);

            sSelectedFolder = fldrBrowser.SelectedPath;
            txBaseFolder.Text = sSelectedFolder;
        }
        private void btPrefsReturn_Click(object sender, EventArgs e)
        {
            if (!oRSACore.HasConfigured)
            {
                DialogResult oDialog = MessageBox.Show(this, "Sistema não configurado, não é possivel continuar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (oDialog == DialogResult.OK)
                {
                    this.Close();
                    //prefsItem.Enabled = true;
                    //pnlPrefs.Visible = false;
                }
            }
            else
            {
                this.Close();
                //bHasConfigured = true;
                //pnlPrefs.Visible = false;
                //scanItem.Enabled = true;
                //organizeItem.Enabled = true;
                //viewItem.Enabled = true;
                //prefsItem.Enabled = true;
            }
        }
        private void btPrefsSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txBaseFolder.Text))
            {
                if (!oRSACore.BaseFolder.Equals(txBaseFolder.Text))  //Aconfiguracao ativa e diferente da requisitada
                {
                    // A pasta informada não existe
                    if (!Directory.Exists(txBaseFolder.Text)) // O local destino informado nao existe
                    {
                        // A pasta informada nao existe, porem ja existe configuracao salva
                        if (oRSACore.HasConfigured)
                        {
                            if (MessageBox.Show("Já existe uma configuração ativa, deseja move-la?", "Alerta !!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (!CheckOutputFolder(txBaseFolder.Text.Trim()))
                                {
                                    SetOutputFolder(txBaseFolder.Text.Trim(), true);
                                    foreach (String sFile in Directory.GetFiles(oRSACore.BaseFolder, "*.*", SearchOption.AllDirectories))
                                    {
                                        File.Move(sFile, sFile.Replace(oRSACore.BaseFolder.Trim(), _BaseFolderTmp.Trim()));
                                    }
                                    oRSACore.BaseFolder = _BaseFolderTmp;
                                    SetOutputFolder(oRSACore.BaseFolder, false);
                                    oRSACore.HasConfigured = true;
                                }
                                else
                                {
                                    SetOutputFolder(txBaseFolder.Text.Trim(), false);
                                    oRSACore.HasConfigured = true;
                                }
                                oRSACore.DbAddress = txDbAdress.Text;
                                oRSACore.DbPort = txDbPort.Text;
                                SaveSysData();
                            }
                        }
                        else
                        {
                            if (!CheckOutputFolder(txBaseFolder.Text.Trim()))
                            {
                                SetOutputFolder(txBaseFolder.Text.Trim(), false);
                            }
                            oRSACore.BaseFolder = txBaseFolder.Text;
                            oRSACore.DbAddress = txDbAdress.Text;
                            oRSACore.DbPort = txDbPort.Text;
                            SaveSysData();
                            oRSACore.HasConfigured = true;
                        }
                    }
                    else
                    {
                        if (oRSACore.HasConfigured)
                        {
                            oRSACore.BaseFolder = txBaseFolder.Text.Trim();
                            if (!CheckOutputFolder(txBaseFolder.Text.Trim()))
                            {
                                SetOutputFolder(txBaseFolder.Text, false);
                            }
                            oRSACore.DbAddress = txDbAdress.Text;
                            oRSACore.DbPort = txDbPort.Text;
                            SaveSysData();
                        }
                        else
                        {
                            oRSACore.BaseFolder = txBaseFolder.Text.Trim();
                            if (!CheckOutputFolder(txBaseFolder.Text.Trim()))
                            {
                                SetOutputFolder(txBaseFolder.Text, false);
                            }
                            oRSACore.DbAddress = txDbAdress.Text;
                            oRSACore.DbPort = txDbPort.Text;
                            SaveSysData();
                            oRSACore.HasConfigured = true;
                        }
                    }
                }
            }
            else
            {
                DialogResult oDialog = MessageBox.Show(this, "Não foi informada informada nenhuma pasta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SetOutputFolder(String pFolder, Boolean pTemp)
        {
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
                //_DbConnParam = @"Data Source=" + _BaseFolder + @"\DupCheckDb.sdf;Password=";
            }
        }
        private Boolean CheckOutputFolder(String pFolder)
        {
            Boolean _SysOK = true;
            if (!Directory.Exists(pFolder))
            {
                _SysOK = false;
            }
            else
            {
                if (!Directory.Exists(pFolder + @"\Structured\"))
                {
                    _SysOK = false;
                }
                else
                {
                    if (!Directory.Exists(pFolder + @"\Duplicated\"))
                    {
                        _SysOK = false;
                    }
                }
            }
            return _SysOK;
        }
        private void SaveSysData()
        {
            Configuration oConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection oSettings = oConfig.AppSettings.Settings;
            if (oSettings["BaseFolder"] == null)
            {
                oSettings.Add("BaseFolder", oRSACore.BaseFolder);
            }
            else
            {
                oSettings["BaseFolder"].Value = oRSACore.BaseFolder;
            }
            if (oSettings["DbPort"] == null)
            {
                oSettings.Add("DbPort", oRSACore.DbPort);
            }
            else
            {
                oSettings["DbPort"].Value = oRSACore.DbPort;
            }
            if (oSettings["DbAddress"] == null)
            {
                oSettings.Add("DbAddress", oRSACore.DbAddress);
            }
            else
            {
                oSettings.Add("DbAddress", oRSACore.DbAddress);
            }


            oConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(oConfig.AppSettings.SectionInformation.Name);
        }
    }
}
