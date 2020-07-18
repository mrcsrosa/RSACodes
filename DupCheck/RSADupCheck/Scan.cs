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
using System.Management;
using System.Collections;
namespace RSADupCheck
{
    public partial class Scan : Form
    {
        StreamWriter oFile;
        private RSACore oRSACore;
        private Hashtable _hashSerialVolume = new Hashtable();
        public Scan()
        {
            InitializeComponent();
            oRSACore = RSACore.GetInstance();
            oRSACore.Connect();
            if (oRSACore.IsConnected)
            {
                FillLogicalDrives();
                cbLogicalDrives.SelectedIndex = 0;
                ckbFolders.Items.Clear();
                FillFolders(cbLogicalDrives.Text.Substring(0, 3));
            }
        }
        private void btHash_Click(object sender, EventArgs e)
        {
            if (ckbFolders.CheckedItems.Count < 1)
            {
                MessageBox.Show("Não foi selecionada nenhuma pasta !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RSAHash oRSAHash = new RSAHash();
            List<RSAPath> oRSAPaths = new List<RSAPath>();
            String _hashvalue_;
            oFile = new StreamWriter(@"D:\Saida.txt", true);
            pnlStatusProc.Visible = true;
            pBarFolders.Minimum = 0;
            pBarFolders.Maximum = ckbFolders.CheckedItems.Count;
            List<String> oAllSubDirs = new List<String>();
            for (Int32 nFolderIndex = 0; nFolderIndex < ckbFolders.CheckedItems.Count; nFolderIndex++)
            {
                try
                {
                    if (oRSACore.HasSubFolders(ckbFolders.CheckedItems[nFolderIndex].ToString()))
                    {
                        String[] _SubDirs = oRSACore.GetSubFolders(Directory.GetDirectories(ckbFolders.CheckedItems[nFolderIndex].ToString(),
                                                                                            "*.*",
                                                                                            chkSubFolder.Checked?SearchOption.AllDirectories:SearchOption.TopDirectoryOnly));
                        oAllSubDirs.Add(ckbFolders.CheckedItems[nFolderIndex].ToString());
                        foreach (String pSubFolder in _SubDirs)
                        {
                            oAllSubDirs.Add(pSubFolder);
                        }
                    }
                    else
                    {
                        oAllSubDirs.Add(ckbFolders.CheckedItems[nFolderIndex].ToString());
                    }
                }
                catch (Exception oErr)
                {
                    oRSACore.SaveDataAboutException(oErr);
                }
                pBarSubFolders.Minimum = 0;
                pBarSubFolders.Maximum = oAllSubDirs.Count;
                for (Int32 nSubDirsIndex = 0; nSubDirsIndex < oAllSubDirs.Count; nSubDirsIndex++)
                {
                    lblFilesInProc.Text = "Localizando arquivos em subpasta ";
                    pnlStatusProc.Refresh();
                    String[] pFiles = Directory.GetFiles(oAllSubDirs[nSubDirsIndex], txFileType.Text, SearchOption.TopDirectoryOnly);
                    lblFilesInProc.Text = "Processando " + pFiles.Length.ToString() + " arquivos";
                    pnlStatusProc.Refresh();
                    foreach (String pFile in pFiles)
                    {
                        _hashvalue_ = oRSACore.CalcularHash(pFile);
                        oRSAHash.hash = _hashvalue_;
                        if ( oRSAHash.GetRSAHash() == RSAHash.Status.HashNotFound)
                        {
                            oRSAHash.classification = "none";
                            oRSAHash.friendlyname = Path.GetFileName(pFile);
                            oRSAHash.insertDate = DateTime.Now;
                            oRSAHash.paths = new List<RSAPath>();
                            RSAPath oRSAPath = new RSAPath();
                            oRSAPath.volume = _hashSerialVolume[cbLogicalDrives.SelectedIndex].ToString();
                            oRSAPath.filename = pFile.ToString();
                            oRSAPath.insertDate = DateTime.Now;
                            oRSAPath.status = RSAPath.Status.New;
                            oRSAHash.paths.Add(oRSAPath);
                            oRSAHash.AddHash();
                        }
                        else
                        {
                            if (oRSAHash.paths.Find(x => x.filename.Equals(pFile)) == null)
                            {
                                RSAPath oRSAPath = new RSAPath();
                                oRSAPath.volume = _hashSerialVolume[cbLogicalDrives.SelectedIndex].ToString();
                                oRSAPath.filename = pFile.ToString();
                                oRSAPath.insertDate = DateTime.Now;
                                oRSAPath.status = RSAPath.Status.New;
                                oRSAHash.AddPath(oRSAPath);
                            }
                        }
                        oFile.WriteLine(pFile);
                    }
                    pBarSubFolders.Increment(1);
                    lblNSubFolders.Text = pBarSubFolders.Value.ToString();
                    lblFilesInProc.Text = "";
                    pnlStatusProc.Refresh();
                }
                pBarFolders.Increment(1);
                lblNFolders.Text = pBarFolders.Value.ToString();
            }
            oFile.Close();
        }
        private void FillFolders(String pLogicalDrive)
        {
            var _syspaths_ = Environment.GetEnvironmentVariables();
            String[] slFolders = Directory.GetDirectories(pLogicalDrive, "*.*", SearchOption.TopDirectoryOnly);
            foreach (String sFolder in slFolders)
            {
                if (sFolder.ToUpper().Contains("$RECYCLE.BIN"))
                {
                    continue;
                }
                else if ( sFolder.ToUpper() ==_syspaths_["ALLUSERSPROFILE"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["APPDATA"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["CommonProgramFiles"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["CommonProgramFiles(x86)"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["ComSpec"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["DriverData"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["LOCALAPPDATA"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["ProgramData"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["ProgramFiles"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["ProgramFiles(x86)"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["SystemRoot"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["TEMP"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["TMP"].ToString().ToUpper())
                {
                    continue;
                }
                else if (sFolder.ToUpper() == _syspaths_["windir"].ToString().ToUpper())
                {
                    continue;
                }
                else
                {
                    ckbFolders.Items.Add(sFolder);
                }
            }
            ckbFolders.SelectedIndex = 0;
        }
        private void FillLogicalDrives()
        {
            _hashSerialVolume.Clear();
            Int32 nPosition;
            String[] oDrives = Directory.GetLogicalDrives();
            ManagementObject oVolumes = null;
            RSAVolume oRSAVolume = new RSAVolume();
            foreach (String sDrive in oDrives)
            {
                // 2 - Removable Disk
                // 3 - Local Disk
                // 4 - Network Drive
                // 5 - Compact Disk
                oVolumes = new ManagementObject("win32_logicaldisk.deviceid=\"" + 
                                                sDrive.Substring(0, 2) + 
                                                "\"");
                oVolumes.Get();
                if (Convert.ToInt32(oVolumes["DriveType"]) >= 2 && 
                    Convert.ToInt32(oVolumes["DriveType"]) <= 4)
                {
                    oRSAVolume.serial = oVolumes["VolumeSerialNumber"] == null ? "0000-0000" : oVolumes["VolumeSerialNumber"].ToString();
                    if (oRSAVolume.GetVolume() == RSAVolume.Status.SerialNotFound)
                    {
                        oRSAVolume.type = oVolumes["DriveType"].ToString();
                        oRSAVolume.insertDate = DateTime.Now;
                        oRSAVolume.lastScanningDate = new DateTime();
                        oRSAVolume.AddVolume();
                    }
                    nPosition = cbLogicalDrives.Items.Add(sDrive + " => " + oRSAVolume.serial);
                    _hashSerialVolume.Add(nPosition, oRSAVolume.serial);
                }
            }
        }
        private void cbLogicalDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            ckbFolders.Items.Clear();
            FillFolders(cbLogicalDrives.Text.Substring(0, 3));
        }
        private void blink()
        {
            if (lblFilesInProc.BackColor == Color.Red)
                lblFilesInProc.BackColor = Color.Transparent;
            else
                lblFilesInProc.BackColor = Color.Red;
        }
        private void btOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
