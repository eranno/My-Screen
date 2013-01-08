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
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class AddFriend : Form
    {
        public AddFriend()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            friend.Email = txtEmail.Text;
            friend.Name = txtName.Text;
            string msgError = isFriendValid(friend);

            if (msgError == null)
            {
                msgError = friend.insert();
                if (msgError.Contains(Server.SUCCESS))
                    this.Close();
                else
                    MessageBox.Show(msgError);
            }
            else //Show message error
                MessageBox.Show(msgError);
        }

        private string  isFriendValid(Friend friend)
        {
            string msg = null;
            bool regex = Regex.IsMatch(friend.Email, "@.");
            if (!regex)
            {
                msg = "Please enter valid email";
            }
            else if(friend.Name == null || friend.Name.Equals(""))
            {
                msg = "Please enter friend name";
            } 
            else if (friend.isExistInDB())
            {
                msg = "Friend already exist in your list";
            }
            return msg;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
