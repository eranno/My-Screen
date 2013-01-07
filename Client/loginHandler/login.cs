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
    public partial class login : Form
    {
        private const string PASSWORD_DOESNT_MACH = "password isn't correct! try again";
        private const string PARAM_MISSING = "at list one parameter is missing!"
                                               + "\n please try again!";
        private const string EMAIL_NOT_VALID = "email not valid! please try again.";

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            error.Visible = false;
            if (email.Text == "" || password.Text == "")
            {
                error.Text = PARAM_MISSING;
                error.Visible = true;
                return;
            }
            Boolean confirmed = checkUserName(this.email.Text, this.password.Text);
            if (!confirmed)
            {
                error.Text = PASSWORD_DOESNT_MACH;
                error.Visible = true;
                return;
            }
            else
            {
                MessageBox.Show("Login successfull!\ncontinue to MyScreen");
            }
                
            MainForm MainForm = new MainForm();
            this.Hide();
            MainForm.Show();

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        //conctes to server to validate new user.
        //return string of confirmation code
        private Boolean checkUserName(String email, String password)
        {

            Boolean confirmed = false;
            String sql;
            //*****************************
            //tester: insert what you want, and delete right after...
            DBHandler.initDB();
            
            
            DBHandler.showTables();
            sql = "DELETE FROM UserProperties WHERE `email` like '%'";
            DBHandler.executeCmd(sql);
            sql = "INSERT INTO UserProperties"
                            + "(`email`,`password`)"
                            + "VALUES('" + email + "','" + password + "')";
            DBHandler.insert(sql);
            //end tester
            //*****************************
            //check ip password matches
            sql = "SELECT `email`, `password` FROM UserProperties "
                            + "WHERE `email`= '" + email+"'";
            DataTable userProps = DBHandler.getTable(sql);
            foreach (DataRow row in userProps.Rows)
            {
                if (row["password"].ToString() == password)
                {
                    confirmed = true;
                } 
                break;
            }
            return confirmed;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signUp signUp = new signUp();
            this.Hide();
            signUp.Show();
        }
    }
}
