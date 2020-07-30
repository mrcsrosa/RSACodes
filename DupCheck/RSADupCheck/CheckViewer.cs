using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using RSACoreLib;

namespace RSADupCheck
{
    public partial class CheckViewer : Form
    {
        private RSACore oRSACore;
        private DataTable oRSAHashes;
        private RSAHash oCurrentRSAHash;
        private Int32 nCurrentHash;
        private Int32 nCurrentImage;
        public CheckViewer()
        {
            InitializeComponent();

            oRSACore = RSACore.GetInstance();
            oRSAHashes = new DataTable();
            oCurrentRSAHash = new RSAHash();

            oRSAHashes.Columns.Add("hash_id", typeof(String));
            oRSAHashes.Columns.Add("_id", typeof(String));
            oRSAHashes.Columns.Add("contagem", typeof(Int32));
            oRSAHashes.Columns.Add("status", typeof(RSAHash.ProcessedStatus));

            lbCurrentImage.Text = "";
            lbTotalImages.Text = "";
            //FillClassification();
            FillClassificationFilter();
            LoadHashes();
            if (oRSAHashes.Rows.Count > 0)
            {
                cmbFiltro.Enabled = true;
                cmbFiltro.SelectedIndex = 0;
                nCurrentHash = 0;
                FillRSAHash(nCurrentHash);
                //if (oRSAHashes.Rows.Count == 1)
                //{
                //    btPreviousHash.Enabled = false;
                //    btNextHash.Enabled = false;
                //}
                //else
                //{
                //    cmbFiltro.Enabled = true;
                //    btPreviousHash.Enabled = false;
                //    btNextHash.Enabled = true;
                //}
                //RefreshStatusColor();
            }
            else
            {
                btPreviousHash.Enabled = false;
                btNextHash.Enabled = false;
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
        private void FillClassificationFilter()
        {
            RSAHash oRSAHash = new RSAHash();
            cmbFiltro.Items.Add("<<TODOS>>");
            foreach (String sClassification in oRSAHash.GetClassifications())
            {
                cmbFiltro.Items.Add(sClassification);
}
        }
        private void LoadHashes()
        {
            //oRSAHashBinding = new BindingSource();
            //oRSAHashes.Columns.Add("hash_id", typeof(String));
            //oRSAHashes.Columns.Add("_id", typeof(String));
            //oRSAHashes.Columns.Add("contagem", typeof(Int32));
            //oRSAHashes.Columns.Add("status", typeof(RSAHash.ProcessedStatus));
            RSAHash oRSAHash = new RSAHash();
            oRSAHashes.Clear();
            List<RSAHashAggregate> oOrganizer = oRSAHash.GetHashesProcessed();
            for (Int32 nCount = 0; nCount < oOrganizer.Count(); nCount++)
            {
                oRSAHashes.Rows.Add(oOrganizer[nCount].hash_id.ToString(),
                                    oOrganizer[nCount]._id.ToString(),
                                    oOrganizer[nCount].contagem.ToString(),
                                    (RSAHash.ProcessedStatus)oOrganizer[nCount].status);
            }
        }
        private void LoadHashes(String pFilter)
        {
            //oRSAHashBinding = new BindingSource();
            RSAHash oRSAHash = new RSAHash();
            List<RSAHashAggregate> oOrganizer = oRSAHash.GetHashesProcessed(pFilter);
            oRSAHashes.Clear();
            for (Int32 nCount = 0; nCount < oOrganizer.Count(); nCount++)
            {
                oRSAHashes.Rows.Add(oOrganizer[nCount].hash_id.ToString(),
                                    oOrganizer[nCount]._id.ToString(),
                                    oOrganizer[nCount].contagem.ToString(),
                                    (RSAHash.ProcessedStatus)oOrganizer[nCount].status);
            }
        }
        private void FillRSAHash(Int32 pRowNumber)
        {
            oCurrentRSAHash.hash = oRSAHashes.Rows[pRowNumber]["_id"].ToString();
            oCurrentRSAHash.GetRSAHash();
            txHash.Text = oCurrentRSAHash.hash;
            txFriendlyname.Text = oCurrentRSAHash.friendlyname;
            cmbClassification.Text = oCurrentRSAHash.classification;
            txTags.Text = oCurrentRSAHash.tags;
            nCurrentImage = 0;
            pBox.Image = null;
            pBox.ImageLocation = oCurrentRSAHash.paths[nCurrentImage].filename;
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
            lbCurrentImage.Text = (nCurrentHash+1).ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            pBox.ImageLocation = @"D:\!FilterPicture\ac.silvestre\Select\20121224_215750.jpg";
            pBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Media.Imaging.JpegBitmapDecoder oJpeg = new System.Windows.Media.Imaging.JpegBitmapDecoder(new Uri(@"D:\!FilterPicture\ac.silvestre\Select\20121224_215750.jpg", false),
                                System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);

            BitmapSource oSource = oJpeg.Frames[0];
            BitmapMetadata oMeta = new BitmapMetadata("jpg");
            Image oImagem = pBox.Image;
            //foreach (System.Drawing.Imaging.PropertyItem oProperty in oImagem.PropertyItems)
            //{
            //    String x = "";
            //}
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipX);
            pBox.Image = oImagem;

        }

        private void pBox_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

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
            lbCurrentImage.Text = (nCurrentHash + 1).ToString();
            RefreshStatusColor();
            return;
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
            lbCurrentImage.Text = (nCurrentHash + 1).ToString();
            RefreshStatusColor();
            return;
        }
        private void RefreshStatusColor()
        {
            if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.MetaRevised)
            {
                txProcessStatus.Text = "Revisado";
                txProcessStatus.BackColor = Color.Gold;
            }
            else if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.NotProcessed)
            {
                txProcessStatus.Text = "Não revisado";
                txProcessStatus.BackColor = Color.White;
            }
            else if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.ProcessedPartial)
            {
                txProcessStatus.Text = "Processado - Parcial";
                txProcessStatus.BackColor = Color.Aquamarine;
            }
            else if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.Processed)
            {
                txProcessStatus.Text = "Processado";
                txProcessStatus.BackColor = Color.GreenYellow;
            }
            return;

        }

        private void btRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFiltro_Validated(object sender, EventArgs e)
        {
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0)
            {
                LoadHashes();
                if (oRSAHashes.Rows.Count > 0)
                {
                    lbTotalImages.Text = oRSAHashes.Rows.Count.ToString();
                    cmbFiltro.Enabled = true;
                    nCurrentHash = 0;
                    FillRSAHash(nCurrentHash);
                    if (oRSAHashes.Rows.Count == 1)
                    {
                        btPreviousHash.Enabled = false;
                        btNextHash.Enabled = false;
                    }
                    else
                    {
                        cmbFiltro.Enabled = true;
                        btPreviousHash.Enabled = false;
                        btNextHash.Enabled = true;
                    }
                    RefreshStatusColor();
                }
                else
                {
                    txHash.Text = "";
                    txFriendlyname.Text = "";
                    txTags.Text = "";
                    cmbClassification.Text = "";
                    txProcessStatus.Text = "";
                    lbCurrentImage.Text = "";
                    lbTotalImages.Text = "";
                    btPreviousHash.Enabled = false;
                    btNextHash.Enabled = false;
                }
            }
            else
            {
                LoadHashes(cmbFiltro.Text.Trim());
                if (oRSAHashes.Rows.Count > 0)
                {
                    lbTotalImages.Text = oRSAHashes.Rows.Count.ToString();
                    cmbFiltro.Enabled = true;
                    nCurrentHash = 0;
                    FillRSAHash(nCurrentHash);
                    if (oRSAHashes.Rows.Count == 1)
                    {
                        btPreviousHash.Enabled = false;
                        btNextHash.Enabled = false;
                    }
                    else
                    {
                        cmbFiltro.Enabled = true;
                        btPreviousHash.Enabled = false;
                        btNextHash.Enabled = true;
                    }
                    RefreshStatusColor();
                }
                else
                {
                    txHash.Text = "";
                    txFriendlyname.Text = "";
                    txTags.Text = "";
                    cmbClassification.Text = "";
                    txProcessStatus.Text = "";
                    lbCurrentImage.Text = "";
                    lbTotalImages.Text = "";
                    btPreviousHash.Enabled = false;
                    btNextHash.Enabled = false;
                }
            }

        }

        private void btRotateRight_Click(object sender, EventArgs e)
        {
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pBox.Image = oImagem;
        }
    }
}
