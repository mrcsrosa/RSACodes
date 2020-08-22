using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using RSACoreLib;
using System.IO;

namespace RSADupCheck
{
    public partial class CheckViewer : Form
    {
        private RSACore oRSACore;
        private DataTable oRSAHashes;
        private RSAHash oCurrentRSAHash;
        private Int32 nCurrentHash;
        //private Int32 nCurrentImage;
        String strPreviousClassification;
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

            strPreviousClassification = "";
            lbCurrentImage.Text = "";
            lbTotalImages.Text = "";
            FillClassification();
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
                if (!sClassification.ToUpper().Equals("<<CLASSIFICAR>>"))
                {
                    cmbClassification.Items.Add(sClassification);
                }
            }
        }
        private void FillClassificationFilter()
        {
            RSAHash oRSAHash = new RSAHash();
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("<<TODOS>>");
            foreach (String sClassification in oRSAHash.GetClassifications())
            {
                if (!sClassification.ToUpper().Equals("<<CLASSIFICAR>>"))
                {
                    cmbFiltro.Items.Add(sClassification);
                }
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
            cmbClassification.SelectedIndex = cmbClassification.Items.IndexOf(oCurrentRSAHash.classification);
            txTags.Text = oCurrentRSAHash.tags;
            //nCurrentImage = 0;
            pBox.Image = null;
            webShowPDF.Visible = false;
            webShowPDF.Url = null;
            axMyplayer.URL = null;
            foreach (RSAPath oRSAPath in oCurrentRSAHash.paths)
            {
                if (oRSAPath.status == RSAPath.Status.Processed)
                {
                    if (oCurrentRSAHash.mimetype == @"image/jpeg")
                    {
                        webShowPDF.Visible = false;
                        axMyplayer.Visible = false;
                        pBox.Visible = true;
                        pBox.Image = null;
                        pBox.ImageLocation = oRSAPath.filename.Replace("<BASEFOLDER>",
                                                                       oRSACore.BaseFolder);
                        pBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else if (oCurrentRSAHash.mimetype == @"video/mp4")
                    {
                        webShowPDF.Visible = false;
                        axMyplayer.Visible = true;
                        pBox.Visible = false;
                        Size oSize = new Size();
                        oSize.Width = 611;
                        oSize.Height = 540;
                        axMyplayer.URL =  oRSAPath.filename.Replace("<BASEFOLDER>",
                                                                       oRSACore.BaseFolder);

                        //pBox.Image = null;
                        //pBox.ImageLocation = oRSAPath.filename.Replace("<BASEFOLDER>",
                        //                                               oRSACore.BaseFolder);
                        //pBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else if (oCurrentRSAHash.mimetype == @"application/pdf")
                    {
                        webShowPDF.Visible = true;
                        axMyplayer.Visible = false;
                        pBox.Visible = false;
                        Size oSize = new Size();
                        oSize.Width = 611;
                        oSize.Height = 540;
                        webShowPDF.Size = oSize;
                        webShowPDF.Navigate(oRSAPath.filename.Replace("<BASEFOLDER>",
                                                                       oRSACore.BaseFolder));

                        //pBox.Image = null;
                        //pBox.ImageLocation = oRSAPath.filename.Replace("<BASEFOLDER>",
                        //                                               oRSACore.BaseFolder);
                        //pBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    break;
                }
                else
                {
                    pBox.Image = null;
                }
            }

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
            PreviousHash();
        }
        private void PreviousHash()
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
            cmbFiltro.Enabled = true;
            cmbClassification.Enabled = false;
            btEnableReclassify.Enabled = true;
            btCommit.Enabled = true;
            btCommitAll.Enabled = true;
            strPreviousClassification = "";

            lbCurrentImage.Text = (nCurrentHash + 1).ToString();
            RefreshStatusColor();
        }
        private void btNextHash_Click(object sender, EventArgs e)
        {
            NextHash();
        }
        private void NextHash()
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
            cmbFiltro.Enabled = true;
            cmbClassification.Enabled = false;
            btEnableReclassify.Enabled = true;
            btCommit.Enabled = true;
            btCommitAll.Enabled = true;
            strPreviousClassification = "";

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
            else if ((RSAHash.ProcessedStatus)oRSAHashes.Rows[nCurrentHash]["status"] == RSAHash.ProcessedStatus.Commmited)
            {
                txProcessStatus.Text = "Efetivado";
                txProcessStatus.BackColor = Color.DeepPink;
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
            //cmbFiltro.
            if (cmbFiltro.SelectedIndex == 0)
            {
                LoadHashes();
                RefreshHashesView();
            }
            else
            {
                LoadHashes(cmbFiltro.Text.Trim());
                RefreshHashesView();
            }
        }
        private void RefreshHashesView()
        {
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
        private void btRotateRight_Click(object sender, EventArgs e)
        {
            Image oImagem = pBox.Image;
            oImagem.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pBox.Image = oImagem;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //var objPlayer = new WMPLib.IWMPPlayer4();
            axMyplayer.Visible = true;
            axMyplayer.URL= @"W:\Uploads\Videos\Fotos Chacara\20180512_123612.mp4";
            axMyplayer.Ctlcontrols.play();
            //611; 540
            //D:\!MySpace\MRosa\OneDrive\Documents\Mackenzie\Ata Colação.pdf

            //W:\Series5OldHD\drvc\!GDriveCloud\trabalho lula gigante.docx
/*            webShowPDF.Visible = true;
            Size oSize = new Size();
            oSize.Width = 611;
            oSize.Height = 540;
            webShowPDF.Size = oSize;
            webShowPDF.Navigate(@"W:\Series5OldHD\drvc\!GDriveCloud\trabalho lula gigante.docx");
*/
            return;
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

            for (Int32 nCnt = 0; nCnt < oRSAHashes.Rows.Count; nCnt++)
                {
                    oCurrentRSAHash.hash = oRSAHashes.Rows[nCnt]["_id"].ToString();
                    oCurrentRSAHash.GetRSAHash();
                    String sFile = "";
                    foreach (RSAPath oPath in oCurrentRSAHash.paths)
                    {
                        if (oPath.status == (RSAPath.Status)4)
                        {
                            sFile = "<BASEFOLDER>" + oPath.filename.Substring(19);
                        }
                        else if (oPath.status == (RSAPath.Status)17)
                        {
                            sFile = "<BASEFOLDER>" + oPath.filename.Substring(19);
                        }
                        oRSAHash.QG(oCurrentRSAHash.hash, oPath.filename, sFile);
                    }
                }

        }
        private void btReclassify_Click(object sender, EventArgs e)
        {
            DialogResult oRetCode = MessageBox.Show("Os IDs serão reclassificados:\r\n\r\n" +
                                                    "De: " +
                                                    strPreviousClassification +
                                                    "\r\nPara: " +
                                                    cmbClassification.Text +
                                                    "\r\nConfirma [S/N] ?",
                                                    "Resumo",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (oRetCode == DialogResult.No)
            {
                cmbFiltro.Enabled = true;
                cmbClassification.Enabled = false;
                btEnableReclassify.Enabled = true;
                btCommit.Enabled = true;
                btCommitAll.Enabled = true;
                cmbClassification.Text = strPreviousClassification;
                return;
            }
            RSAHash oRSAHash = new RSAHash();
            if (cmbClassification.Text.Equals(strPreviousClassification))
            {
                cmbFiltro.Enabled = true;
                cmbClassification.Enabled = false;
                btEnableReclassify.Enabled = true;
                strPreviousClassification = "";
                return;
            }
            else
            {
                for (Int32 nCount = 0; nCount < oRSAHashes.Rows.Count; nCount++)
                {
                    String x = oRSAHashes.Rows[nCount]["_id"].ToString();
                    oRSAHash.hash = oRSAHashes.Rows[nCount]["_id"].ToString();
                    oRSAHash.GetRSAHash();
                    foreach(RSAPath oRSAPath in oRSAHash.paths)
                    {
                        if (oRSAPath.status == RSAPath.Status.Processed)
                        {
                            if (!Directory.Exists(oRSACore.StructuredFolder + cmbClassification.Text))
                            {
                                Directory.CreateDirectory(oRSACore.StructuredFolder + cmbClassification.Text);
                            }
                            try
                            {
                                String y = oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder);
                                x = oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder).
                                    Replace(strPreviousClassification, cmbClassification.Text);

                                File.Move(oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder), 
                                          oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder).
                                          Replace(strPreviousClassification, cmbClassification.Text));
                            }
                            catch (Exception oErr)
                            {

                            }
                            oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                      oRSAPath.filename,
                                                      oRSAPath.status,
                                                      oRSAPath.filename.Replace(strPreviousClassification, cmbClassification.Text));
                        }
                    }
                    oRSAHash.classification = cmbClassification.Text.Trim();
                    oRSAHash.UpdateMetadata();
                }
                cmbFiltro.Enabled = true;
                cmbClassification.Enabled = false;
                btEnableReclassify.Enabled = true;
                strPreviousClassification = "";
                FillClassificationFilter();
                cmbFiltro.SelectedIndex =  cmbFiltro.Items.IndexOf(cmbClassification.Text);
                RefreshClassificationChange();
            }
        }
        private void btEnableReclassify_Click(object sender, EventArgs e)
        {
            strPreviousClassification = cmbFiltro.Text;
            cmbFiltro.Enabled = false;
            cmbClassification.Enabled = true;
            btEnableReclassify.Enabled = false;
            btCommit.Enabled = false;
            btCommitAll.Enabled = false;
        }
        private void cmbClassification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        private void RefreshClassificationChange()
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
        private void btReclassifyOne_Click(object sender, EventArgs e)
        {
            DialogResult oRetCode = MessageBox.Show("O ID será reclassificado:\r\n\r\n" +
                                                    "De: " +
                                                    strPreviousClassification +
                                                    "\r\nPara: " +
                                                    cmbClassification.Text +
                                                    "\r\nConfirma [S/N] ?",
                                                    "Resumo",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (oRetCode == DialogResult.No)
            {
                cmbFiltro.Enabled = true;
                cmbClassification.Enabled = false;
                btEnableReclassify.Enabled = true;
                btCommit.Enabled = true;
                btCommitAll.Enabled = true;
                cmbClassification.Text = strPreviousClassification;
                return;
            }
            RSAHash oRSAHash = new RSAHash();
            if (cmbClassification.Text.Equals(strPreviousClassification))
            {
                cmbFiltro.Enabled = true;
                cmbClassification.Enabled = false;
                btEnableReclassify.Enabled = true;
                strPreviousClassification = "";
                return;
            }
            else
            {
                //for (Int32 nCount = 0; nCount < oRSAHashes.Rows.Count; nCount++)
                //{
                String x = oRSAHashes.Rows[nCurrentHash]["_id"].ToString();
                oRSAHash.hash = oRSAHashes.Rows[nCurrentHash]["_id"].ToString();
                oRSAHash.GetRSAHash();
                foreach (RSAPath oRSAPath in oRSAHash.paths)
                {
                    if (oRSAPath.status == RSAPath.Status.Processed)
                    {
                        if (!Directory.Exists(oRSACore.StructuredFolder + cmbClassification.Text))
                        {
                            Directory.CreateDirectory(oRSACore.StructuredFolder + cmbClassification.Text);
                        }
                        try
                        {
                            String y = oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder);
                            x = oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder).
                                Replace(strPreviousClassification, cmbClassification.Text);

                            File.Move(oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder),
                                        oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder).
                                        Replace(strPreviousClassification, cmbClassification.Text));
                        }
                        catch (Exception oErr)
                        {

                        }
                        oRSAHash.UpdatePathStatus(oRSAHash.hash,
                                                    oRSAPath.filename,
                                                    oRSAPath.status,
                                                    oRSAPath.filename.Replace(strPreviousClassification, cmbClassification.Text));
                    }
                }
                oRSAHash.classification = cmbClassification.Text.Trim();
                oRSAHash.UpdateMetadata();
                //}
                cmbFiltro.Enabled = true;
                cmbClassification.Enabled = false;
                btEnableReclassify.Enabled = true;
                strPreviousClassification = "";
                FillClassificationFilter();
                cmbFiltro.SelectedIndex = cmbFiltro.Items.IndexOf(cmbClassification.Text);
                RefreshClassificationChange();
            }
        }
        private void btCommit_Click(object sender, EventArgs e)
        {
            Commit(oCurrentRSAHash.hash);
            PreviousHash();
            RefreshStatusColor();
        }
        private void btCommitAll_Click(object sender, EventArgs e)
        {
            Commit();
            RefreshStatusColor();
        }
        private void Commit()
        {
            DialogResult oRetCode = MessageBox.Show("Serão processados todos os IDs da classificação: " +
                                                    cmbFiltro.Text.Trim() +
                                                    "\r\n" +
                                                    "imagens duplicadas serão excluidas para liberação de espaça.\r\n\r\n" +
                                                    "Confirma [S/N] ?",
                                                    "Resumo",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (oRetCode == DialogResult.No) return;
            RSAHash oRSAHash = new RSAHash();
            List<RSAHashAggregate> oHashesProcessed = oRSAHash.GetHashesProcessed(cmbFiltro.Text);
            for (Int32 nCount = 0; nCount < oHashesProcessed.Count(); nCount++)
            {
                if ((RSAHash.ProcessedStatus)oHashesProcessed[nCount].status == RSAHash.ProcessedStatus.Processed)
                {
                    oRSAHash.hash = oHashesProcessed[nCount]._id.ToString();
                    oRSAHash.GetRSAHash();
                    foreach (RSAPath oRSAPath in oRSAHash.paths)
                    {
                        if (oRSAPath.status == RSAPath.Status.KillIt ||
                            oRSAPath.status == RSAPath.Status.Killed)
                        {
                            if (File.Exists(oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder)))
                            {
                                File.Delete(oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder));
                            }
                            oRSAHash.Delete(oRSAHash.hash,
                                            oRSAPath.volume,
                                            oRSAPath.filename);
                        }
                    }
                    oRSAHash.status = RSAHash.ProcessedStatus.Commmited;
                    oRSAHash.UpdateMetadata();
                    // Verifica se restou algum RSAPath 
                    oRSAHash.GetRSAHash();
                    if (oRSAHash.paths.Count == 0)
                    {
                        oRSAHash.Delete(oRSAHash.hash);
                    }
                }
            }
            LoadHashes(cmbFiltro.Text.Trim());
            RefreshHashesView();
        }
        private void Commit(String pRSAHash)
        {
            RSAHash oRSAHash = new RSAHash();
            oRSAHash.hash = pRSAHash;
            oRSAHash.GetRSAHash();
            Int32 nPathProcessed = 0;
            Int32 nPathOthers = 0;
            foreach (RSAPath oRSAPath in oRSAHash.paths)
            {
                if (oRSAPath.status == RSAPath.Status.Processed)
                {
                    nPathProcessed++;
                }
                else
                {
                    nPathOthers++;
                }
            }
            DialogResult oRetCode =  MessageBox.Show("Sera(ao) processada(s):\r\n" +
                                                     nPathProcessed.ToString() +
                                                     " imagem(ns) (estruturada(s))\r\n" +
                                                     nPathOthers.ToString() +
                                                     " imagem(ns) (duplicada(s)) - que sera(ao) apagadas definitvamente !\r\n\r\n" +
                                                     "Confirma [S/N] ?", 
                                                     "Resumo",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (oRetCode == DialogResult.No) return;
        
            if (oRSAHash.status == RSAHash.ProcessedStatus.Processed)
            {
                foreach (RSAPath oRSAPath in oRSAHash.paths)
                {
                    if (oRSAPath.status == RSAPath.Status.KillIt ||
                        oRSAPath.status == RSAPath.Status.Killed)
                    {
                        if (File.Exists(oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder)))
                        {
                            File.Delete(oRSAPath.filename.Replace("<BASEFOLDER>", oRSACore.BaseFolder));
                        }
                        oRSAHash.Delete(oRSAHash.hash,
                                        oRSAPath.volume,
                                        oRSAPath.filename);
                    }
                }
                oRSAHash.status = RSAHash.ProcessedStatus.Commmited;
                oRSAHashes.Rows[nCurrentHash]["status"] = RSAHash.ProcessedStatus.Commmited;
                oRSAHash.UpdateMetadata();
            }
            // Verifica se restou algum RSAPath 
            oRSAHash.GetRSAHash();
            if (oRSAHash.paths.Count == 0)
            {
                oRSAHash.Delete(oRSAHash.hash);
                oRSAHashes.Rows[nCurrentHash].Delete();
                lbTotalImages.Text = oRSAHashes.Rows.Count.ToString();
            }
        }

        private void btCommit_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Efeitva o ID, e exclui as imagens duplicadas ou descartadas.", (IWin32Window)sender);
        }

        private void btCommitAll_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Efeitva todos os IDs dentro da classificação,\r\ne exclui as imagens duplicadas ou descartadas.", (IWin32Window)sender);
        }

        private void btReclassifyOne_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Reclassifica o IDs selecionado.", (IWin32Window)sender);
        }

        private void btReclassify_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Reclassifica todos os IDs.", (IWin32Window)sender);
        }

        private void btPreviousHash_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("ID anterior.", (IWin32Window)sender);
        }

        private void btNextHash_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Proximo ID.", (IWin32Window)sender);
        }

        private void btRotateRight_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Rotacionar a imagem.", (IWin32Window)sender);
        }

        private void btEnableReclassify_MouseHover(object sender, EventArgs e)
        {
            tipRecycle.Show("Habilitar a reclassificação.", (IWin32Window)sender);
        }
    }
}
