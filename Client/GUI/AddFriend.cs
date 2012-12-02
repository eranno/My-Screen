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
                this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
