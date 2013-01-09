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
        public static string ADD_PERMISSION = "http://my.jce.ac.il/~eranno/act/add_permission.php";
        public static string REMOVE_PERMISSION = "http://my.jce.ac.il/~eranno/act/remove_permission.php";
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
            if (msg == null)
                msg = "Error: Connection to server";
            return msg;
        }
        private static string permission(string friendEmail, string imageId , string url)
        {
            string resp = null;
            string msg = null;

            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                User user = LocalData.getUserProperties();
                data["email"] = user.Email;
                data["password"] = user.Password;
                data["femail"] = friendEmail;
                data["fid"] = "";//TODO - ask eran to remove this!.
                data["serial"] = imageId;

                var response = wb.UploadValues(url, "POST", data);
                resp = Encoding.UTF8.GetString(response);
            }
            string type = null;
            if (url.Equals(ADD_PERMISSION))
                type = "granted to";
            else
                type = "removed from";
            switch (resp)
            {
                case "0":
                    msg = "Server Success: Permission "+ type + " friend";
                    break;
                case "1":
                    msg = "Server Error: invalid input";
                    break;
                case "2":
                    msg = "Server Error: Invalid user properties";
                    break;
            }
            if (msg == null)
                msg = "Error: Connection to server";
            return msg;
        }
        public static string addPermission(string friendEmail , string imageId)
        {
            return permission(friendEmail , imageId , ADD_PERMISSION) ;
        }

        public static string removePermission(string friendEmail, string imageId)
        {
            return permission(friendEmail, imageId, REMOVE_PERMISSION);
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
