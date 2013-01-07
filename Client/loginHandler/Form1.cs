using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;

namespace loginHandler
{
    public partial class login : Form
    {
        private const string PASSWORD_DOESNT_MACH = "password doesn't mach!";
        private const string PARAM_MISSING = "at list one parameter is missing!"
                                               + "\n please try again!";
        private const string EMAIL_NOT_VALID = "email not valid! please try again.";

        public login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Submit!");
            error.Visible = false;
            if (password.Text != reEnterPassword.Text)
            {
                password.Text = null;
                reEnterPassword.Text = null;
                error.Text = PASSWORD_DOESNT_MACH;
                error.Visible = true;
                return;
            }
            if (name.Text == "" || email.Text == "" ||
                password.Text == "" || reEnterPassword.Text == "")
            {
                error.Text = PARAM_MISSING;
                error.Visible = true;
                return;
            }

            if (!validEmail(email.Text, password.Text))
            {
                error.Text = EMAIL_NOT_VALID;
                error.Visible = true;
                return;
            }
            //set new values in user's properties table.
            Boolean success = setProperties(name.Text, email.Text, password.Text);
            Form2 form2 = new Form2();
            this.Close();
            form2.Show();
        }

        //checks if email is valid
        private Boolean validEmail(String email, String password)
        {
            //send to newUserName method in order to check if user is valid. 
            if (newUserName(email, password)) return true;
            return false;
        }
        //conctes to server to validate new user
        private Boolean newUserName(String email, String password)
        {
            //TODO. connect to server and validate
            return true;
        }
        //insert user's properties
        private Boolean setProperties(String name, String email, String password)
        {
            //TODO. connect to user's DB and update
            return true;
        }
    }
}