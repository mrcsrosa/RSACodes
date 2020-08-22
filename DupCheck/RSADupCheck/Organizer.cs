using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSACoreLib;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace RSADupCheck
{
    public partial class Organizer : Form
    {
        private RSACore oRSACore;
        private DataTable oRSAHashes = new DataTable();
        private Int32 nCurrentHash;
        private Int32 nCurrentImage;
        private String _metaclassification_;
        private String _metatags_;
        private RSAHash oCurrentRSAHash;       
        public Organizer()
        {
            InitializeComponent();
            oRSACore = RSACore.GetInstance();
            oRSACore.Connect();
            oCurrentRSAHash = new RSAHash();
            LoadHashes();
            FillClassification();
            if (oRSAHashes.Rows.Count > 0)
            {
                nCurrentHash = 0;
                FillRSAHash(nCurrentHash);
                if (oRSAHashes.Rows.Count == 1)
                {
                    btPreviousHash.Enabled = false;
                    btNextHash.Enabled = false;
                }
                else
                {
                    btPreviousHash.Enabled = false;
                    btNextHash.Enabled = true;
                }
                RefreshStatusColor();
            }
            else
            {
                btPreviousHash.Enabled = false;
                btNextHash.Enabled = false;
                btPurgeHash.Enabled = false;
                btMetaUpdate.Enabled = false;
                btProcessarImagem.Enabled = false;
                btRotateRight.Enabled = false;
                btPreviousImage.Enabled = false;
                btNextImage.Enabled = false;
                lbHash.Text = "";
                lblCurrentImage.Text = "";
                lblNumberOfImages.Text = "";
                lblFilename.Text = "";
            }
        }
        private void FillRSAHash(Int32 pRowNumber)
        {
            oCurrentRSAHash.hash = oRSAHashes.Rows[pRowNumber]["_id"].ToString();
            oCurrentRSAHash.GetRSAHash();
            lbHash.Text = oCurrentRSAHash.hash;
            txFriendlyName.Text = oCurrentRSAHash.friendlyname;
            cmbClassification.Text = oCurrentRSAHash.classification;
            txTags.Text = oCurrentRSAHash.tags;
            lblNumberOfImages.Text = oCurrentRSAHash.paths.Count.ToString();
            nCurrentImage = 0;
            lblCurrentImage.Text = (nCurrentImage + 1).ToString();
            pBox.Image = null;
            if (oCurrentRSAHash.paths[nCurrentImage].filename.Contains("<BASEFOLDER>"))
            {
                pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename.Replace("<BASEFOLDER>",                 
                                                                                           oRSACore.BaseFolder);
                lblFilename.Text = oCurrentRSAHash.paths[nCurrentImage].filename.Replace("<BASEFOLDER>",
                                                                                         oRSACore.BaseFolder);
            }
            else
            {
                String strDriveLetter = oRSACore.GetDriveLetterBySerial(oCurrentRSAHash.paths[nCurrentImage].volume);
                pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename;
                lblFilename.Text = oCurrentRSAHash.paths[nCurrentImage].filename;
            }
            pBox.SizeMode = PictureBoxSizeMode.Zoom;

            if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.NotProcessed)
            {
                txProcessStatus.Text = "Não Processado";
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.MetaRevised)
            {
                txProcessStatus.Text = "Revisado";
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial)
            {
                txProcessStatus.Text = "Processado parcial";
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.Processed)
            {
                txProcessStatus.Text = "Processado";
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.Commmited)
            {
                txProcessStatus.Text = "Processado total";
            }
            
            if (oCurrentRSAHash.paths.Count <= 1)
            {
                btNextImage.Enabled = false;
                btPreviousImage.Enabled = false;
            }
            else
            {
                btNextImage.Enabled = true;
                btPreviousImage.Enabled = false;
            }

            if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.Processed ||
                oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial ||
                oCurrentRSAHash.status == RSAHash.ProcessedStatus.Commmited)
            {
                btPurgeHash.Enabled = false;
                btMetaUpdate.Enabled = false;
                if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial)
                {
                    btProcessarImagem.Enabled = true;
                }
                else
                {
                    btProcessarImagem.Enabled = false;
                }
            }
            else
            {
                btPurgeHash.Enabled = true;
                btMetaUpdate.Enabled = true;
                btProcessarImagem.Enabled = true;
            }
            lbNumRecord.Text = (nCurrentHash+1).ToString();
            lbTotalRecord.Text = oRSAHashes.Rows.Count.ToString();
        }
        private void LoadHashes()
        {
            oRSAHashes.Clear();
            oRSAHashes.Columns.Add("hash_id", typeof(String));
            oRSAHashes.Columns.Add("_id", typeof(String));
            oRSAHashes.Columns.Add("contagem", typeof(Int32));
            oRSAHashes.Columns.Add("status", typeof(RSAHash.ProcessedStatus));
            RSAHash oRSAHash = new RSAHash();
            List<RSAHashAggregate> oOrganizer = oRSAHash.GetHashesForOrganizer();
            for (Int32 nCount = 0; nCount < oOrganizer.Count(); nCount++)
            {
                oRSAHashes.Rows.Add(oOrganizer[nCount].hash_id.ToString(),
                                    oOrganizer[nCount]._id.ToString(),
                                    oOrganizer[nCount].contagem.ToString(),
                                    (RSAHash.ProcessedStatus) oOrganizer[nCount].status);
            }
            lbTotalRecord.Text = oOrganizer.Count.ToString();
        }
        private void SetButtonsState()
        {
            if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.NotProcessed)
            {
                btMetaUpdate.Enabled = true;
                btProcessarImagem.Enabled = false;
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.Processed)
            {
                btMetaUpdate.Enabled = false;
                btProcessarImagem.Enabled = false;
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial)
            {
                btMetaUpdate.Enabled = false;
                btProcessarImagem.Enabled = true;
            }
            else
            {
                btMetaUpdate.Enabled = true;
                btProcessarImagem.Enabled = true;
            }
        }
        //private void FillHashList()
        //{
        //    oRSAHashTable = new DataTable();
        //    //oRSAHashBinding = new BindingSource();
        //    oRSAHashTable.Columns.Add("hash_id", typeof(String));
        //    oRSAHashTable.Columns.Add("_id", typeof(String));
        //    oRSAHashTable.Columns.Add("contagem", typeof(Int32));
        //    oRSAHashTable.Columns.Add("status", typeof(RSAHash.ProcessedStatus));
        //    RSAHash oRSAHash = new RSAHash();
        //    List<RSAHashAggregate> oForOrganizer = oRSAHash.GetHashesForOrganizer();
        //    dgHashes.Rows.Clear();
        //    for (Int32 nCount = 0; nCount < oForOrganizer.Count(); nCount++)
        //    {
        //        oRSAHash.hash = oForOrganizer[nCount]._id.ToString();
        //        oRSAHash.GetRSAHash();
        //        oRSAHashTable.Rows.Add(oForOrganizer[nCount].hash_id.ToString(),
        //                               oForOrganizer[nCount]._id.ToString(),
        //                               oForOrganizer[nCount].contagem.ToString(),
        //                               oRSAHash.status);
        //        //dgHashes.Rows.Add(oForOrganizer[nCount].hash_id.ToString(),
        //        //                  oForOrganizer[nCount]._id.ToString(),
        //        //                  oForOrganizer[nCount].contagem.ToString());
        //    }
        //    //for (Int32 nCount = 0; nCount< oRSAHashTable.Rows.Count; nCount++)
        //    //{
        //    //    RSAHash _RSAHash = new RSAHash();
        //    //    _RSAHash.hash = oRSAHashTable.Rows[nCount]["_id"].ToString();
        //    //    _RSAHash.GetRSAHash();
        //    //    oRSAHashTable.Rows[nCount]["status"] = _RSAHash.status;
        //    //}
        //    //oRSAHashBinding.DataSource = oRSAHashTable;
        //    dgHashes.Columns.Clear();
        //    //dgHashes.DataSource = oRSAHashBinding;
        //    RefreshHashView();
        //}
        private void btRotateRight_Click(object sender, EventArgs e)
        {
            //System.Windows.Media.Imaging.JpegBitmapDecoder oJpeg = new System.Windows.Media.Imaging.JpegBitmapDecoder(new Uri(pBox.ImageLocation.ToString(), false),
            //System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);
            //BitmapSource oSource = oJpeg.Frames[0];
            //BitmapMetadata oMeta = new BitmapMetadata("jpg");
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pBox.Image = oImagem;
        }
        private void btMetaUpdate_Click(object sender, EventArgs e)
        {
            //_metaclassification_ = txClassification.Text;
            _metaclassification_ = cmbClassification.Text.Trim();
            _metatags_ = txTags.Text;
            //txClassification.Enabled = true;
            cmbClassification.Enabled = true;
            txTags.Enabled = true;
            btMetaUpdate.Enabled = false;
            btMetaSave.Enabled = true;
            btMetaCancel.Enabled = true;
            btProcessarImagem.Enabled = false;
        }
        private void btMetaSave_Click(object sender, EventArgs e)
        {
            //SaveMetaData(txClassification.Text, txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.MetaRevised);
            SaveMetaData(cmbClassification.Text.Trim(), txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.MetaRevised);
            oRSAHashes.Rows[nCurrentHash]["status"] = RSAHash.ProcessedStatus.MetaRevised;

            RefreshClassification();
            RefreshStatusColor();
            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btMetaUpdate.Enabled = true;
            cmbClassification.Enabled = false;
            btProcessarImagem.Enabled = true;
            txTags.Enabled = false;
        }
        private void RefreshClassification()
        {
            String tmpClassification = cmbClassification.Text.Trim();
            if (!cmbClassification.Items.Contains(cmbClassification.Text.Trim()))
            {
                cmbClassification.Items.Add(cmbClassification.Text.Trim());
            }
        }
        private void SaveMetaData(String pClassification, String pFriendlyName, String pTags, RSAHash.ProcessedStatus pStatus)
        {
            oCurrentRSAHash.classification = pClassification;
            oCurrentRSAHash.friendlyname = pFriendlyName;
            oCurrentRSAHash.tags = pTags;
            oCurrentRSAHash.status = pStatus;
            oCurrentRSAHash.UpdateMetadata();
        }
        private void RefreshStatusColor()
        {
            if ((RSAHash.ProcessedStatus) oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.MetaRevised)
            {
                txProcessStatus.Text = "Revisado";
                txProcessStatus.BackColor = Color.Gold;
            }
            else if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.NotProcessed)
            {
                txProcessStatus.Text = "Não revisado";
                txProcessStatus.BackColor = Color.White;
            }
            else if ((RSAHash.ProcessedStatus) oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.ProcessedPartial)
            {
                txProcessStatus.Text = "Processado - Parcial";
                txProcessStatus.BackColor = Color.Aquamarine;
            }
            else if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.Processed)
            {
                txProcessStatus.Text = "Processado";
                txProcessStatus.BackColor = Color.GreenYellow;
            }
        }
        private void btMetaCancel_Click(object sender, EventArgs e)
        {
            //txClassification.Text = _metaclassification_;
            cmbClassification.Text = _metaclassification_;
            txTags.Text = _metatags_;
            cmbClassification.Enabled = false;
            txTags.Enabled = false;

            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btMetaUpdate.Enabled = true;
            btProcessarImagem.Enabled = true;
        }
        private void btRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btProcessarImagem_Click(object sender, EventArgs e)
        {
            if (cmbClassification.Text.ToUpper() == "<<CLASSIFICAR>>")
            {
                MessageBox.Show("Existe imagem sem análise, por favor revisar !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            Boolean bPreviousProcessed;
            String sRandomFileName = DateTime.UtcNow.Year.ToString() +  // year
                         DateTime.UtcNow.Month.ToString() +  // month
                         DateTime.UtcNow.Day.ToString() +  // day 
                         DateTime.UtcNow.Hour.ToString() +  // hour
                         DateTime.UtcNow.Minute.ToString() +  // minute
                         DateTime.UtcNow.Second.ToString() +  // second
                         DateTime.UtcNow.Millisecond.ToString();
            if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial)
            {
                bPreviousProcessed = true;
            }
            else
            {
                bPreviousProcessed = false;
            }
            oRSAHash.hash = oCurrentRSAHash.hash;
            for (Int32 nCount = 0; nCount < oCurrentRSAHash.paths.Count; nCount++)
            {
                if (oCurrentRSAHash.paths[nCount].status != RSAPath.Status.Killed &&
                    oCurrentRSAHash.paths[nCount].status != RSAPath.Status.KillIt &&
                    oCurrentRSAHash.paths[nCount].status != RSAPath.Status.Processed)
                {
                    if (nCount == 0)
                    {
                        try
                        {
                            if (!Directory.Exists(oRSACore.StructuredFolder + cmbClassification.Text.Trim()))
                            {
                                Directory.CreateDirectory(oRSACore.StructuredFolder + cmbClassification.Text.Trim());
                            }
                            File.Move(oCurrentRSAHash.paths[0].filename.Trim(),
                                      oRSACore.StructuredFolder +
                                      cmbClassification.Text.Trim() +
                                      @"\" + sRandomFileName +
                                      Path.GetExtension(oCurrentRSAHash.paths[0].filename.Trim()));
                        }
                        catch (FileNotFoundException oErr)
                        {
                        }
                        catch (Exception oErr)
                        {
                            File.Move(oCurrentRSAHash.paths[0].filename.Trim(),
                                      oRSACore.StructuredFolder +
                                      cmbClassification.Text.Trim() +
                                      @"\" + sRandomFileName +
                                      Path.GetExtension(oCurrentRSAHash.paths[0].filename.Trim()));
                        }
                        oRSAHash.classification = oCurrentRSAHash.classification;
                        oRSAHash.friendlyname = oCurrentRSAHash.friendlyname;
                        oRSAHash.tags = oCurrentRSAHash.tags;
                        oRSAPath.filename = oCurrentRSAHash.paths[0].filename.Trim();
                        if (bPreviousProcessed)
                        {
                            oRSAPath.status = RSAPath.Status.KillIt;
                        }
                        else
                        {
                            oRSAPath.status = RSAPath.Status.Processed;
                        }
                        oRSAHash.paths = null;
                        oRSAHash.paths = new List<RSAPath>();
                        oRSAHash.paths.Add(oRSAPath);

                        oRSAHash.UpdatePathStatus(oRSACore.StructuredFolder +
                                                  cmbClassification.Text.Trim() + @"\" +
                                                  sRandomFileName +
                                                  Path.GetExtension(oCurrentRSAHash.paths[0].filename.Trim()));
                        oRSAHash.friendlyname = sRandomFileName +
                                                Path.GetExtension(oCurrentRSAHash.paths[0].filename.Trim());
                        txFriendlyName.Text = sRandomFileName +
                                              Path.GetExtension(oCurrentRSAHash.paths[0].filename.Trim());
                        oRSAHash.UpdateMetadata();
                        oCurrentRSAHash.friendlyname = sRandomFileName +
                                                       Path.GetExtension(oCurrentRSAHash.paths[0].filename.Trim());
                        if (bPreviousProcessed)
                        {
                            oCurrentRSAHash.paths[0].status = RSAPath.Status.KillIt;
                        }
                        else
                        {
                            oCurrentRSAHash.paths[0].status = RSAPath.Status.Processed;
                        }
                        oRSAHashes.Rows[nCurrentHash]["status"] = RSAPath.Status.Processed;
                    }
                    else
                    {
                        if ((RSAPath.Status)oCurrentRSAHash.paths[nCount].status != RSAPath.Status.Processed ||
                            (RSAPath.Status)oCurrentRSAHash.paths[nCount].status != RSAPath.Status.KillIt ||
                            (RSAPath.Status)oCurrentRSAHash.paths[nCount].status != RSAPath.Status.Killed)
                        {
                            try
                            {
                                File.Move(oCurrentRSAHash.paths[nCount].filename.Trim(),
                                          oRSACore.DuplicatedFolder +
                                          sRandomFileName +
                                          Path.GetExtension(oCurrentRSAHash.paths[nCount].filename.Trim()));
                            }
                            catch(FileNotFoundException oErr)
                            {

                            }
                            catch (Exception oErr)
                            {
                                sRandomFileName = sRandomFileName + "_" + nCount.ToString();
                                File.Move(oCurrentRSAHash.paths[nCount].filename.Trim(),
                                          oRSACore.DuplicatedFolder +
                                          sRandomFileName +
                                          Path.GetExtension(oCurrentRSAHash.paths[nCount].filename.Trim()));
                            }
                            oRSAPath.filename = oCurrentRSAHash.paths[nCount].filename.Trim();
                            oRSAPath.status = RSAPath.Status.KillIt;
                            oRSAHash.paths = null;
                            oRSAHash.paths = new List<RSAPath>();
                            oRSAHash.paths.Add(oRSAPath);

                            oRSAHash.UpdatePathStatus(@"<BASEFOLDER>\Duplicated\" +
                                                      sRandomFileName +
                                                      Path.GetExtension(oCurrentRSAHash.paths[nCount].filename.Trim()));
                        }
                    }
                }
            }
            SaveMetaData(cmbClassification.Text.Trim(), txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.Processed);
            oRSAHashes.Rows[nCurrentHash]["status"] = RSAHash.ProcessedStatus.Processed;
            FillRSAHash(nCurrentHash);
            RefreshStatusColor();
            SetButtonsState();
        }
        private void ckAddProcessed_EnabledChanged(object sender, EventArgs e)
        {
            if (!ckAddProcessed.Checked)
            {
                //oRSAHashBinding.Filter = " status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Processed).ToString() +
                //                         " and status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Commmited).ToString();
            }
            else
            {
                //oRSAHashBinding.Filter = " status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Processed).ToString() +
                //                         " and status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Commmited).ToString();
            }
        }
        private void ckAddProcessed_CheckStateChanged(object sender, EventArgs e)
        {
            RefreshHashView();
        }
        private void RefreshHashView()
        {
            if (!ckAddProcessed.Checked)
            {
                //oRSAHashBinding.Filter = " status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Processed).ToString() +
                //                         " and status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Commmited).ToString();
            }
            else
            {
                //oRSAHashBinding.Filter = "";
            }
        }
        private void btPurgeHash_Click(object sender, EventArgs e)
        {
            if (oCurrentRSAHash.status != RSAHash.ProcessedStatus.Processed &&
                oCurrentRSAHash.status != RSAHash.ProcessedStatus.Commmited &&
                oCurrentRSAHash.status != RSAHash.ProcessedStatus.ProcessedPartial)
            {
                for (Int32 nCount = 0; nCount < oCurrentRSAHash.paths.Count; nCount++)
                {
                    try
                    {
                        File.Delete(oCurrentRSAHash.paths[nCount].filename);
                    }
                    catch (IOException oErr)
                    {

                    }
                }
                oCurrentRSAHash.Delete(oCurrentRSAHash.hash);
                oRSAHashes.Rows[nCurrentHash].Delete();
                if (oRSAHashes.Rows.Count > 0)
                {
                    if (nCurrentHash > 0)
                    {
                        nCurrentHash--;
                    }
                    FillRSAHash(nCurrentHash);
                    RefreshStatusColor();
                    //btPurgeHash.Enabled = true;
                }
                else
                {
                    btPreviousHash.Enabled = false;
                    btNextHash.Enabled = false;
                    btPurgeHash.Enabled = false;
                    btMetaUpdate.Enabled = false;
                    btProcessarImagem.Enabled = false;
                    btRotateRight.Enabled = false;
                    btPreviousImage.Enabled = false;
                    btNextImage.Enabled = false;
                    lbHash.Text = "";
                    lblCurrentImage.Text = "";
                    lblNumberOfImages.Text = "";
                    lblFilename.Text = "";
                    cmbClassification.Text = "";
                    txProcessStatus.Text = "";
                    txFriendlyName.Text = "";
                    btPurgeHash.Enabled = false;
                    pBox.Image = null;
                    pBox.ImageLocation = "";
                }
                if (oRSAHashes.Rows.Count <2)
                {
                    btPreviousHash.Enabled = false;
                    btNextHash.Enabled = false;
                }
            }

            return;
        }
        private void FillClassification()
        {
            RSAHash oRSAHash = new RSAHash();
            foreach (String sClassification in oRSAHash.GetClassifications())
            {
                cmbClassification.Items.Add(sClassification);
            }
        }
        private void cmbClassification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        private void btPreviousHash_Click(object sender, EventArgs e)
        {
            if (nCurrentHash > 0) nCurrentHash--;
            FillRSAHash(nCurrentHash);
            if (nCurrentHash == 0)
            {
                btNextHash.Enabled = true;
                btPreviousHash.Enabled = false;
            }
            else
            {
                btNextHash.Enabled = true;
                btPreviousHash.Enabled = true;
            }
            RefreshStatusColor();
        }
        private void btNextHash_Click(object sender, EventArgs e)
        {
            if (oRSAHashes.Rows.Count > 1) nCurrentHash++;
            FillRSAHash(nCurrentHash);
            if (nCurrentHash == oRSAHashes.Rows.Count - 1)
            {
                btNextHash.Enabled = false;
                btPreviousHash.Enabled = true;
            }
            else
            {
                btNextHash.Enabled = true;
                btPreviousHash.Enabled = true;
            }
            RefreshStatusColor();
        }
        private void btPreviousImage_Click(object sender, EventArgs e)
        {
            nCurrentImage--;
            lblCurrentImage.Text = (nCurrentImage + 1).ToString();
            pBox.Image = null;
            if (oCurrentRSAHash.paths[nCurrentImage].filename.Contains("<BASEFOLDER>"))
            {
                pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename.Replace("<BASEFOLDER>",
                                                                                           oRSACore.BaseFolder);
                lblFilename.Text = oCurrentRSAHash.paths[nCurrentImage].filename.Replace("<BASEFOLDER>",
                                                                                         oRSACore.BaseFolder);
            }
            else
            {
                pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename;
                lblFilename.Text = oCurrentRSAHash.paths[nCurrentImage].filename;
            }
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (nCurrentImage == 0)
            {
                btNextImage.Enabled = true;
                btPreviousImage.Enabled = false;
            }
            else
            {
                btNextImage.Enabled = true;
                btPreviousImage.Enabled = true;
            }
        }
        private void btNextImage_Click(object sender, EventArgs e)
        {
            nCurrentImage++;
            lblCurrentImage.Text = (nCurrentImage + 1).ToString();
            pBox.Image = null;
            if (oCurrentRSAHash.paths[nCurrentImage].filename.Contains("<BASEFOLDER>"))
            {
                pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename.Replace("<BASEFOLDER>",
                                                                                           oRSACore.BaseFolder);
                lblFilename.Text = oCurrentRSAHash.paths[nCurrentImage].filename.Replace("<BASEFOLDER>",
                                                                                         oRSACore.BaseFolder);
            }
            else
            {
                pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename;
                lblFilename.Text = oCurrentRSAHash.paths[nCurrentImage].filename;
            }
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (nCurrentImage == (oCurrentRSAHash.paths.Count - 1))
            {
                btNextImage.Enabled = false;
                btPreviousImage.Enabled = true;
            }
            else
            {
                btNextImage.Enabled = true;
                btPreviousImage.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            for (Int32 nCount = 0; nCount < oRSAHashes.Rows.Count; nCount++ )
            {
                oRSAHash.hash = oRSAHashes.Rows[nCount]["_id"].ToString();
                oRSAHash.GetRSAHash();
                if (nCount > 10000)
                {
                    String x = "";
                }
                Boolean bFind = false;
                foreach (RSAPath oRSAPath in oRSAHash.paths)
                {
                    if (oRSAPath.filename.Contains("<BASEFOLDER>"))
                    {
                        if (File.Exists(oRSAPath.filename.Replace("<BASEFOLDER>",
                                                                  oRSACore.BaseFolder)))
                        {
                            bFind = true;
                        }
                        else
                        {
                            oRSAHash.Delete(oRSAHash.hash, oRSAPath.volume, oRSAPath.filename);
                        }
                    }
                    else
                    {
                        if (File.Exists(oRSAPath.filename))
                        {
                            bFind = true;
                        }
                        else
                        {
                            oRSAHash.Delete(oRSAHash.hash, oRSAPath.volume, oRSAPath.filename);
                        }
                    }
                }
                if (!bFind)
                {
                    oRSAHash.Delete(oRSAHash.hash);
                }
            }
            return;
            //RSAHash oRSAHash = new RSAHash();

            for (Int32 nCnt = 0; nCnt < oRSAHashes.Rows.Count; nCnt++)
            {
                oCurrentRSAHash.hash = oRSAHashes.Rows[nCnt]["_id"].ToString();
                oCurrentRSAHash.GetRSAHash();
                foreach(RSAPath oPath in oCurrentRSAHash.paths)
                {
                    if (oPath.status == (RSAPath.Status)4)
                    {
                        String sFile = oPath.filename.Substring(12);
                    }
                    else if (oPath.status == (RSAPath.Status)17)
                    {
                        String sFile = oPath.filename.Substring(12);
                    }
                }
            }
        }
    }
}