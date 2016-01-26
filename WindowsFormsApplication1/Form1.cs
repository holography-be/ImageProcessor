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
using ImageProcessor;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        ImageFactory image;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image = new ImageFactory();
                image.Load(openFileDialog1.FileName);
                pictureBox1.Image = (Image)image.Image.Clone();
                pictureBox2.Image = (Image)image.Image.Clone();
                //setImageProperties();
                //fileOpened = true;   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            image.Filter(ImageProcessor.Imaging.Filters.Photo.MatrixFilters.GreyScale);
            pictureBox2.Image = (Image)(image.Image.Clone());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            image.Update((Image)pictureBox1.Image.Clone());
            pictureBox2.Image = image.Image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            image.Halftone();
            pictureBox2.Image = (Image)(image.Image.Clone());
        }


    }
}
