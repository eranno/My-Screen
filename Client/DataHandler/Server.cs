using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Specialized;


namespace DataHandler
{
    public class Server
    {
        public static void sync()
        {

            
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
