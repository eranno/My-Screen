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


namespace GUI
{
    public class Friends
    {
        public DataTable friendsSource()
        {
            return DBHandler.getTable("SELECT * FROM Friends");
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
    }
}
