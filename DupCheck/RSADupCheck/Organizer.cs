using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSACoreLib;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data;

namespace RSADupCheck
{
    public partial class Organizer : Form
    {
        private RSACore oRSACore;
        private String _metaclassification_;
        private String _metatags_;
        private RSAHash oCurrentRSAHash;
        private DataTable oRSAHashTable;
        private BindingSource oRSAHashBinding;
        public Organizer()
        {
            InitializeComponent();
            oRSACore = RSACore.GetInstance();
            oRSACore.Connect();
            oCurrentRSAHash = new RSAHash();
            dgFiles.Columns["filename"].Width = 315;
            dgFiles.Columns["volume"].Width = 65;
            dgFiles.Columns["status"].Width = 85;
            FillHashList();
            FillClassification();
            if (dgHashes.Rows.Count > 0) dgHashes.CurrentCell = dgHashes[0, 0];
            btPreviousHash.Enabled = false;
            btNextHash.Enabled = true;
        }

        private void SetButtonsState()
        {
            if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.NotProcessed)
            {
                btMetaUpdate.Enabled = true;
                btManterImagem.Enabled = true;
                btCancelaImagem.Enabled = true;
                btProcessarImagem.Enabled = false;
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.Processed)
            {
                btMetaUpdate.Enabled = false;
                btManterImagem.Enabled = false;
                btCancelaImagem.Enabled = false;
                btProcessarImagem.Enabled = false;
            }
            else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial)
            {
                btMetaUpdate.Enabled = false;
                btManterImagem.Enabled = false;
                btCancelaImagem.Enabled = true;
                btProcessarImagem.Enabled = true;
            }
            else
            {
                btMetaUpdate.Enabled = true;
                btManterImagem.Enabled = true;
                btCancelaImagem.Enabled = true;
                btProcessarImagem.Enabled = true;
            }
        }
        private void FillFileList(String pHash, Int32 pPos)
        {
            txFriendlyName.Text = oCurrentRSAHash.friendlyname;
            //txClassification.Text = oCurrentRSAHash.classification;
            cmbClassification.Text = oCurrentRSAHash.classification;
            txTags.Text = oCurrentRSAHash.tags;
            dgFiles.Rows.Clear();
            foreach (RSAPath oPath in oCurrentRSAHash.paths)
            {
                Int32 nPos = dgFiles.Rows.Add(oPath.filename.ToString(),
                                                oPath.volume.ToString(),
                                                oPath.status
                        );
            }
            lblCurrentImage.Text = "1";
            lblNumberOfImages.Text = dgFiles.Rows.Count.ToString();
            btPreviousImage.Enabled = false;
            btNextImage.Enabled = true;
            lblFilename.Text = dgFiles.Rows[0].Cells["filename"].FormattedValue.ToString();
        }
        private void FillHashList()
        {
            oRSAHashTable = new DataTable();
            oRSAHashBinding = new BindingSource();
            oRSAHashTable.Columns.Add("hash_id", typeof(String));
            oRSAHashTable.Columns.Add("_id", typeof(String));
            oRSAHashTable.Columns.Add("contagem", typeof(Int32));
            oRSAHashTable.Columns.Add("status", typeof(RSAHash.ProcessedStatus));
            RSAHash oRSAHash = new RSAHash();
            List<RSAHashAggregate> oForOrganizer = oRSAHash.GetHashesForOrganizer();
            dgHashes.Rows.Clear();
            for (Int32 nCount = 0; nCount < oForOrganizer.Count(); nCount++)
            {
                oRSAHash.hash = oForOrganizer[nCount]._id.ToString();
                oRSAHash.GetRSAHash();
                oRSAHashTable.Rows.Add(oForOrganizer[nCount].hash_id.ToString(),
                                       oForOrganizer[nCount]._id.ToString(),
                                       oForOrganizer[nCount].contagem.ToString(),
                                       oRSAHash.status);
                //dgHashes.Rows.Add(oForOrganizer[nCount].hash_id.ToString(),
                //                  oForOrganizer[nCount]._id.ToString(),
                //                  oForOrganizer[nCount].contagem.ToString());
            }
            //for (Int32 nCount = 0; nCount< oRSAHashTable.Rows.Count; nCount++)
            //{
            //    RSAHash _RSAHash = new RSAHash();
            //    _RSAHash.hash = oRSAHashTable.Rows[nCount]["_id"].ToString();
            //    _RSAHash.GetRSAHash();
            //    oRSAHashTable.Rows[nCount]["status"] = _RSAHash.status;
            //}
            oRSAHashBinding.DataSource = oRSAHashTable;
            dgHashes.Columns.Clear();
            dgHashes.DataSource = oRSAHashBinding;
            RefreshHashView();
        }
        private void dgHashes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgHashes.Rows.Count > 0)
            {
                oCurrentRSAHash.hash = dgHashes.Rows[e.RowIndex].Cells["_id"].Value.ToString();
                RSAHash.ProcessedStatus oRetCod = oCurrentRSAHash.GetRSAHash();
                FillFileList(oCurrentRSAHash.hash, e.RowIndex);
                if (dgHashes.CurrentCell != null)
                {
                    if (e.RowIndex == dgHashes.Rows.GetFirstRow(dgHashes.CurrentCell.State))
                    {
                        btPreviousHash.Enabled = false;
                        btNextHash.Enabled = true;
                    }
                    else if (e.RowIndex == dgHashes.Rows.GetLastRow(dgHashes.CurrentCell.State))
                    {
                        btPreviousHash.Enabled = true;
                        btNextHash.Enabled = false;
                    }
                    else
                    {
                        btPreviousHash.Enabled = true;
                        btNextHash.Enabled = true;
                    }
                }
                lbHash.Text = oCurrentRSAHash.hash;
                SetButtonsState();
                RefreshStatusColor();
            }
        }
        private void dgFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (oCurrentRSAHash.status != RSAHash.ProcessedStatus.ProcessedPartial)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() ==
                        RSAPath.Status.ForDeletion.ToString())
                    {
                        btCancelaImagem.Text = "Recuperar Imagem";
                    }
                    else
                    {
                        btCancelaImagem.Text = "Excluir Imagem";
                    }
                    if (dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() ==
                        RSAPath.Status.ForProcesssing.ToString())
                    {
                        btManterImagem.Text = "Reverter";
                    }
                    else
                    {
                        btManterImagem.Text = "Manter Imagem";
                    }
                    pBox.Image = null;
                    pBox.ImageLocation = dgFiles.Rows[e.RowIndex].Cells["filename"].Value.ToString();
                    pBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                if (dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.KillIt.ToString() ||
                    dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.Killed.ToString() ||
                    dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.Processed.ToString())
                {
                    btCancelaImagem.Enabled = false;
                    btCancelaImagem.Text = "Excluir Imagem";
                }
                else
                {
                    if (dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.ForDeletion.ToString())
                    {
                        btCancelaImagem.Text = "Recuperar Imagem";
                    }
                    else
                    {
                        btCancelaImagem.Text = "Excluir Imagem";
                    }
                    btCancelaImagem.Enabled = true;
                }
                pBox.Image = null;
                pBox.ImageLocation = dgFiles.Rows[e.RowIndex].Cells["filename"].Value.ToString();
                pBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void btRotateLeft_Click(object sender, EventArgs e)
        {
            //System.Windows.Media.Imaging.JpegBitmapDecoder oJpeg = new System.Windows.Media.Imaging.JpegBitmapDecoder(new Uri(pBox.ImageLocation.ToString(), false),
            //        System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);
            //BitmapSource oSource = oJpeg.Frames[0];
            //BitmapMetadata oMeta = new BitmapMetadata("jpg");
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pBox.Image = oImagem;
        }
        private void btRotateRight_Click(object sender, EventArgs e)
        {
            //System.Windows.Media.Imaging.JpegBitmapDecoder oJpeg = new System.Windows.Media.Imaging.JpegBitmapDecoder(new Uri(pBox.ImageLocation.ToString(), false),
            //System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);
            //BitmapSource oSource = oJpeg.Frames[0];
            //BitmapMetadata oMeta = new BitmapMetadata("jpg");
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipX);
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
            btCancelaImagem.Enabled = false;
            btProcessarImagem.Enabled = false;
            btManterImagem.Enabled = false;
            btMetaSave.Enabled = true;
            btMetaCancel.Enabled = true;
            SetButtonsState();
        }
        private void btMetaSave_Click(object sender, EventArgs e)
        {
            //SaveMetaData(txClassification.Text, txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.MetaRevised);
            SaveMetaData(cmbClassification.Text.Trim(), txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.MetaRevised) ;
            RefreshClassification();
            RefreshStatusColor();
            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btCancelaImagem.Enabled = true;
            btMetaUpdate.Enabled = true;
            btProcessarImagem.Enabled = true;
            btManterImagem.Enabled = true;
            //txClassification.Enabled = false;
            cmbClassification.Enabled = false;
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
            if (dgHashes.CurrentCell != null)
            {
                //oCurrentRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
                //oCurrentRSAHash.GetRSAHash();
                if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.MetaRevised)
                {
                    txProcessStatus.Text = "Revisado";
                    txProcessStatus.BackColor = Color.Gold;
                }
                else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.NotProcessed)
                {
                    txProcessStatus.Text = "Não revisado";
                    txProcessStatus.BackColor = Color.White;
                }
                else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.ProcessedPartial)
                {
                    txProcessStatus.Text = "Processado - Parcial";
                    txProcessStatus.BackColor = Color.Aquamarine;
                }
                else if (oCurrentRSAHash.status == RSAHash.ProcessedStatus.Processed)
                {
                    txProcessStatus.Text = "Processado";
                    txProcessStatus.BackColor = Color.GreenYellow;
                }
                for (Int32 nCounter = 0; nCounter < dgFiles.RowCount; nCounter++)
                {
                    if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().Equals
                                                              (RSAPath.Status.ForProcesssing.ToString()))
                    {
                        dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    else if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().Equals
                                              (RSAPath.Status.ForDeletion.ToString()))
                    {
                        dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().Equals
                                              (RSAPath.Status.KillIt.ToString()))
                    {
                        dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().Equals
                              (RSAPath.Status.New.ToString()))
                    {
                        dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().Equals
                              (RSAPath.Status.NotProcessed.ToString()))
                    {
                        dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().Equals
                                              (RSAPath.Status.Processed.ToString()))
                    {
                        dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                }
            }
        }
        private void btMetaCancel_Click(object sender, EventArgs e)
        {
            //txClassification.Text = _metaclassification_;
            cmbClassification.Text = _metaclassification_;
            txTags.Text = _metatags_;
            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btCancelaImagem.Enabled = true;
            btMetaUpdate.Enabled = true;
            btProcessarImagem.Enabled = true;
            btManterImagem.Enabled = true;
            //txClassification.Enabled = false;
            cmbClassification.Enabled = false;
            txTags.Enabled = false;
        }
        private void btCancelaImagem_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            oRSAPath.filename = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].Value.ToString();
            if (dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value.ToString() == 
                RSAPath.Status.ForDeletion.ToString())
            {
                oRSAPath.status = RSAPath.Status.Recovered;
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                oRSAPath.status = RSAPath.Status.ForDeletion;
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
            }
            oRSAHash.paths = new List<RSAPath>();
            oRSAHash.paths.Add(oRSAPath);
            if ( oRSAHash.UpdatePathStatus() != RSAHash.ProcessedStatus.NotProcessed)
            {
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value = oRSAPath.status;
                if (oRSAPath.status == RSAPath.Status.ForDeletion)
                {
                    btCancelaImagem.Text = "Recuperar Imagem";
                }
                else
                {
                    btCancelaImagem.Text = "Excluir Imagem";
                }
            }
            SetButtonsState();
        }
        private void btRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btManterImagem_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            oRSAPath.filename = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].Value.ToString();
            if (dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value.ToString() == 
                RSAPath.Status.New.ToString() ||
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value.ToString() ==
                RSAPath.Status.NotProcessed.ToString())
            {
                oRSAPath.status = RSAPath.Status.ForProcesssing;
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
            else
            {
                oRSAPath.status = RSAPath.Status.NotProcessed;
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            oRSAHash.paths = new List<RSAPath>();
            oRSAHash.paths.Add(oRSAPath);
            if (oRSAHash.UpdatePathStatus() != RSAHash.ProcessedStatus.NotProcessed)
            {
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value = oRSAPath.status;
                if (oRSAPath.status == RSAPath.Status.NotProcessed)
                {
                    btManterImagem.Text = "Manter Imagem";
                }
                else
                {
                    btManterImagem.Text = "Reverter";
                }
            }
            SetButtonsState();
        }
        private void btProcessarImagem_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            oRSAHash.hash = oCurrentRSAHash.hash;
            Int32 nForProcess = 0;
            for (Int32 nCounter =0; nCounter < dgFiles.Rows.Count; nCounter++)
            {
                if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().
                    Equals(RSAPath.Status.ForProcesssing.ToString())) nForProcess++;
            }
            if (nForProcess > 1)
            {
                MessageBox.Show("Não é possivel manter 2 arquivos na base principal, por favor revisar !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (Int32 nCounter = 0; nCounter < dgFiles.Rows.Count; nCounter++)
            {
                if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().
                    Equals(RSAPath.Status.New.ToString())  ||
                    dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().
                    Equals(RSAPath.Status.NotProcessed.ToString()) ||
                    dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().
                    Equals(RSAPath.Status.Recovered.ToString()))
                {
                    MessageBox.Show("Existe imagem sem análise, por favor revisar !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            for (Int32 nCounter = 0; nCounter < dgFiles.Rows.Count; nCounter++)
            {
                if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().
                    Equals(RSAPath.Status.ForDeletion.ToString()))
                {
                    String sRandomFileName = DateTime.UtcNow.Year.ToString() +  // year
                                             DateTime.UtcNow.Month.ToString() +  // month
                                             DateTime.UtcNow.Day.ToString() +  // day 
                                             DateTime.UtcNow.Hour.ToString() +  // hour
                                             DateTime.UtcNow.Minute.ToString() +  // minute
                                             DateTime.UtcNow.Second.ToString() +  // second
                                             DateTime.UtcNow.Second.ToString();

                    // Copiar da origem para a pasta duplicated controlada pelo app
                    try
                    {
                        File.Move(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString(),
                                  oRSACore.DuplicatedFolder + 
                                  sRandomFileName +
                                  Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    }
                    catch (Exception oErr)
                    {
                        sRandomFileName = sRandomFileName + "_" + nCounter.ToString();
                        File.Move(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString(),
                                  oRSACore.DuplicatedFolder + 
                                  sRandomFileName +
                                  Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    }

                    oRSAPath.filename = dgFiles.Rows[nCounter].Cells["filename"].Value.ToString();

                    oRSAPath.status = RSAPath.Status.KillIt;
                    oRSAHash.paths = null;
                    oRSAHash.paths = new List<RSAPath>();
                    oRSAHash.paths.Add(oRSAPath);

                    oRSAHash.UpdatePathStatus(oRSACore.DuplicatedFolder +
                                              sRandomFileName +
                                              Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    //dgFiles.Rows[nCounter].Cells["status"].Value = oRSAPath.status;
                    //dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (dgFiles.Rows[nCounter].Cells["status"].FormattedValue.ToString().
                         Equals(RSAPath.Status.ForProcesssing.ToString()))
                {
                    String sRandomFileName = DateTime.UtcNow.Year.ToString() +  // year
                                             DateTime.UtcNow.Month.ToString() +  // month
                                             DateTime.UtcNow.Day.ToString() +  // day 
                                             DateTime.UtcNow.Hour.ToString() +  // hour
                                             DateTime.UtcNow.Minute.ToString() +  // minute
                                             DateTime.UtcNow.Second.ToString() +  // second
                                             DateTime.UtcNow.Second.ToString();

                    // Copiar da origem para a pasta duplicated controlada pelo app
                    try
                    {
                        //if (!Directory.Exists(oRSACore.StructuredFolder + txClassification.Text))
                        if (!Directory.Exists(oRSACore.StructuredFolder + cmbClassification.Text.Trim()))
                        {
                            //Directory.CreateDirectory(oRSACore.StructuredFolder + txClassification.Text);
                            Directory.CreateDirectory(oRSACore.StructuredFolder + cmbClassification.Text.Trim());
                        }
                        File.Move(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString(),
                                  oRSACore.StructuredFolder +
                                  //txClassification.Text +
                                  cmbClassification.Text.Trim() + 
                                  @"\" + sRandomFileName +
                                  Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    }
                    catch (Exception oErr)
                    {
                        sRandomFileName = sRandomFileName + "_" + nCounter.ToString();
                        File.Move(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString(),
                                  oRSACore.StructuredFolder + 
                                  //txClassification.Text +
                                  cmbClassification.Text.Trim() +
                                  @"\" + sRandomFileName +
                                  Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    }

                    oRSAPath.filename = dgFiles.Rows[nCounter].Cells["filename"].Value.ToString();
                    
                    oRSAPath.status = RSAPath.Status.Processed;
                    oRSAHash.paths = null;
                    oRSAHash.paths = new List<RSAPath>();
                    oRSAHash.paths.Add(oRSAPath);

                    oRSAHash.UpdatePathStatus(oRSACore.StructuredFolder + 
                                              //txClassification.Text + @"\" +
                                              cmbClassification.Text.Trim() + @"\" +
                                              sRandomFileName +
                                              Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    oRSAHash.friendlyname = sRandomFileName +
                                            Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString());
                    txFriendlyName.Text = sRandomFileName +
                                          Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString());
                    oRSAHash.UpdateMetadata();
                    //dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            //SaveMetaData(txClassification.Text, txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.Processed);
            SaveMetaData(cmbClassification.Text.Trim(), txFriendlyName.Text, txTags.Text, RSAHash.ProcessedStatus.Processed);
            dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["status"].Value = RSAHash.ProcessedStatus.Processed;
            oCurrentRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            RSAHash.ProcessedStatus oRetCod = oCurrentRSAHash.GetRSAHash();
            FillFileList(dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString(), dgHashes.CurrentCell.RowIndex);
            RefreshStatusColor();
            SetButtonsState();
        }
        private void ckAddProcessed_EnabledChanged(object sender, EventArgs e)
        {
            if (!ckAddProcessed.Checked)
            {
                oRSAHashBinding.Filter = " status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Processed).ToString() +
                                         " and status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Commmited).ToString();
            }
            else
            {
                oRSAHashBinding.Filter = " status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Processed).ToString() +
                                         " and status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Commmited).ToString();
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
                oRSAHashBinding.Filter = " status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Processed).ToString() +
                                         " and status <> " + Convert.ToInt32(RSAHash.ProcessedStatus.Commmited).ToString();
            }
            else
            {
                oRSAHashBinding.Filter = "";
            }
        }
        private void btPurgeHash_Click(object sender, EventArgs e)
        {
            if (!dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["status"].FormattedValue.ToString().
                                           Equals(RSAHash.ProcessedStatus.Processed.ToString()) &&
                !dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["status"].FormattedValue.ToString().
                                           Equals(RSAHash.ProcessedStatus.Commmited.ToString()))
            {
                RSAHash oRSAHash = new RSAHash();
                oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].FormattedValue.ToString();
                for (Int32 nCount =0; nCount < dgFiles.Rows.Count; nCount++)
                {
                    try
                    {
                        File.Delete(dgFiles.Rows[nCount].Cells["filename"].FormattedValue.ToString());
                    }
                    catch (IOException oErr)
                    {

                    }
                }
                oRSAHash.Delete();
                dgHashes.Rows.Remove(dgHashes.CurrentRow);
            }
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
            dgHashes.CurrentCell = dgHashes[0, dgHashes.CurrentCell.RowIndex - 1];
            if (dgHashes.CurrentCell.RowIndex == dgHashes.Rows.GetFirstRow(dgHashes.CurrentCell.State))
            {
                btPreviousHash.Enabled = false;
                btNextHash.Enabled = true;
            }
            else
            {
                btPreviousHash.Enabled = true;
                btNextHash.Enabled = true;
            }
        }
        private void btNextHash_Click(object sender, EventArgs e)
        {
            dgHashes.CurrentCell = dgHashes[0, dgHashes.CurrentCell.RowIndex + 1];
            if (dgHashes.CurrentCell.RowIndex == dgHashes.Rows.GetLastRow(dgHashes.CurrentCell.State))
            {
                btPreviousHash.Enabled = true;
                btNextHash.Enabled = false;
            }
            else
            {
                btPreviousHash.Enabled = true;
                btNextHash.Enabled = true;
            }
        }

        private void btPreviousImage_Click(object sender, EventArgs e)
        {
            dgFiles.CurrentCell = dgFiles[0, dgFiles.CurrentCell.RowIndex - 1];
            if (dgFiles.CurrentCell.RowIndex == dgFiles.Rows.GetFirstRow(dgFiles.CurrentCell.State))
            {
                btPreviousImage.Enabled = false;
                btNextImage.Enabled = true;
            }
            else
            {
                btPreviousImage.Enabled = true;
                btNextImage.Enabled = true;
            }
            lblCurrentImage.Text = (dgFiles.CurrentCell.RowIndex + 1).ToString();
            lblFilename.Text = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].FormattedValue.ToString();
        }
        private void btNextImage_Click(object sender, EventArgs e)
        {
            dgFiles.CurrentCell = dgFiles[0, dgFiles.CurrentCell.RowIndex + 1];
            if (dgFiles.CurrentCell.RowIndex == dgFiles.Rows.GetLastRow(dgFiles.CurrentCell.State))
            {
                btPreviousImage.Enabled = true;
                btNextImage.Enabled = false;
            }
            else
            {
                btPreviousImage.Enabled = true;
                btNextImage.Enabled = true;
            }
            lblCurrentImage.Text = (dgFiles.CurrentCell.RowIndex + 1).ToString();
            lblFilename.Text = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].FormattedValue.ToString();
        }

    }
}