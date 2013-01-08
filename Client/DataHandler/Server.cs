using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Specialized;
using System.Net;


namespace DataHandler
{
    public class Server
    {
        public static string SUCCESS = "Server Success:";
        //TODO generalize server methods!
        public static string addContact(Friend friend)
        {
            string resp = null;
            string msg = null; 
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                User user = LocalData.getUserProperties();
                data["email"] = user.Email;
                data["password"] = user.Password;
                data["femail"] = friend.Email;
                data["fid"] = friend.FriendId;

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/add_contact.php", "POST", data);
                resp = Encoding.UTF8.GetString(response);
            }

            switch (resp)
            {
                case "0":
                    msg = "Server Success: Friend added to server";
                    break;
                case "1":
                    msg = "Server Error: invalid input";
                    break;
                case "2":
                    msg = "Server Error: Invalid user properties";
                    break;
            }


            return msg;
        }

        public static string addPermission(Friend friend , string key)
        {
            string resp = null;
            string msg = null;
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                User user = LocalData.getUserProperties();
                data["email"] = user.Email;
                data["password"] = user.Password;
                data["femail"] = friend.Email;
                data["fid"] = friend.FriendId;
                data["serial"] = key;

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/add_permission.php", "POST", data);
                resp = Encoding.UTF8.GetString(response);
            }

            switch (resp)
            {
                case "0":
                    msg = "Server Success: Permission granted to user";
                    break;
                case "1":
                    msg = "Server Error: invalid input";
                    break;
                case "2":
                    msg = "Server Error: Invalid user properties";
                    break;
            }
            return msg;
        }

        public static string buildJson()
        {

            JObject json = prepareJson();
            
            DataTable table = DBHandler.getTable("SELECT * FROM Images");
            List<object> list = new List<object>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new JProperty(row["id"].ToString(), row["name"].ToString()));
            }
            JObject obj = new JObject(list.ToArray());
            JProperty prop = new JProperty("add_images", obj);
            json.Add(prop);
            return json.ToString();
        }

        private static JObject prepareJson()
        {
            User user = LocalData.getUserProperties();

            List<object> l = new List<object>();

            l.Add(new JProperty("id", user.UserId));
            l.Add(new JProperty("email", user.Email));
            l.Add(new JProperty("password", user.Password));

            JObject o = new JObject(l.ToArray());
            JProperty p = new JProperty("login", o);
            JObject o2 = new JObject(p);
            return o2;
        }
    }
}
