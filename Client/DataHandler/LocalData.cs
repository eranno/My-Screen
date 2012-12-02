using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace DataHandler
{
    //This class should be singelton.
    public class LocalData
    {
        public static String ENCRYPTED_FILES_FD = "Encrypted Files";
        public static String ENCRYPTED_IMAGES_FD = "Encrypted Files\\Encrypted Images";
        public static String DATA_FD = "Data";

        public static String ENCRYPTED_IMAGES_THUMBNAIL_FD = "Encrypted Files\\Encrypted Images Thumbnail";
        public static String ENCRYPTED_IMAGES = "Encrypte Files\\EncryptedImages.xml";
        public static String FRIENDS_DATA = "Data\\FriendsData.xml";
        public static String FRIEND_AUTH_IMG = "Data\\FriendAuthImages.xml";
        

        public LocalData()
        {
            createLocalFolders();
            createDataFiles();
            //fillData();
        }

        private void createLocalFolders()
        {
            if (!Directory.Exists(ENCRYPTED_FILES_FD))
            {
                Directory.CreateDirectory(ENCRYPTED_FILES_FD);
                if (!Directory.Exists(ENCRYPTED_IMAGES_THUMBNAIL_FD))
                    Directory.CreateDirectory(ENCRYPTED_IMAGES_THUMBNAIL_FD);
                if (!Directory.Exists(ENCRYPTED_IMAGES_FD))
                    Directory.CreateDirectory(ENCRYPTED_IMAGES_FD);
            }
            if(!Directory.Exists(DATA_FD))
                Directory.CreateDirectory(DATA_FD);

           
        }
        private void createDataFiles()
        {
            if (!File.Exists(FRIENDS_DATA))
            {
                XmlTextWriter xWriter = new XmlTextWriter(FRIENDS_DATA, Encoding.UTF8);
                xWriter.WriteStartElement("Friends");
                xWriter.WriteEndElement();
                xWriter.Close();
            }
            if (!File.Exists(FRIEND_AUTH_IMG))
            {
                XmlTextWriter xWriter2 = new XmlTextWriter(FRIEND_AUTH_IMG, Encoding.UTF8);
                xWriter2.WriteStartElement("Friend");
                xWriter2.WriteEndElement();
                xWriter2.Close();
            }
            if (!File.Exists(FRIEND_AUTH_IMG))
            {
                XmlTextWriter xWriter2 = new XmlTextWriter(FRIEND_AUTH_IMG, Encoding.UTF8);
                xWriter2.WriteStartElement("Friend");
                xWriter2.WriteEndElement();
                xWriter2.Close();
            }
        }

        public void fillData()
        {
            String[] fds = { "Noam Tzuime", "Ilan Ben Tal" };
            XmlDocument doc = new XmlDocument();
            doc.Load(FRIENDS_DATA);
            foreach (String s in fds)
            {
                XmlNode friend = doc.CreateElement("Friend");
                XmlNode name = doc.CreateElement("Name");
                name.InnerText = s;
                friend.AppendChild(name);
                doc.DocumentElement.AppendChild(friend);
            }
            doc.Save(FRIENDS_DATA);
        }

        public static bool addFriend(String name)
        {
            if (isFriendExist(name) || name.Equals(""))
                return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(FRIENDS_DATA);
            XmlNode friend = doc.CreateElement("Friend");
            XmlNode friendName = doc.CreateElement("Name");
            friendName.InnerText = name;
            friend.AppendChild(friendName);
            doc.DocumentElement.AppendChild(friend);
            doc.Save(FRIENDS_DATA);
            return true;

        }
        public static bool isFriendExist(String name)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FRIENDS_DATA);
            foreach (XmlNode node in doc.SelectNodes("Friends/Friend/Name"))
            {
                String existName = node.InnerText;
                existName = existName.ToLower();
                name = name.ToLower();
                if (name.Equals(existName))
                    return true;
            }
            return false;
        }
    }
}
