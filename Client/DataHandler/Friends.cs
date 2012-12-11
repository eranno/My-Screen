using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DataHandler
{
    public class Friends
    {
        List<Friend> allFriends;
        Friend currentFriend;
        public Friends()
        {
            allFriends = new List<Friend>();
        }

        public void loadFriends()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(LocalData.FRIENDS_DATA);
            foreach (XmlNode node in doc.SelectNodes("Friends/Friend"))
            {
                String name = node.SelectSingleNode("Name").InnerText;
                Friend friend = new Friend(name);
                foreach (XmlNode childNode in node.SelectNodes("Image"))
                {
                    friend.addImage(childNode.InnerText);
                }
               
                allFriends.Add(friend);
            }
        }

        public List<Friend> getFriends()
        {
            return allFriends;
        }

        public void addFriend(Friend friend)
        {
            allFriends.Add(friend);
        }
        public void addFriend(String name)
        {
            allFriends.Add(new Friend(name));
        }

        public void setCurrentFriend(String name)
        {
            foreach (Friend f in allFriends)
            {
                if (f.getName().Equals(name))
                {
                    currentFriend = f;
                    break;
                }
            }

        }

    }
}
