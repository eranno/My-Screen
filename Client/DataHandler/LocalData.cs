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

        public static Friends friends;

        public LocalData()
        {
            createLocalFolders();
            createDataFiles();
            friends = new Friends();
            friends.loadFriends();

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
            friends.addFriend(name);
            return true;

        }
        public static List<String> getImages(String name){
            XmlDocument doc = new XmlDocument();
            doc.Load(FRIENDS_DATA);
            List<String> imgs = new List<String>();
            foreach (XmlNode node in doc.SelectNodes("Friends/Friend"))
            {
                XmlNode childNode = node.SelectSingleNode("Name");
                String friendName = childNode.InnerText;
                friendName = friendName.ToLower();
                name = name.ToLower();
                if (name.Equals(friendName))
                {
                   
                    foreach (XmlNode friendNode in childNode.SelectNodes("Friends/Friend/Image"))
                    {
                        imgs.Add(friendNode.InnerText);
                    }
                   
                }
            }
            return imgs;
        }

        public static void addImages(String name, List<String> images)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FRIENDS_DATA);
            foreach (XmlNode node in doc.SelectNodes("Friends/Friend"))
            {
                XmlNode childNode = node.SelectSingleNode("Name");
                String friendName = childNode.InnerText;
                friendName = friendName.ToLower();
                name = name.ToLower();
                if (name.Equals(friendName))
                {
                    foreach (String im in images)
                    {
                        XmlNode image = doc.CreateElement("Image");
                        image.InnerText = im;
                        node.AppendChild(image);
                    }
                    break;
                }
            }
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
