using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;
using System.Collections.Specialized;
using System.Net;

namespace GUI
{
    public partial class AddFriend : Form
    {
        Friends friends;
        public AddFriend(Friends friends)
        {
            InitializeComponent();
            this.friends = friends;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string name = txtName.Text;

            friends.addFriend(email, name);
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
