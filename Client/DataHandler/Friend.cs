using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Collections.Specialized;

namespace DataHandler
{
    public class Friend
    {
        List<String> imageList;
        String name;

        

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
