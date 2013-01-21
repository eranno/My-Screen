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
