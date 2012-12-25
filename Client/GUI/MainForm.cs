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
            imageList1.ImageSize = new System.Drawing.Size(150, 150);
            List<String> files = currFriend.getImageList();
            lvImgsStatus(files.Count);
            ProgressBar pb = new ProgressBar();
            pb.Show();
            //long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            foreach (var imgFile in files)
            {
                
                    using (FileStream fs = new FileStream(imgFile, FileMode.Open, FileAccess.Read))
                    {
                        using (Image img = Image.FromStream(fs))
                        {
                            imageList1.Images.Add(img);
                        }
                    }
                    //TODO: exception!
             
            }
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            //MessageBox.Show("Total : " + (end-start));
            lvImgs.LargeImageList = imageList1;
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                  //TODO: move it to another thread.
                ListViewItem lvi = new ListViewItem(Path.GetFileName(files[i]), i);
                lvImgs.Items.Add(lvi);
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

        private void friendSelected(object sender, KeyEventArgs e)
        {

        }

    }
}
