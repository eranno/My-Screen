using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Data;

namespace DataHandler
{
    public class LocalData
    {
        public static void createThumb(List<string> files)
        {
            Thread t = new Thread(LocalData.workerThumbs);
            t.Start(files); 
        }

        private static void workerThumbs(object files)
        {
            List<string> imgFiles = files as List<string>;
            foreach (String fileName in imgFiles)
            {
                using (Image image = Image.FromFile(fileName))
                {
                    Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                    string newFile = Path.ChangeExtension(fileName, "thumb");
                    string loc = "Thumbnails\\" + Path.GetFileName(newFile);
                    thumb.Save(loc);
                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string type = Path.GetExtension(fileName);
                    DBHandler.insert("INSERT INTO Images(name , pathThumb , pathOriginal , type) VALUES(" + "'" + name + "'" + ", " + "'" + loc + "'" + " , " + "'" + fileName + "'" + " , " + "'" + type + "'" + ")");
                }
            }
        }

        public static void removeImageFromFriend(string imageId , string friendId)
        {
            DBHandler.executeCmd("DELETE FROM AuthImages WHERE imageId=" + imageId + " AND friendId=" + "'" + friendId + "'");
        }

        public static void insertEncryptedImage(EncryptedImage encryptedImage)
        {
            DBHandler.insert("INSERT INTO Images(idx , name , key , type , pathEncrypted , pathThumb , pathOriginal) VALUES('" + encryptedImage.Idx + "' , '" + encryptedImage.Name + "' , '" + encryptedImage.Key + "' , '" + encryptedImage.Type + "' ,'" + encryptedImage.PathEncrypted + "' , '" + encryptedImage.PathThumb + "' , '" + encryptedImage.PathOriginal + "')");
        }

        public static void updateEncryptedImage(EncryptedImage encryptedImage)
        {
            StringBuilder sb = new StringBuilder();  
            sb.Append("idx='" + encryptedImage.Idx + "',");
            sb.Append("name='" + encryptedImage.Name + "',");
            sb.Append("key='" + encryptedImage.Key + "',");
            sb.Append("type='" + encryptedImage.Type + "',");
            sb.Append("pathEncrypted='" + encryptedImage.PathEncrypted + "',");
            sb.Append("pathThumb='" + encryptedImage.PathThumb + "',");
            sb.Append("pathOriginal='" + encryptedImage.PathOriginal + "'");
            DBHandler.executeCmd("UPDATE Images SET " + sb + " WHERE pathOriginal='" + encryptedImage.PathOriginal +"'");
        }

        public static User getUserProperties()
        {
            DataRow row = DBHandler.getTable("SELECT * FROM UserProperties").Rows[0];
            User user = new User(); 
            user.Email = row["email"].ToString();
            user.UserId = row["userId"].ToString();
            user.Name = row["name"].ToString();
            user.Password = row["password"].ToString();
            user.SecurityCode = row["securityCode"].ToString();
            return user;
        }

        public static string addUser(User user)
        { 
            return DBHandler.insert("INSERT INTO UserProperties(email , name , userId , password , securityCode) VALUES('" + user.Email + "' , '" + user.Name + "' , '" + user.UserId +  "' ,'" + user.Password + "' , '" + user.SecurityCode + "')");
        }
        public static string deleteUser(User user)
        {
            return DBHandler.executeCmd("DELETE FROM UserProperties WHERE email='" + user.Email +"'");
        }

        public static string updateUser(User user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("email='" + user.Email + "',");
            sb.Append("userId='" + user.UserId + "',");
            sb.Append("name='" + user.Name + "',");
            sb.Append("password='" + user.Password + "',");
            sb.Append("securityCode='" + user.SecurityCode + "',");
            sb.Append("imageId='" + user.ImageId + "'");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(sb);
            Console.WriteLine();
            return DBHandler.executeCmd("UPDATE UserProperties SET " + sb + " WHERE email='" + user.Email + "'");
        }
    }

}
