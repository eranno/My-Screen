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
    public partial class EncrypForm : Form
    {
        public EncrypForm()
        {
            InitializeComponent();
        }

        private void btLoadImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                foreach (var imgFile in files)
                {
                    lbImgFiles.Items.Add(Path.GetFileName(imgFile));
                }
            }
        }

    }
}
