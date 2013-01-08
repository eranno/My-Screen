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
using System.Net;
using System.Collections.Specialized;

namespace loginHandler
{
    public partial class confirmation : Form
    {
        int i;
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

            User user = LocalData.getUserProperties();


            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["userId"] = user.UserId;
                data["securityCode"] = confirmationCode.Text;

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/activate.php", "GET", data);

                //contains conf code
                String body = Encoding.UTF8.GetString(response);
                char code = body[0];
                if (code == '1' || code == '2')
                {
                    MessageBox.Show("Error code: " + code);
                    error.Text = WORNG_CONF_CODE;
                    error.Visible = true;
                    return ;
                }
                else
                {
                    MessageBox.Show("Success code: " + body);
                    error.Text = WORNG_CONF_CODE;
                    error.Visible = true;
                }
            }


                MainForm MainForm = new MainForm();
                this.Hide();
                MainForm.Show();
        }

        private void confirmation_Load(object sender, EventArgs e)
        {


        }
    }
}
