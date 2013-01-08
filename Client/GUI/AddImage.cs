using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;

namespace GUI
{
    public partial class AddImage : Form
    {
        string friendId;
        Friends friends;
        public AddImage(Friends friends , string friendId)
        {
            InitializeComponent();
            dataGridView1.DataSource = friends.getFriendImagesSource(friendId);
            foreach (DataGridViewColumn cl in dataGridView1.Columns)
            {
                if (cl.Name.Equals("name"))
                {
                    cl.Visible = true;
                    cl.MinimumWidth = dataGridView1.Width;
                }
                else
                {
                    cl.Visible = false;
                }
            }
            this.friendId = friendId;
            this.friends = friends;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = dataGridView1.SelectedRows.Count;
            if (size == 0)
            {
                MessageBox.Show("Select images first");
                return;
            }
            for (int i = 0; i < size; i++)
            {
                DataRowView row = dataGridView1.SelectedRows[i].DataBoundItem as DataRowView;
                string id = row["id"].ToString();
                string ImageIdx = row["idx"].ToString();
                string path = row["pathThumb"].ToString();
                friends.addImageToFriend(friendId, id, path);
                Server.addPermission(friendId, ImageIdx);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["name"].Width = dataGridView1.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = friends.getFriendImagesSource(friendId);
        }

    }
}
