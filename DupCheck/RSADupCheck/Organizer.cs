using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using RSACoreLib;
//using MongoDB.Driver;
//using MongoDB.Bson;
using System.Windows.Media.Imaging;
//using System.Security.Cryptography;

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
            FillHashList();
            if (dgHashes.Rows.Count > 0)
            {
                FillFileList(dgHashes.Rows[0].Cells["_id"].Value.ToString());
                dgHashes.CurrentCell = dgHashes[0, 0];
            }
        }
        private void FillFileList(String pHash)
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
                    dgFiles.Rows.Add(oPath.filename.ToString(),
                                     oPath.volume.ToString(),
                                     oPath.status
                            );
                }
            }
            return;
            //var files = oRSACore.Hashes.Find(new BsonDocument("hash", results[0].GetValue("_id").ToString()));
            //var files = oRSACore.RSAHashes.Find(new BsonDocument("hash", pHash));
            //txFriendlyName.Text = files.Single()["friendlyname"].ToString();
            //txClassification.Text = files.Single()["classification"].ToString();
            //try
            //{
            //    txTags.Text = files.Single()["tags"].ToString();
            //}
            //catch (Exception oErr)
            //{
            //    txTags.Text = "";
            //}
            //dgFiles.Rows.Clear();
            //foreach (var hash in files.ToList())
            //{
            //    String x = "";
            //    foreach (var file in hash["paths"].AsBsonArray)
            //    {
            //        dgFiles.Rows.Add(file["filename"].ToString(),
            //                         file["volume"].ToString(),
            //                         file["status"].ToString()
            //            );
            //    }
            //    x = "";
            //}
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

            //var filtro = oRSACore.RSAHashes.Aggregate().Project(new BsonDocument { 
            //                                                    { "_id", "$hash" },
            //                                                    new BsonDocument{ {"hash_id", "$_id" } },
            //                                                    { "contagem", new BsonDocument("$size", "$paths") } })
            //                                        .Sort(new BsonDocument { { "contagem", -1 } })
            //                                        .Match(new BsonDocument { { "contagem", new BsonDocument("$gt", 0) } });
            //var results = filtro.ToList();
            ////.Match(new BsonDocument { { "$match", new BsonDocument("contagem", "$gt:1") } });   results[0].GetValue("_id").ToString()
            ////            foreach ( var item in results.)results[0].GetValue("_id").ToString()
            //for (Int32 nCount = 0; nCount < results.Count(); nCount++)
            //{
            //    dgHashes.Rows.Add(results[nCount].GetValue("hash_id").ToString(), results[nCount].GetValue("_id").ToString(), results[nCount].GetValue("contagem").ToString());
            //}


        }
        private void dgHashes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgHashes.Rows.Count > 0)
            {
                FillFileList(dgHashes.Rows[e.RowIndex].Cells["_id"].Value.ToString());
            }
        }
        private void dgFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
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
            foreach (System.Drawing.Imaging.PropertyItem oProperty in oImagem.PropertyItems)
            {
                String x = "";
            }
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



            foreach (System.Drawing.Imaging.PropertyItem oProperty in oImagem.PropertyItems)
            {
                String x = "";
            }
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
            txClassification.Enabled = false;
            txTags.Enabled = false;
        }
        private void SaveMetaData()
        {
            RSAHash oRSAHash = new RSAHash();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            oRSAHash.classification = txClassification.Text;
            oRSAHash.tags = txTags.Text;
            if (oRSAHash.UpdateMetadata() == RSAHash.Status.HashUpdated)
            {

            }
            //var filter = Builders<BsonDocument>.Filter.Eq("hash", dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString());
            //var up = Builders<BsonDocument>.Update.Set("classification", txClassification.Text)
            //                                      .Set("tags", txTags.Text);


            //oRSACore.RSAHashes.UpdateOne(filter, up);
        }
        private void btMetaCancel_Click(object sender, EventArgs e)
        {
            txClassification.Text = _metaclassification_;
            txTags.Text = _metatags_;
            btMetaSave.Enabled = false;
            btMetaCancel.Enabled = false;
            btCancelaImagem.Enabled = true;
            btMetaUpdate.Enabled = true;
            txClassification.Enabled = false;
            txTags.Enabled = false;
        }
        private void btCancelaImagem_Click(object sender, EventArgs e)
        {
            RSAHash oRSAHash = new RSAHash();
            RSAPath oRSAPath = new RSAPath();
            oRSAHash.hash = dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString();
            oRSAPath.filename = dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].Value.ToString();
            oRSAPath.status = RSAPath.Status.ForDeletion;
            oRSAHash.paths = new List<RSAPath>();
            oRSAHash.paths.Add(oRSAPath);
            if ( oRSAHash.UpdatePathStatus() == RSAHash.Status.HashUpdated)
            {
                dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value = oRSAPath.status;
            }

            //var upOption = new UpdateOptions();
            //var filter = Builders<BsonDocument>.Filter.Eq("hash", dgHashes.Rows[dgHashes.CurrentCell.RowIndex].Cells["_id"].Value.ToString());
            //upOption.ArrayFilters = new List<ArrayFilterDefinition> { 
            //    new BsonDocumentArrayFilterDefinition<BsonDocument>(
            //    new BsonDocument("element.filename", 
            //                     dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["filename"].Value.ToString())) };
            //var up = Builders<BsonDocument>.Update.Set("paths.$[element].status", "-");
            //oRSACore.RSAHashes.UpdateOne(filter, up, upOption);

            //dgFiles.Rows[dgFiles.CurrentCell.RowIndex].Cells["status"].Value = "-";
            ////dgFiles.Rows[dgFiles.CurrentCell.RowIndex]
        }
        private void btRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
