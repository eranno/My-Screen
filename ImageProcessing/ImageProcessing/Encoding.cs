using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImageProcessing
{

    class Encoding
    {


        Image inputImage;
        Bitmap inputBitmap;
        int SWAP = 300;
        int[,] path;
        String imageIndex;
        // Bitmap b2;

        public Encoding(String url, string index)
        {
            imageIndex = index;
            using (WebClient wc = new WebClient())
            {
                Stream strm = null;

                try
                {
                    strm = wc.OpenRead(url);
                    inputImage = Image.FromStream(strm);
                    inputBitmap = new Bitmap(inputImage);
                }
                finally
                {
                    if (strm != null)
                        strm.Close();
                }


                inputBitmap.Save("C:\\Users\\user\\pics\\stage\\fromWeb" + imageIndex + ".jpg");

            }
        }




        public static System.Drawing.Bitmap Resize(System.Drawing.Bitmap value, int newWidth, int newHeight)
        {
            System.Drawing.Bitmap resizedImage = new System.Drawing.Bitmap(newWidth, newHeight);
            System.Drawing.Graphics.FromImage((System.Drawing.Image)resizedImage).DrawImage(value, 0, 0, newWidth, newHeight);
            return (resizedImage);
        }

    }
}
