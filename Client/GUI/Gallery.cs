using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class Gallery : Form
    {
        string[] files;
        int pointer;
        int picWidth, picHieght;
        public Gallery()
        {
            InitializeComponent();
            getFiles();
            initComponents();
        }

        public void getFiles()
        {
            String time = DateTime.Now.ToString("dd-MM-yyyy");
            if (!Directory.Exists("DecodedImages\\" + time))
                Directory.CreateDirectory("DecodedImages\\" + time);
            files = Directory.GetFiles("DecodedImages\\" + time);
            pointer = 0;
        }

        public void initComponents()
        {
            if (files.Length == 0)
            {
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnPrev.Enabled = false;
            }

            picWidth = pictureBox1.Width;
            picHieght = pictureBox1.Height;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pointer < files.Length)
            {
                showImage();
                pointer++;
            }
            else
                btnNext.Enabled = false;
            btnPrev.Enabled = true;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {       
            if (pointer > 0)
            {
                pointer--;
                showImage();
            }
            else
                btnPrev.Enabled = false;
            btnNext.Enabled = true;
        }

        private void showImage()
        {
            string path = files[pointer];
            Image image = Image.FromFile(path);
            pictureBox1.Image = image;
        }
    }
}
