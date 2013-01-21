using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataHandler;
using System.Net;
using System.Collections.Specialized;
using GUI;

namespace loginHandler
{
    public partial class signUp : Form
    {
        private const string PASSWORD_DOESNT_MACH = "password doesn't mach!";
        private const string PARAM_MISSING = "at list one parameter is missing!"
                                               + "\n please try again!";
        private const string EMAIL_NOT_REGEX = "Not a legal email patteren! please try again.";
        private const string EMAIL_NOT_VALID = "email not valid! please try again.";

        public signUp()
        {
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            //check params
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
            if ( ! validEmail(email.Text, password.Text) )
            {
                error.Text = EMAIL_NOT_REGEX;
                error.Visible = true;
                return;
            }

            //try to sign newUser
            String userId = newUserName(email.Text, password.Text);
            if ( userId == null )
            {
                error.Text = EMAIL_NOT_VALID;
                error.Visible = true;
                return;
            }
            
            //set new values in user's properties table.
            Boolean success = setProperties(name.Text, email.Text,
                password.Text, userId);
            if (success)
            {
                
            }
            else
            {
                return;
            }
            confirmation confirmation = new confirmation();
            this.Hide();
            confirmation.Show();
        }

        //checks if email&password is in ok pattern
        private Boolean validEmail(String email, String password)
        {
            Boolean patternOk = false;
            //TODO check if email&password pattern ok
            patternOk = true;
            return patternOk;
        }

        //conctes to server to validate new user.
        //return string of userId
        private String newUserName(String email, String password)
        {
            //TODO. connect to server and validate
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["email"] = email;
                data["password"] = password;

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/signup.php", "POST", data);
                //MessageBox.Show("Error code: after web ");
                //contains conf code
                String body = Encoding.UTF8.GetString(response);
                char code = body[0];
                if (code == '1' || code == '2')
                {
                    MessageBox.Show("Error code: " + code);
                    return null;
                }
                else
                {
                    MessageBox.Show("Success code: " + body);
                    return body;
                }
            }
        }
        //insert user's properties
        private Boolean setProperties(String name, String email,
                                        String password, String userId)
        {
           
            const string NOT_CONFIRMED = "not confirmed";
            userId = userId.Substring(0, 32);
            User user = new User(); 
            user.Email = email;
            user.Name = name;
            user.Password = password;
            user.UserId = userId;
            user.SecurityCode = NOT_CONFIRMED;
            DBHandler.initDB();
            String result = LocalData.addUser(user);
            if (result == null)
            {
                MessageBox.Show("in set");
                return true;
            }
            //
            else
            {
                //MessageBox.Show("SQL ERROR: " + result);
            }
            return false;
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            
        }
    }
}