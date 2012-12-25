using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Collections.Specialized;
using System.Data;

namespace DataHandler
{
    public class Friend
    {
        List<String> imageList;
        String name;

        DataTable myImages;

        public DataTable getMyImages()
        {
            if (myImages == null)
            {
                DBHandler.getTable("SELECT name FROM Images WHERE Images.id=");
            }
            return myImages;
        }

        public void setMyImages(DataTable table)
        {
            myImages = table;
        }

        public Friend(String friendName)
        {
            name = friendName;
            imageList = LocalData.getImages(friendName);
        }

        public void addImage(String path)
        {
            imageList.Add(path);
        }

        public void addImages(List<String> imgs)
        {
            imageList.AddRange(imgs);
            LocalData.addImages(name, imgs);
        }


        public List<String> getImageList()
        {
            return imageList;
        }


        public String getName()
        {
            return name;
        }
    }
}
