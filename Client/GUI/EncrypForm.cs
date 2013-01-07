using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataHandler;
using System.Threading;
using ImageProcessing;

namespace GUI
{
    public partial class EncrypForm : Form
    {
        List<string> imgFiles;

        public EncrypForm()
        {
            InitializeComponent();
            imgFiles = new List<string>();
        }

        private void btLoadImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                foreach (string imgFile in files)
                {
                    imgFiles.Add(imgFile);
                    lbImgFiles.Items.Add(Path.GetFileName(imgFile));
                }
            }
        }

        private void encryptNstore_Click(object sender, EventArgs e)
        {
            if (imgFiles.Count == 0)
            {
                MessageBox.Show("Load some images first");
                return;
            }
            ImageHandler.createThumb(imgFiles);
            //LocalData.createThumb(imgFiles);
            this.Close();
        }


    }
}
