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
    public partial class MainForm : Form
    {
        bool isDecrypt;
        public MainForm()
        {
            InitializeComponent();
            isDecrypt = false;
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            if (isDecrypt)
            {
                btDecrypt.Text = "Start Decrypt";
                isDecrypt = false;
            }
            else
            {
                btDecrypt.Text = "Stop Decrypt";
                isDecrypt = true;
            }
        }

        private void btAddImage_Click(object sender, EventArgs e)
        {

        }

        private void btEncryptImage_Click(object sender, EventArgs e)
        {
            EncrypForm ef = new EncrypForm();
            ef.ShowDialog(this);
        }


    }
}
