using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;
using GUI;

namespace loginHandler
{
    public partial class confirmation : Form
    {
        private const string NO_CONF_CODE = "no confirmation code. try again";
        private const string WORNG_CONF_CODE = "worng confirmation code. try again";

        public confirmation()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (confirmationCode.Text == "")
            {
                error.Text = NO_CONF_CODE;
                error.Visible = true;
            }
            //CHECK IF VALIDATE COSE MATCHES
<<<<<<< HEAD
            DataTable dt = DBHandler.getTable("SELECT securityCode FROM UserProperties");
            DataRow row = dt.Rows[0];
            String confCodeFromTable = row["securityCode"].ToString();
=======
            DataTable dt = DBHandler.getTable("SELECT userId FROM UserProperties");
            DataRow row = dt.Rows[0];
            String confCodeFromTable = row["userId"].ToString();
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4

            if (confirmationCode.Text != confCodeFromTable)
            {
                error.Text = WORNG_CONF_CODE;
                error.Visible = true;
            }

            if (confirmationCode.Text == confCodeFromTable)
            {
                MainForm MainForm = new MainForm();
                this.Hide();
                MainForm.Show();
            }

        }

        private void confirmation_Load(object sender, EventArgs e)
        {

        }
    }
}
