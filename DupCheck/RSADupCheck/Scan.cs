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
            if (oRSACore.IsConnected)
            {
                FillClassification();
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
            //oFile = new StreamWriter(@"D:\Saida.txt", true);
            pnlStatusProc.Visible = true;
            pBarFolders.Minimum = 0;
            pBarFolders.Maximum = ckbFolders.CheckedItems.Count;
            pBarSubFolders.Minimum = 0;
            pBarSubFolders.Maximum = 100;
            lblGira.Text = @"|";
            lblGira.Visible = true;
            //List<String> oAllSubDirs = new List<String>();
            for (Int32 nFolderIndex = 0; nFolderIndex < ckbFolders.CheckedItems.Count; nFolderIndex++)
            {
                //try
                //{
                //    //if (oRSACore.HasSubFolders(ckbFolders.CheckedItems[nFolderIndex].ToString()))
                //    if (chkSubFolder.Checked)
                //    {
                //        String[] _SubDirs = oRSACore.GetSubFolders(Directory.GetDirectories(
                //                                                   ckbFolders.CheckedItems[nFolderIndex].ToString(),
                //                                                   "*.*",
                //                                                   chkSubFolder.Checked?SearchOption.AllDirectories:SearchOption.TopDirectoryOnly));
                //        oAllSubDirs.Add(ckbFolders.CheckedItems[nFolderIndex].ToString());
                //        foreach (String pSubFolder in _SubDirs)
                //        {
                //            oAllSubDirs.Add(pSubFolder);
                //            ItIsRunning();
                //        }
                //    }
                //    else
                //    {
                //        oAllSubDirs.Add(ckbFolders.CheckedItems[nFolderIndex].ToString());
                //    }
                //}
                //catch (Exception oErr)
                //{
                //    oRSACore.SaveDataAboutException(oErr);
                //}

                List<String> oAllSubDirs = new List<string>();
                oAllSubDirs.Add(ckbFolders.CheckedItems[nFolderIndex].ToString());
                String[] oSubDirs;
                try
                {
                    oSubDirs = Directory.GetDirectories(ckbFolders.CheckedItems[nFolderIndex].ToString(),
                                                                    "*.*",
                                                                    chkSubFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                }
                catch (PathTooLongException oErr)
                {
                    pBarFolders.Increment(1);
                    lblNFolders.Text = pBarFolders.Value.ToString();
                    ItIsRunning();
                    continue;
                }
                for (Int32 nCount = 0; nCount < oSubDirs.Length; nCount++)
                {
                    oAllSubDirs.Add(oSubDirs[nCount].ToString());
                }
                
                pBarSubFolders.Minimum = 0;
                pBarSubFolders.Maximum = oAllSubDirs.Count;
                for (Int32 nSubDirsIndex = 0; nSubDirsIndex < oAllSubDirs.Count; nSubDirsIndex++)
                {
                    lblFilesInProc.Text = "Localizando arquivos em subpasta ";
                    pnlStatusProc.Refresh();
                    String[] pFiles;
                    try
                    {
                        pFiles = Directory.GetFiles(oAllSubDirs[nSubDirsIndex],
                                                             txFileType.Text,
                                                             SearchOption.TopDirectoryOnly);
                    }
                    catch (PathTooLongException oErr)
                    {
                        pBarSubFolders.Increment(1);
                        lblNSubFolders.Text = pBarSubFolders.Value.ToString();
                        lblFilesInProc.Text = "";
                        pnlStatusProc.Refresh();
                        continue;
                    }
                    lblFilesInProc.Text = "Processando " + pFiles.Length.ToString() + " arquivos";
                    pnlStatusProc.Refresh();
                    lbFilename.Text = "";
                    foreach (String pFile in pFiles)
                    {
                        lbFilename.Text = pFile;
                        try
                        {
                            _hashvalue_ = oRSACore.CalcularHash(pFile);
                        }
                        catch (Exception oErr)
                        {
                            ItIsRunning();
                            continue;
                        }
                        oRSAHash.hash = _hashvalue_;
                        if ( oRSAHash.GetRSAHash() == RSAHash.ProcessedStatus.NotFound)
                        {
                            oRSAHash.classification = "<<classificar>>";
                            oRSAHash.friendlyname = Path.GetFileName(pFile);
                            oRSAHash.insertDate = DateTime.Now;
                            oRSAHash.status = RSAHash.ProcessedStatus.NotProcessed;
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
                            if (oRSAHash.status == RSAHash.ProcessedStatus.Processed ||
                                oRSAHash.status == RSAHash.ProcessedStatus.Commmited)
                            {
                                oRSAHash.status = RSAHash.ProcessedStatus.ProcessedPartial;
                                oRSAHash.UpdateMetadata();
                            }

                        }
                        ItIsRunning();
                        //oFile.WriteLine(pFile);
                    }
                    pBarSubFolders.Increment(1);
                    lblNSubFolders.Text = pBarSubFolders.Value.ToString();
                    lblFilesInProc.Text = "";
                    pnlStatusProc.Refresh();
                }
                pBarFolders.Increment(1);
                lblNFolders.Text = pBarFolders.Value.ToString();
                ItIsRunning();
            }
            //oFile.Close();
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
                    String sRSASerialVolume = "";
                    if (!File.Exists(sDrive + @".RSASystems\.RSASerialVolume.idx"))
                    {
                        if (!Directory.Exists(sDrive + @".RSASystems\"))
                        {
                            DirectoryInfo oDirInfo = Directory.CreateDirectory(sDrive + @".RSASystems\");
                            oDirInfo.Attributes = FileAttributes.Hidden;                            
                        }
                        sRSASerialVolume = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).ToUpper();
//                        FileInfo oSerialVolume = new FileInfo(sDrive + @".RSASystems\.RSASerialVolume.idx");
//                        oSerialVolume.CreateText();
//                        oSerialVolume.Attributes = FileAttributes.Hidden;
//                        oSerialVolume = null;
                        StreamWriter oSaveData = new StreamWriter(sDrive + @".RSASystems\.RSASerialVolume.idx");
                        oSaveData.WriteLine(sRSASerialVolume);
                        oSaveData.Close();
                        oRSAVolume.serial = sRSASerialVolume.Trim();
                    }
                    else
                    {
                        StreamReader oReadData = new StreamReader(sDrive + @".RSASystems\.RSASerialVolume.idx");
                        sRSASerialVolume = oReadData.ReadLine();
                        oRSAVolume.serial = sRSASerialVolume.Trim();
                    }
//                    oRSAVolume.serial = oVolumes["VolumeSerialNumber"] == null ? "0000-0000" : oVolumes["VolumeSerialNumber"].ToString();
                    if (oRSAVolume.GetVolume() == RSAVolume.Status.SerialNotFound)
                    {
                        oRSAVolume.type = oVolumes["DriveType"].ToString();
                        oRSAVolume.insertDate = DateTime.Now;
                        oRSAVolume.lastScanningDate = new DateTime();
                        oRSAVolume.AddVolume();
                    }
                    nPosition = cbLogicalDrives.Items.Add(sDrive); // + " => " + oRSAVolume.serial);
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
        private void ItIsRunning()
        {
            if (lblGira.Text == @"|")
            {
                lblGira.Text = @"/";
            }
            else if (lblGira.Text == @"/")
            {
                lblGira.Text = @"\";
            }
            else if (lblGira.Text == @"\")
            {
                lblGira.Text = @"|";
            }
            pnlImportar.Refresh();
        }

        private void btFolderBrowsing_Click(object sender, EventArgs e)
        {
            fldrBrowsing.ShowDialog();
            txForImporting.Text = fldrBrowsing.SelectedPath.Trim();
        }
        private void FillClassification()
        {
            RSAHash oRSAHash = new RSAHash();
            foreach (String sClassification in oRSAHash.GetClassifications())
            {
                cmbClassification.Items.Add(sClassification);
            }
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            if (cmbClassification.Text.ToUpper().Equals("<<CLASSIFICAR>>") ||
                txForImporting.Text.Trim() == "")
            {
                MessageBox.Show("Importação não classificada ou pasta não informada !!\r\nPor favor validar", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ImportFolder();
        }

        private void ImportFolder()
        {
            String sSerialVolume;
            String[] sFiles = Directory.GetFiles(txForImporting.Text,
                                                 txFileTypeForImport.Text,
                                                 SearchOption.TopDirectoryOnly);
            StreamReader oReadData = new StreamReader(Path.GetPathRoot(txForImporting.Text) + @".RSASystems\.RSASerialVolume.idx");
            sSerialVolume = oReadData.ReadLine();

            if (sFiles.Length == 0)
            {
                //TODO: implementar mensagem informando que não há arquivos
                return;
            }
            else
            {
                pbProcessamento.Minimum = 0;
                pbProcessamento.Maximum = sFiles.Length;
                pbProcessamento.Visible = true;

                RSAHash oRSAHash = new RSAHash();
                CheckFolderClassification(oRSACore.StructuredFolder +
                            @"\" +
                            cmbClassification.Text.Trim());
                String sFolderDestination = oRSACore.StructuredFolder +
                                            cmbClassification.Text.Trim() + @"\";
                sSerialVolume = oRSACore.GetSerialVolume(Path.GetPathRoot(txForImporting.Text));
                foreach (String sFileName in sFiles)
                {
                    String sRandomFileName = DateTime.UtcNow.Year.ToString() +  // year
                                             DateTime.UtcNow.Month.ToString() +  // month
                                             DateTime.UtcNow.Day.ToString() +  // day 
                                             DateTime.UtcNow.Hour.ToString() +  // hour
                                             DateTime.UtcNow.Minute.ToString() +  // minute
                                             DateTime.UtcNow.Second.ToString() +  // second
                                             DateTime.UtcNow.Millisecond.ToString() +
                                             Path.GetExtension(sFileName);

                    String sHash = oRSACore.CalcularHash(sFileName);
                    oRSAHash.hash = sHash;
                    if ( oRSAHash.GetRSAHash() == RSAHash.ProcessedStatus.NotFound )
                    {
                        oRSAHash.classification = cmbClassification.Text.Trim().ToUpper();
                        oRSAHash.friendlyname = sRandomFileName;
                        oRSAHash.insertDate = DateTime.Now;
                        oRSAHash.tags = txTagsForImport.Text;
                        RSAPath oRSAPath = new RSAPath();
                        oRSAPath.oldfilename = sFileName;
                        oRSAPath.filename = sFolderDestination + sRandomFileName;
                        oRSAPath.insertDate = DateTime.Now;
                        oRSAPath.volume = sSerialVolume;
                        oRSAHash.paths = new List<RSAPath>();
                        oRSAHash.paths.Add(oRSAPath);
                        oRSAPath.status = RSAPath.Status.Processed;
                        if (!File.Exists(sFolderDestination + sRandomFileName))
                        {
                            try
                            {
                                File.Move(sFileName, sFolderDestination +
                                                     sRandomFileName);
                            }
                            catch (Exception oErr)
                            {
                                //TODO: implementar tratamento de erro para IO Move
                            }
                        }
                        else
                        {
                            try
                            {
                                File.Move(sFileName, sFolderDestination +
                                                     new Random().Next(100).ToString() +
                                                     "_" +
                                                     sRandomFileName);
                            }
                            catch (Exception oErr)
                            {
                                //TODO: implementar tratamento de erro para IO Move
                            }
                        }
                        oRSAHash.status = RSAHash.ProcessedStatus.Processed;
                        oRSAHash.AddHash();
                    }
                    else
                    {
                       // Check if path is already registered
                        Boolean bRegisteredBefore = false;
                        for (Int32 nCount = 0; nCount < oRSAHash.paths.Count; nCount++)
                        {
                            if (oRSAHash.paths[nCount].oldfilename == sFileName ||
                                oRSAHash.paths[nCount].filename == sFileName)
                            {
                                bRegisteredBefore = true;
                                break;
                            }
                        }
                        if (!bRegisteredBefore)
                        {
                            if (oRSAHash.classification != cmbClassification.Text.Trim()) 
                            {
                                oRSAHash.classification = cmbClassification.Text.Trim();
                            }
                            for (Int32 nCount = 0; nCount < oRSAHash.paths.Count; nCount++)
                            {
                                if (oRSAHash.paths[nCount].status == RSAPath.Status.Processed)
                                {
                                    try
                                    {
                                        File.Move(oRSAHash.paths[nCount].filename,
                                                  oRSACore.DuplicatedFolder + sRandomFileName);
                                    }
                                    catch (Exception oErr)
                                    {
                                    }
                                    oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                              oRSAHash.paths[nCount].filename,
                                                              RSAPath.Status.KillIt,
                                                              oRSACore.DuplicatedFolder + sRandomFileName);
                                }
                                else
                                {
                                    oRSAHash.UpdatePathStatus(oRSAHash.hash, 
                                                              oRSAHash.paths[nCount].filename,
                                                              RSAPath.Status.KillIt);
                                }
                            }
                            RSAPath oRSAPath = new RSAPath();
                            oRSAPath.filename = sFolderDestination + sRandomFileName;
                            oRSAPath.oldfilename = sFileName;
                            oRSAPath.insertDate = DateTime.Now;
                            oRSAPath.volume = sSerialVolume;
                            oRSAPath.status = RSAPath.Status.Processed;
                            oRSAHash.AddPath(oRSAPath);
                            try
                            {
                                File.Move(sFileName, sFolderDestination + sRandomFileName);
                            }
                            catch (Exception oErr)
                            {
                            }
                            oRSAHash.status = RSAHash.ProcessedStatus.Processed;
                            oRSAHash.tags = txTagsForImport.Text;
                            oRSAHash.classification = cmbClassification.Text.Trim();
                            oRSAHash.UpdateMetadata();
                        }
                        else
                        {
                            Boolean bHasProcessed = false;
                            for (Int32 nCount = 0; nCount < oRSAHash.paths.Count; nCount++)
                            {
                                if (oRSAHash.paths[nCount].status == RSAPath.Status.Processed)
                                {
                                    bHasProcessed = true;
                                    break;
                                }
                            }
                            if (bHasProcessed)
                            {
                                for (Int32 nCount = 0; nCount < oRSAHash.paths.Count; nCount++)
                                {
                                    if (oRSAHash.paths[nCount].status == RSAPath.Status.Processed)
                                    {
                                        if (oRSAHash.classification != cmbClassification.Text.Trim())
                                        {
                                            File.Move(oRSAHash.paths[nCount].filename,
                                                      oRSACore.DuplicatedFolder + Path.GetFileName(oRSAHash.paths[nCount].filename));
                                            File.Move(sFileName,
                                                      sFolderDestination + sRandomFileName);
                                        }
                                        oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                                  oRSAHash.paths[nCount].filename,
                                                                  RSAPath.Status.Processed,
                                                                  sFolderDestination + sRandomFileName);
                                    }
                                    else
                                    {
                                        oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                                  oRSAHash.paths[nCount].filename,
                                                                  RSAPath.Status.KillIt);
                                    }
                                }
                                oRSAHash.status = RSAHash.ProcessedStatus.Processed;
                                oRSAHash.tags = txTagsForImport.Text;
                                oRSAHash.classification = cmbClassification.Text.Trim();
                                oRSAHash.UpdateMetadata();
                            }
                        }
                    }
                    pbProcessamento.Value++;
                }
                pbProcessamento.Visible = false;
            }
        }

        private void CheckFolderClassification(string pFolder)
        {
            if (!Directory.Exists(pFolder))
            {
                Directory.CreateDirectory(pFolder);
            }
        }

        private void cmbClassification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
