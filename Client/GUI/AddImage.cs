using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddImage : Form
    {
        string  friendId;
        Friends friends;
        public AddImage(Friends friends , string friendId)
        {
            InitializeComponent();
            checkedListBox1.DataSource = friends.getFriendImagesSource(friendId);
            checkedListBox1.DisplayMember = "name";
            this.friendId = friendId;
            this.friends = friends;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string id = ((DataRowView)checkedListBox1.CheckedItems[i])["id"].ToString();
                string path = ((DataRowView)checkedListBox1.CheckedItems[i])["pathThumb"].ToString();
                friends.addImageToFriend(friendId, id , path);
            }
            this.Close();
        }
    }
}
