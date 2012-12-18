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
        public AddFriend()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!LocalData.addFriend(nameTxt.Text))
                MessageBox.Show("Friend name already exist!");
            else
            {
                 using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["email"] = "noam185@gmail.com";
                data["password"] = "1234";
                data["femail"] = nameTxt.Text;

                var response = wb.UploadValues("http://myscreen.cu.cc/act/add_contact.php", "POST", data);
                String body = Encoding.UTF8.GetString(response);
                char code = body[0];
                     if(code == '0')
                        MessageBox.Show("Success code: " + code);
                     else
                         MessageBox.Show("Error code: " + code);
            }
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
