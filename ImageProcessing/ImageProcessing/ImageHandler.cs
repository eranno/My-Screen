using System.Drawing;
using System.IO;
using System.Threading;
//using System.Collections;
using System.Collections.Generic;
using System;
using DataHandler;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public static class ImageHandler
    {
        public static void createThumb(List<string> files)
        {
            Thread t = new Thread(ImageHandler.Encrypt);
            t.Start(files);
        }

        private static void Encrypt(object files)
        {
            List<string> imgFiles = files as List<string>;
            /*
            Parallel.ForEach(imgFiles, fileName =>
            {
            
            }
            );
             */
            foreach (String fileName in imgFiles)
            {
                Image image = Image.FromFile(fileName);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                string newFile = Path.ChangeExtension(fileName, "thumb");
                string loc = "Thumbnails\\" + Path.GetFileName(newFile);
                thumb.Save(loc);
                string name = Path.GetFileNameWithoutExtension(fileName);
                string type = Path.GetExtension(fileName);
                DBHandler.insert("INSERT INTO Images(name , pathThumb , pathOriginal , type) VALUES(" + "'" + name + "'" + ", " + "'" + loc + "'" + " , " + "'" + fileName + "'" + " , " + "'" + type + "'" + ")");

                ImageEncoder.EncodeImage(fileName);
            }

        }
    }
}