using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHandler
{
    public class User
    {
        private string _Email;
        private string _Name;
        private string _Password;
        private string _SecurityCode;
        private string _UserId;
        private string _ImageId;

        public string Email
        {
            set { this._Email = value; }
            get { return this._Email; }
        }
        public string Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }

        public string Password
        {
            set { this._Password = value; }
            get { return this._Password; }
        }
        public string SecurityCode
        {
            set { this._SecurityCode = value; }
            get { return this._SecurityCode; }
        }
        public string UserId
        {
            set { this._UserId = value; }
            get { return this._UserId; }
        }
        public string ImageId
        {
            set { this._ImageId = value; }
            get { return this._ImageId; }
        }
    }
}
