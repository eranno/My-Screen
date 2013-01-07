﻿using System;
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
        private const string EMAIL_NOT_VALID = "email not valid! please try again.";

        public signUp()
        {
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DBHandler.showTables());
            //tester
            //confirmation confirmation = new confirmation();
            //this.Hide();
            //confirmation.Show();
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

<<<<<<< HEAD
            String confCode = validEmail(email.Text, password.Text);
            if (confCode == null )
=======
            String id = validEmail(email.Text, password.Text);
            if (id == null)
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
            {
                error.Text = EMAIL_NOT_VALID;
                error.Visible = true;
                return;
            }
            
            //set new values in user's properties table.
            //
            Boolean success = setProperties(name.Text, email.Text,
<<<<<<< HEAD
                password.Text, confCode);
            //Boolean success = setProperties("name.Text", "email.Text",
            //    "password.Text", "confCode");
            //
            if (success) MessageBox.Show("Login successfull!\ncontinue to MyScreen");
=======
                password.Text, id);
            //Boolean success = setProperties("name.Text", "email.Text",
            //    "password.Text", "confCode");
            //
            if (success)
            {
                //MessageBox.Show("Login successfull!\ncontinue to MyScreen");
            }
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
            else
            {
                return;
            }
<<<<<<< HEAD
            MainForm MainForm = new MainForm();
            this.Hide();
            MainForm.Show();
=======
            confirmation confirmation = new confirmation();
            this.Hide();
            confirmation.Show();
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
        }

        //checks if email is valid
        private String validEmail(String email, String password)
        {
            //send to newUserName method in order to check if user is valid. 
            return newUserName(email, password);
        }

        //conctes to server to validate new user.
        //return string of confirmation code
        private String newUserName(String email, String password)
        {
            //TODO. connect to server and validate
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["email"] = email;
                data["password"] = password;

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/signup.php", "POST", data);
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
<<<<<<< HEAD
                    MessageBox.Show("Success code: " + code);
=======
                    MessageBox.Show("Success code: " + body);
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
                    return body;
                }
            }
        }
        //insert user's properties
        private Boolean setProperties(String name, String email,
<<<<<<< HEAD
                                        String password, String securityCode)
=======
                                        String password, String userId)
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
        {
            String sql;
            //TODO. connect to user's DB and update
            //get confirmation code
            //***************************
            //tester
            sql = "DELETE FROM UserProperties WHERE `email` like '%'";
            DBHandler.executeCmd(sql);
            //end tester
            //**************************
<<<<<<< HEAD
            sql = "INSERT INTO UserProperties"
                            + "(email , name , password , securityCode)"
                            + "VALUES('"+email+"and','"+name+"','"+password+"','"
                            +securityCode+"')";
=======
            userId = userId.Substring(0, 20);
            sql = "INSERT INTO UserProperties"
                            + "(email , name , password , userId)"
                            + "VALUES('"+email+"and','"+name+"','"+password+"','"
                            + userId + "')";
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
            /*
            sql = "INSERT INTO UserProperties(email , name , password , securityCode)"
            +"VALUES('myComp@gmail.com', 'localhost' , '123456' ,"
            +"'187365543208213678653094')";
            */
            MessageBox.Show(DBHandler.insert(sql));
            
<<<<<<< HEAD
            MessageBox.Show(DBHandler.showTables());
=======
            //MessageBox.Show(DBHandler.showTables());
>>>>>>> c3b3579d67b99a1e5fff5fcab49b2bbbcf6a58b4
            return true;
        }
    }
}