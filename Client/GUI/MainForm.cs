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
            }
            else
            {
                btDecrypt.Text = "Stop Decrypt";
                isDecrypt = true;
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
            ImageList il = friends.getMyImages(currFriendId);
            //Hide\Show the Alert label ("Add New Images")
            lvImgsStatus(il.Images.Count);

            lvImgs.LargeImageList = il;
            for (int i = 0; i < il.Images.Count; i++)
            {
                  //TODO: move it to another thread.
                ListViewItem lvi = new ListViewItem("", i);
                lvImgs.Items.Add(lvi);
                //lvImgs.Refresh();
            }
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
            AddFriend ad = new AddFriend(friends);
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
                
                lvi.Remove();
            }
        }


 


    }
}
