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

        Dictionary<String ,ImageList> images;
        DataTable friends;

        public Friends()
        {
            friends = DBHandler.getTable("SELECT * FROM Friends");
            images = new Dictionary<String, ImageList>(); 
        }

        public void addFriend(string email , string name)
        {
            DataRow row = friends.NewRow();
            row["email"] = email;
            row["name"] = name;
            friends.Rows.Add(row);
            DBHandler.updateTable(friends, "SELECT * FROM Friends");
        }

        public DataTable getFriendImagesSource(string friendId)
        {
            string friendImages = "SELECT Images.* FROM AuthImages , Images WHERE friendId=" + "'" + friendId + "'" + " AND imageId=id";
            string allImages = "SELECT * FROM Images";
            return DBHandler.getTable(allImages + " EXCEPT " + friendImages);
        }
        public void addImageToFriend(string friendId ,string imageId, string path )
        {
            ImageList myImages = null;
            try
            {
                myImages = images[friendId];
                DBHandler.insert("INSERT INTO AuthImages(imageId , friendId) VALUES('" + imageId + "' , '" + friendId +"')");
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Image img = Image.FromStream(fs);
                    myImages.Images.Add(img);
                }
            }
            catch (KeyNotFoundException e) 
            {
                MessageBox.Show("There is no friend with email Id: " + friendId);
            }
        }

        public ImageList getMyImages(String email)
        {
            ImageList myImages = null;
            try
            {
                myImages = images[email];
            }
            catch (KeyNotFoundException e)
            {
            }
            if (myImages == null)
            {
                myImages = new ImageList();
                myImages.ImageSize = new System.Drawing.Size(80, 80);
                myImages.ColorDepth = ColorDepth.Depth32Bit;
   
                DataTable table = DBHandler.getTable("SELECT * FROM AuthImages , Images WHERE friendId=" + "'" + email + "'" + " AND imageId=id");
                foreach (DataRow row in table.Rows)
                {
                    string path = row["pathThumb"].ToString();
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs);
                      myImages.Images.Add(img);
                    }
                }
                images.Add(email, myImages);
            }
            return myImages;
        }
        public DataTable friendsSource()
        {
            return friends;
        }

       

    }
}
