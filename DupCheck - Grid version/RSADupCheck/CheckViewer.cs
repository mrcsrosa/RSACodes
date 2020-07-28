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

namespace RSADupCheck
{
    public partial class CheckViewer : Form
    {
        public CheckViewer()
        {
            InitializeComponent();
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
    }
}
