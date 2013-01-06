using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Collections.Specialized;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace DataHandler
{
    public class Friend
    {
        List<String> imageList;
        DataRow details;
            
        ImageList myImages = null;

        public ImageList getMyImages()
        {
            if (myImages == null)
            {
                myImages = new ImageList();
                myImages.ImageSize = new System.Drawing.Size(100, 100);
                myImages.ColorDepth = ColorDepth.Depth32Bit;

                string email = details["email"].ToString();
                DataTable table = DBHandler.getTable("SELECT * FROM AuthImages , Images WHERE friendId=" + "'" + email + "'" + " AND imageId=id");
                foreach (DataRow row in table.Rows)
                {
                    string path = row["pathThumb"].ToString();
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (Image img = Image.FromStream(fs))
                        {
                            myImages.Images.Add(img);
                        }
                    }
                }
            }       
            return myImages;
        }

        public Friend (DataRow details)
        {
            this.details = details;
        }

        private void fillImages()
        {
            //threading
        }

        public void addImage(String path)
        {
            imageList.Add(path);
        }

        public List<String> getImageList()
        {
            return imageList;
        }

    }
}
