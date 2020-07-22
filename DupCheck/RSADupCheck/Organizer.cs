using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSACoreLib;
using System.Windows.Media.Imaging;
using System.IO;

namespace RSADupCheck
{
    public partial class Organizer : Form
    {
        private RSACore oRSACore;
        private String _metaclassification_;
        private String _metatags_;
        public Organizer()
        {
            InitializeComponent();
            oRSACore = RSACore.GetInstance();
            oRSACore.Connect();
            //db.hashes.aggregate( [ 
            //{ $project: {  _id:"$hash", contagem:  {  $size:"$paths"  }} 
            //}, 
            //{ $sort: 
            //    { contagem: -1 } }
            //] )
            dgFiles.Columns["filename"].Width = 315;
            dgFiles.Columns["volume"].Width = 65;
            dgFiles.Columns["status"].Width = 85;
            FillHashList();
            if (dgHashes.Rows.Count > 0)
            {
                FillFileList(dgHashes.Rows[0].Cells["_id"].Value.ToString(), 0);
                dgHashes.CurrentCell = dgHashes[0, 0];
            }
        }
        private void FillFileList(String pHash, Int32 pPos)
        {
            RSAHash oRSAHash = new RSAHash();
            oRSAHash.hash = pHash;
            if (oRSAHash.GetRSAHash() == RSAHash.Status.HashFound)
            {
                txFriendlyName.Text = oRSAHash.friendlyname;
                txClassification.Text = oRSAHash.classification;
                txTags.Text = oRSAHash.tags;
                dgFiles.Rows.Clear();
                foreach (RSAPath oPath in oRSAHash.paths)
                {
                    Int32 nPos = dgFiles.Rows.Add(oPath.filename.ToString(),
                                                  oPath.volume.ToString(),
                                                  oPath.status
                            );
                    if (oPath.status == RSAPath.Status.New || 
                        oPath.status == RSAPath.Status.NotProcessed)
                    {
                        dgFiles.Rows[nPos].DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (oPath.status == RSAPath.Status.ForProcesssing ||
                             oPath.status == RSAPath.Status.Processed)
                    {
                        dgFiles.Rows[nPos].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    else if (oPath.status == RSAPath.Status.ForDeletion)
                    {
                        dgFiles.Rows[nPos].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if (oPath.status == RSAPath.Status.KillIt ||
                             oPath.status == RSAPath.Status.Killed )
                    {
                        dgFiles.Rows[nPos].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                if ( oRSAHash.status == RSAHash.ProcessedStatus.NotProcessed)
                {
                    txProcessStatus.Text = "Não revisado";
                    dgHashes.Rows[pPos].DefaultCellStyle.BackColor = Color.White;
                }
                else if (oRSAHash.status == RSAHash.ProcessedStatus.MetaRevised)
                {
                    txProcessStatus.Text = "Revisado";
                    dgHashes.Rows[pPos].DefaultCellStyle.BackColor = Color.Gold;
                }
                else if (oRSAHash.status == RSAHash.ProcessedStatus.Processed)
                {
                    txProcessStatus.Text = "Processado";
                    dgHashes.Rows[pPos].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
            return;
        }
        private void FillHashList()
        {
            RSAHash oRSAHash = new RSAHash();
            List<RSAHashAggregate> oForOrganizer = oRSAHash.GetHashesForOrganizer();
            dgHashes.Rows.Clear();
            for (Int32 nCount = 0; nCount < oForOrganizer.Count(); nCount++)
            {
                dgHashes.Rows.Add(oForOrganizer[nCount].hash_id.ToString(),
                                  oForOrganizer[nCount]._id.ToString(),
                                  oForOrganizer[nCount].contagem.ToString());
            }
        }
        private void dgHashes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgHashes.Rows.Count > 0)
            {
                FillFileList(dgHashes.Rows[e.RowIndex].Cells["_id"].Value.ToString(), e.RowIndex);
            }
        }
        private void dgFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.ForDeletion.ToString())
            {
                btCancelaImagem.Text = "Recuperar Imagem";
            }
            else
            {
                btCancelaImagem.Text = "Excluir Imagem";
            }
            if (dgFiles.Rows[e.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.ForProcesssing.ToString())
            {
                btManterImagem.Text = "Reverter";
            }
            else
            {
                btManterImagem.Text = "Manter Imagem";
            }
            pBox.ImageLocation = dgFiles.Rows[e.RowIndex].Cells["filename"].Value.ToString();
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void btRotateLeft_Click(object sender, EventArgs e)
        {
            System.Windows.Media.Imaging.JpegBitmapDecoder oJpeg = new System.Windows.Media.Imaging.JpegBitmapDecoder(new Uri(pBox.ImageLocation.ToString(), false),
                    System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);
            BitmapSource oSource = oJpeg.Frames[0];
            BitmapMetadata oMeta = new BitmapMetadata("jpg");
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pBox.Image = oImagem;
        }
        private void btRotateRight_Click(object sender, EventArgs e)
        {
            System.Windows.Media.Imaging.JpegBitmapDecoder oJpeg = new System.Windows.Media.Imaging.JpegBitmapDecoder(new Uri(pBox.ImageLocation.ToString(), false),
            System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);
            BitmapSource oSource = oJpeg.Frames[0];
            BitmapMetadata oMeta = new BitmapMetadata("jpg");
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipX);
            pBox.Image = oImagem;
        }
        private void btMetaUpdate_Click(object sender, EventArgs e)
        {
            _metaclassification_ = txClassification.Text;
            _metatags_ = txTags.Text;
            txClassification.Enabled = true;
            txTags.Enabled = true;
            btMetaUpdate.Enabled = false;
            btCancelaImagem.Enabled = false;
            btProcessarImagem.Enabled = false;
            btManterImagem.Enabled = false;
            btMetaSave.Enabled = true;
            btMetaCancel.Enabled = true;
        }
        private void btMetaSave_Click(object sender, EventArgs e)
        {
            SaveMetaData();
            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btCancelaImagem.Enabled = true;
            btMetaUpdate.Enabled = true;
            btProcessarImagem.Enabled = true;
            btManterImagem.Enabled = true;
            txClassification.Enabled = false;
            txTags.Enabled = false;
        }
        private void SaveMetaData()
        {
            RSAHash oRSAHash = new RSAHash();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            oRSAHash.classification = txClassification.Text;
            oRSAHash.tags = txTags.Text;
            oRSAHash.
            if (oRSAHash.UpdateMetadata() == RSAHash.ProcessedStatus.MetaRevised)
            {
                txProcessStatus.Text = "Revisado";
            }
            else
            {
                txProcessStatus.Text = "Não revisado";
            }
        }
        private void btMetaCancel_Click(object sender, EventArgs e)
        {
            txClassification.Text = _metaclassification_;
            txTags.Text = _metatags_;
            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btCancelaImagem.Enabled = true;
            btMetaUpdate.Enabled = true;
            btProcessarImagem.Enabled = true;
            btManterImagem.Enabled = true;
            txClassification.Enabled = false;
            txTags.Enabled = false;
        }
        private void btCancelaImagem_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            oRSAPath.filename = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].Value.ToString();
            if (dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value.ToString() == RSAPath.Status.ForDeletion.ToString())
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
            if ( oRSAHash.UpdatePathStatus() == RSAHash.Status.HashUpdated)
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
            if (oRSAHash.UpdatePathStatus() == RSAHash.Status.HashUpdated)
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
        }
        private void btProcessarImagem_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            String x = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].ToString();
            Int32 nNoDups = 0;
            for (Int32 nCounter =0; nCounter < dgFiles.Rows.Count; nCounter++)
            {
                if (dgFiles.Rows[nCounter].Cells["status"].Value.ToString().Equals(RSAPath.Status.ForProcesssing.ToString())) nNoDups++;
            }
            if (nNoDups > 1)
            {
                MessageBox.Show("Não é possivel manter 2 arquivos na base principal, por favor revisar !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            for (Int32 nCounter = 0; nCounter < dgFiles.Rows.Count; nCounter++)
            {
                if (dgFiles.Rows[nCounter].Cells["status"].Value.ToString().Equals(RSAPath.Status.ForDeletion.ToString()))
                {
                    oRSAPath.filename = dgFiles.Rows[nCounter].Cells["filename"].Value.ToString();
                    oRSAPath.status = RSAPath.Status.KillIt;
                    oRSAHash.paths = new List<RSAPath>();
                    oRSAHash.paths.Add(oRSAPath);
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
                                  oRSACore.DuplicatedFolder + sRandomFileName +
                                                              Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    }
                    catch (Exception oErr)
                    {
                        sRandomFileName = sRandomFileName + "_" + nCounter.ToString();
                        File.Move(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString(),
                                  oRSACore.DuplicatedFolder + sRandomFileName +
                                                              Path.GetExtension(dgFiles.Rows[nCounter].Cells["filename"].Value.ToString()));
                    }
                    oRSAHash.UpdatePathStatus();
                    dgFiles.Rows[nCounter].Cells["status"].Value = oRSAPath.status;
                    dgFiles.Rows[nCounter].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}