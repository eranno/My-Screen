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
using System.Xml;

namespace GUI
{
    public partial class MainForm : Form
    {
        bool isDecrypt;
        LocalData ld;
        String contextName;
        public MainForm()
        {
            InitializeComponent();
            isDecrypt = false;
            //Important localData before populateFriends.
            ld = new LocalData();
            populateFriends();
        }

        public void populateFriends()
        {
            lvFriends.Clear();
            XmlDocument xmlData = new XmlDocument();
            xmlData.Load(LocalData.FRIENDS_DATA);
            foreach (XmlNode node in xmlData.SelectNodes("Friends/Friend"))
            {
                ListViewItem lvi = new ListViewItem(node.InnerText);
                Font font = new System.Drawing.Font("Helvetica", 10, FontStyle.Bold);
                lvi.Font = font;
                lvFriends.Items.Add(lvi);
            }
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
           
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                foreach (var imgFile in files)
                {
                    //TODO: move it to another thread.
                    //lbImgFiles.Items.Add(Path.GetFullPath(imgFile));
                }
            }
        }

        private void populateLvImgs()
        {
            lvImgs.Clear();
            int size = imageList1.Images.Count;
            for (int i = 0; i < size; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                //lvi.Text = imageList1.Images.get
                lvImgs.Items.Add(lvi);
            }
        }

        private void populateImageList()
        {

        }

        private void btEncryptImage_Click(object sender, EventArgs e)
        {
            EncrypForm ef = new EncrypForm();
            ef.ShowDialog(this);
        }

        private void friendSelected(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection sel = lvFriends.SelectedIndices;
            lblFriend.Text = lvFriends.Items[sel[0]].Text;
            contextName = lvFriends.Items[sel[0]].Text;
        }

        private void btAddFriend_Click(object sender, EventArgs e)
        {
            AddFriend ad = new AddFriend();
            ad.ShowDialog(this);
            //Need to check if change ocurr in xml file.
            populateFriends();
        }

        private void friendDoubleSelected(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection sel = lvFriends.SelectedIndices;
            lblFriend.Text = lvFriends.Items[sel[0]].Text;
            contextName = lvFriends.Items[sel[0]].Text;
        }

    }
}
