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
using ImageProcessing;

namespace GUI
{
    public partial class MainForm : Form
    {
        bool isDecrypt;
        String currFriendId;
        Friends friends;

        private bool lbFlag;

        public MainForm()
        {
            InitializeComponent();
            isDecrypt = false;
            lbFlag = false;
            friends = new Friends();
            populateFriends();
            btAddImage.Enabled = false;
            btnRemoveImgs.Enabled = false;

        }


        public void populateFriends()
        {
            friendsList.DataSource = friends.friendsSource();
            friendsList.DisplayMember = "name";
            lbFlag = true;
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            if (isDecrypt)
            {
                btDecrypt.Text = "Start Decrypt";
                isDecrypt = false;
                TrafficHandler.terminate();
                MessageBox.Show("Traffic observer terminated");
            }
            else
            {
                MessageBox.Show("Traffic observer activated");
                TrafficHandler.activate();
                btDecrypt.Text = "Stop Decrypt";
                isDecrypt = true;
                ImageFiltering.startFilter();
            }
        }

        private void btAddImage_Click(object sender, EventArgs e)
        {
            AddImage addImage = new AddImage(friends , currFriendId);
            addImage.ShowDialog(this);
            populateImageList();
        }

        private void populateImageList()
        {
            //Clear all the items in list view.
            lvImgs.Items.Clear();
            //Getting image list of selected friend
            Dictionary<DataRow,Image> map = friends.getMyImages(currFriendId);
            ImageList il = fillImgList(map);
            //Hide\Show the Alert label ("Add New Images")
            lvImgsStatus(il.Images.Count);
            lvImgs.LargeImageList = il;
            for (int i = 0; i < il.Images.Count; i++)
            {
                DataRow row = map.Keys.ElementAt(i);
                ListViewItem lvi = new ListViewItem(row["name"].ToString(), i);
                lvi.Tag = row;
                lvImgs.Items.Add(lvi);
                //lvImgs.Refresh();
            }
        }

        private ImageList fillImgList(Dictionary<DataRow,Image> map)
        {
            ImageList myImages = new ImageList();
            myImages.ImageSize = new System.Drawing.Size(107, 80);
            myImages.ColorDepth = ColorDepth.Depth32Bit;

            foreach (var entry in map)
            {
                myImages.Images.Add(entry.Value);
            }

            return myImages;
        }

        private void lvImgsStatus(int size)
        {
            if(size == 0)
                lblalertImgs.Visible = true;
            else
                lblalertImgs.Visible = false;
        }

        private void btEncryptImage_Click(object sender, EventArgs e)
        {
            EncrypForm ef = new EncrypForm();
            ef.ShowDialog(this);
        }


        private void btAddFriend_Click(object sender, EventArgs e)
        { 
            AddFriend ad = new AddFriend();
            ad.ShowDialog(this);
            //Need to check if change ocurr in xml file.
            populateFriends();
        }


        private void friendsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFlag)
            {
                btAddImage.Enabled = true;
                // Get the currently selected item in the ListBox. 
                DataRowView item = (DataRowView)friendsList.SelectedItem;
                //TODO
                lblFriend.Text = item["name"].ToString();
                currFriendId = item["email"].ToString();
                populateImageList();
            }
        }

        private void showTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDB showDB = new ShowDB();
            showDB.Show();
           
        }

        private void lvImgs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                btnRemoveImgs.Enabled = true;
            else
                btnRemoveImgs.Enabled = false;
        }

        private void btnRemoveImgs_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvImgs.SelectedItems)
            {
                DataRow row = lvi.Tag as DataRow;
                string msg = Server.removePermission(currFriendId , row["idx"].ToString());
                MessageBox.Show(msg);
                LocalData.removeImageFromFriend(row["id"].ToString() , currFriendId);
                lvi.Remove();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrafficHandler.terminate();
        }

        private void followAfterTrafficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messages.init();
            TrafficFollow form = new TrafficFollow();
            form.Show();
        }

        private void syncWithServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Server.buildJson());
        }
    }
}
