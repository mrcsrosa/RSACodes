using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.Configuration;
using RSACoreLib;
using System.Management;
using System.Collections;
namespace RSADupCheck
{
    public partial class Scan : Form
    {
        //StreamWriter oFile;
        private RSACore oRSACore;
        private Hashtable _hashSerialVolume = new Hashtable();
        private String strFileTypemask;
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
        private void FillClassification()
        {
            RSAHash oRSAHash = new RSAHash();
            cmbClassification.Items.Clear();
            foreach (String strClassification in oRSAHash.GetClassifications())
            {
                cmbClassification.Items.Add(strClassification);
            }
            oRSAHash = null;
        }
        private void FillLogicalDrives()
        {
            _hashSerialVolume.Clear();
            Int32 nPosition;
            String[] strArrayDrives = Directory.GetLogicalDrives();
            ManagementObject oVolumes = null;
            RSAVolume oRSAVolume = new RSAVolume();
            foreach (String strDrive in strArrayDrives)
            {
                // 2 - Removable Disk
                // 3 - Local Disk
                // 4 - Network Drive
                // 5 - Compact Disk
                oVolumes = new ManagementObject("win32_logicaldisk.deviceid=\"" +
                                                strDrive.Substring(0, 2) +
                                                "\"");
                oVolumes.Get();
                if (Convert.ToInt32(oVolumes["DriveType"]) >= 2 &&
                    Convert.ToInt32(oVolumes["DriveType"]) <= 4)
                {
                    String sRSASerialVolume = "";
                    if (!File.Exists(strDrive + @".RSASystems\.RSASerialVolume.idx"))
                    {
                        if (!Directory.Exists(strDrive + @".RSASystems\"))
                        {
                            DirectoryInfo oDirInfo = Directory.CreateDirectory(strDrive + @".RSASystems\");
                            oDirInfo.Attributes = FileAttributes.Hidden;
                        }
                        sRSASerialVolume = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).ToUpper();
                        StreamWriter oSaveData = new StreamWriter(strDrive + @".RSASystems\.RSASerialVolume.idx");
                        oSaveData.WriteLine(sRSASerialVolume);
                        oSaveData.Close();
                        oRSAVolume.serial = sRSASerialVolume.Trim();
                    }
                    else
                    {
                        StreamReader oReadData = new StreamReader(strDrive + @".RSASystems\.RSASerialVolume.idx");
                        sRSASerialVolume = oReadData.ReadLine();
                        oRSAVolume.serial = sRSASerialVolume.Trim();
                    }
                    if (oRSAVolume.GetVolume() == RSAVolume.Status.SerialNotFound)
                    {
                        oRSAVolume.type = oVolumes["DriveType"].ToString();
                        oRSAVolume.insertDate = DateTime.Now;
                        oRSAVolume.lastScanningDate = new DateTime();
                        oRSAVolume.AddVolume();
                    }
                    nPosition = cbLogicalDrives.Items.Add(strDrive); // + " => " + oRSAVolume.serial);
                    _hashSerialVolume.Add(nPosition, oRSAVolume.serial);
                }
            }
            strArrayDrives = null;
            oVolumes = null;
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
                else if (sFolder.ToUpper() == _syspaths_["ALLUSERSPROFILE"].ToString().ToUpper())
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
            String strMimeType = "";
            if (txFileType.Text.ToUpper().Contains("*.JPG") ||
                txFileType.Text.ToUpper().Contains("*.JPEG"))
            {
                strMimeType = @"image/jpeg";
            }
            else if (txFileType.Text.ToUpper().Contains("*.MP4"))
            {
                strMimeType = @"video/mp4";
            }
            else if (txFileType.Text.ToUpper().Contains("*.PDF"))
            {
                strMimeType = @"application/pdf";
            }
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
                        if (strMimeType == "video/mp4")
                        {
                            FileInfo oFileInfo = new FileInfo(pFile);
                            if (oFileInfo.Length > (300*1024000))
                            {
                                oFileInfo = null;
                                continue;
                            }
                            oFileInfo = null;
                        }

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
                            oRSAHash.mimetype = strMimeType;
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
        private void btImportar_Click(object sender, EventArgs e)
        {
            if (cmbClassification.Text.ToUpper().Equals("<<CLASSIFICAR>>") ||
                txForImporting.Text.Trim() == "")
            {
                MessageBox.Show("Importação não classificada ou pasta não informada !!\r\nPor favor validar", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            strFileTypemask = cmbClassification.Text.ToUpper().Trim();
            ImportFolder();
            FillClassification();
        }
        private void ImportFolder()
        {
            String sSerialVolume;
            List<String> sFiles = new List<String>();
            String[] arrayFileType = txFileTypeForImport.Text.Split(';');
            foreach (String sFilterType in arrayFileType)
            {
                sFiles.AddRange(Directory.GetFiles(txForImporting.Text,
                                          sFilterType,
                                          SearchOption.TopDirectoryOnly).ToList());
            }
            StreamReader oReadData = new StreamReader(Path.GetPathRoot(txForImporting.Text) + @".RSASystems\.RSASerialVolume.idx");
            sSerialVolume = oReadData.ReadLine();
            if (sFiles.Count == 0)
            {
                //TODO: implementar mensagem informando que não há arquivos
                return;
            }
            else
            {
                String strMimeType = "";
                if (txFileTypeForImport.Text.ToUpper().Contains("*.JPG") ||
                    txFileTypeForImport.Text.ToUpper().Contains("*.JPEG"))
                {
                    strMimeType = @"image/jpeg";
                }
                else if (txFileTypeForImport.Text.ToUpper().Contains("*.MP4"))
                {
                    strMimeType = @"video/mp4";
                }
                else if (txFileTypeForImport.Text.ToUpper().Contains("*.PDF"))
                {
                    strMimeType = @"application/pdf";
                }

                pbProcessamento.Minimum = 0;
                pbProcessamento.Maximum = sFiles.Count;
                pbProcessamento.Value = 0;
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
                        oRSAHash.mimetype = strMimeType;
                        oRSAHash.insertDate = DateTime.Now;
                        oRSAHash.tags = txTagsForImport.Text;
                        RSAPath oRSAPath = new RSAPath();
                        oRSAPath.oldfilename = sFileName;
                        oRSAPath.filename = @"<BASEFOLDER>\Structured\" + 
                                            cmbClassification.Text.Trim() +
                                            @"\" +
                                            sRandomFileName;
                        oRSAPath.insertDate = DateTime.Now;
                        oRSAPath.volume = sSerialVolume;
                        try
                        {
                            File.Move(sFileName, sFolderDestination +
                                                 sRandomFileName);
                        }
                        catch (Exception oErr)
                        {
                            //TODO: implementar tratamento de erro para IO Move
                        }
                        oRSAHash.paths = new List<RSAPath>();
                        oRSAHash.paths.Add(oRSAPath);
                        oRSAPath.status = RSAPath.Status.Processed;
                        oRSAHash.status = RSAHash.ProcessedStatus.Processed;
                        oRSAHash.AddHash();
                    }
                    else
                    {
                        // TOPTOPTOPTOP
                        for (Int32 nCount = 0; nCount < oRSAHash.paths.Count; nCount++)
                        {
                            String[] arrayFileParts = oRSAHash.paths[nCount].filename.Split('\\');
                            String sFile = arrayFileParts[arrayFileParts.Length - 1];
                            if (oRSAHash.paths[nCount].status == RSAPath.Status.Processed)
                            {
                                try
                                {
                                    File.Move(oRSAHash.paths[nCount].filename.Replace(@"<BASEFOLDER>",
                                                                                      oRSACore.BaseFolder),
                                              oRSACore.DuplicatedFolder +
                                              sFile);
                                }
                                catch (Exception oErr)
                                {
                                    sFile = DateTime.Now.Millisecond.ToString().Trim() + sFile;
                                    File.Move(oRSAHash.paths[nCount].filename.Replace(@"<BASEFOLDER>",
                                                                                      oRSACore.BaseFolder),
                                              oRSACore.DuplicatedFolder +
                                              sFile);
                                }
                                oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                          oRSAHash.paths[nCount].filename,
                                                          RSAPath.Status.KillIt,
                                                          @"<BASEFOLDER>\Duplicated\" + sFile);
                            }
                            else
                            {
                                oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                          oRSAHash.paths[nCount].filename,
                                                          RSAPath.Status.KillIt);
                            }
                        }
                        RSAPath oRSAPath = new RSAPath();
                        oRSAPath.filename = @"<BASEFOLDER>\Structured\" +
                                            cmbClassification.Text.Trim() +
                                            @"\" +
                                            sRandomFileName;
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
