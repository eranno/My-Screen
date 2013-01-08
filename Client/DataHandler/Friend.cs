using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataHandler
{
    public class Friend
    {
        private string _Email;
        private string _Name;
        private string _FriendId;

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

        public string FriendId
        {
            set { this._FriendId = value; }
            get { return this._FriendId; }
        }
        public string insert()
        {
            string msg = null;
            string response = Server.addContact(this);
            if (response != null && response.Contains(Server.SUCCESS))
            {
                msg = DBHandler.insert("INSERT INTO Friends(email , name , userId) VALUES('" + _Email + "', '" + _Name + "', '" + _FriendId + "')");
                if (msg == null)
                    msg = response;
            }
            if (msg == null)
                msg = response;
            return msg;
        }
        public bool isExistInDB()
        {
            bool result = false;
            if (_Email != null)
            {
                DataTable table = DBHandler.getTable("SELECT * FROM Friends WHERE email='" + Email + "'");
                if (table.Rows.Count == 1)
                    result = true;
            }
            return result;
        }
    }
}
