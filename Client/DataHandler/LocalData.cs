using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Threading;

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
                Image image = Image.FromFile(fileName);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                string newFile = Path.ChangeExtension(fileName, "thumb");
                string loc = "Thumbnails\\" + Path.GetFileName(newFile);
                thumb.Save(loc);
                string name = Path.GetFileNameWithoutExtension(fileName);
                string type = Path.GetExtension(fileName);
                DBHandler.insert("INSERT INTO Images(name , pathThumb , pathOriginal , type) VALUES(" + "'" + name + "'" + ", " + "'" + loc + "'" + " , " + "'" + fileName + "'" + " , " +  "'" + type + "'"+ ")");
            }
        }
    }

}
