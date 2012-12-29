using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using DataHandler;
using System.Text.RegularExpressions;

namespace GUI
{
    public class Friends
    {

        DataTable friends;

        public Friends()
        {
            friends = DBHandler.getTable("SELECT * FROM Friends");
        }

        public bool addFriend(string email , string name)
        {
            var res = friends.Select("email = '" + email + "'");
            var regex = Regex.IsMatch(email, "@.");
            if (!regex)
            {
                MessageBox.Show("Please enter valid email");
                return false;
            }
            if (res.Length != 0)
            {
                MessageBox.Show("Friend already exist in your list");
                return false;
            }

            DataRow row = friends.NewRow();
            row["email"] = email;
            row["name"] = name;
            friends.Rows.Add(row);
            DBHandler.updateTable(friends, "SELECT * FROM Friends");
            return true;
        }

        public DataTable getFriendImagesSource(string friendId)
        {
            string friendImages = "SELECT Images.* FROM AuthImages , Images WHERE friendId=" + "'" + friendId + "'" + " AND imageId=id";
            string allImages = "SELECT * FROM Images";
            return DBHandler.getTable(allImages + " EXCEPT " + friendImages);
        }
        public void addImageToFriend(string friendId ,string imageId, string path )
        {
            try
            {
                DBHandler.insert("INSERT INTO AuthImages(imageId , friendId) VALUES('" + imageId + "' , '" + friendId +"')");
            }
            catch (KeyNotFoundException e) 
            {
                MessageBox.Show("There is no friend with email Id: " + friendId);
            }
        }

        public Dictionary<DataRow , Image> getMyImages(String email)
        {
           Dictionary<DataRow , Image> map = new Dictionary<DataRow,Image>();
                  
               DataTable table = DBHandler.getTable("SELECT * FROM AuthImages , Images WHERE friendId=" + "'" + email + "'" + " AND imageId=id");
                foreach (DataRow row in table.Rows)
                {
                    string path = row["pathThumb"].ToString();
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs);
                        map.Add(row , img);
                    }
                }
            return map;
        }
           
        
        public DataTable friendsSource()
        {
            return friends;
        }

       

    }
}
