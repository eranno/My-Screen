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
using System.Net;
using System.Collections.Specialized;

namespace GUI
{
    public partial class MainForm : Form
    {
        bool isDecrypt;
        LocalData ld;
        String contextName;
        List<Friend> allFriends;
        Friend currFriend;
       
        public MainForm()
        {
            InitializeComponent();
            isDecrypt = false;
            //Important localData before populateFriends.
            ld = new LocalData();

            populateFriends();
            lvImgsStatus(0);
            btAddImage.Enabled = false;
        }
        //List<ImageList> imgListControl;
        //private void initControls(){
        //    imgListControl = new List<ImageList>();
        //    foreach (Friend f in allFriends)
        //    {
        //        ImageList imglist = new ImageList();
        //        imglist.Tag = f;
                
        //    }
        //}

        public void populateFriends()
        {
            lvFriends.Clear();
            allFriends = LocalData.friends.getFriends();
            
            foreach (Friend friend in allFriends)
            {
                ListViewItem lvi = new ListViewItem(friend.getName());
                lvi.Tag = friend;
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
                List<String> files = openFileDialog1.FileNames.ToList<String>();
                int size = imageList1.Images.Count, i = 0;
                currFriend.addImages(files);
                populateImageList();
            }
        }

        private void populateImageList()
        {
            lvImgs.Items.Clear();
            imageList1.Images.Clear();
            List<String> files = currFriend.getImageList();
            lvImgsStatus(files.Count);
            foreach (var imgFile in files)
            {
                //TODO: exception!
                Image img = Image.FromFile(imgFile);
                imageList1.Images.Add(img);
                //TODO: move it to another thread.
                lvImgs.Items.Add(new ListViewItem(Path.GetFileName(imgFile), imageList1.Images.Count - 1));
                lvImgs.Refresh();
            }
        }

        private void lvImgsStatus(int size)
        {
            if(size == 0)
                alertImgsLbl.Visible = true;
            else
                alertImgsLbl.Visible = false;
        }

        private void btEncryptImage_Click(object sender, EventArgs e)
        {
            EncrypForm ef = new EncrypForm();
            ef.ShowDialog(this);
        }

        private void friendSelected(object sender, EventArgs e)
        {
            btAddImage.Enabled = true;

            ListView.SelectedIndexCollection sel = lvFriends.SelectedIndices;
            lblFriend.Text = lvFriends.Items[sel[0]].Text;
            contextName = lvFriends.Items[sel[0]].Text;

            currFriend = (Friend) lvFriends.SelectedItems[0].Tag;

            populateImageList();
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
            btAddImage.Enabled = true;

            ListView.SelectedIndexCollection sel = lvFriends.SelectedIndices;
            if (sel.Count > 0)
            {
                lblFriend.Text = lvFriends.Items[sel[0]].Text;
                contextName = lvFriends.Items[sel[0]].Text;
            }
        }

    }
}
