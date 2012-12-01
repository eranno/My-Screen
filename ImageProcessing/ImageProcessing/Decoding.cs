using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImageProcessing
{
    class Decoding
    {

        Image inputImage;
        Bitmap inputBitmap;
        int SWAPS = 300;
        int HIGHT = 300;
        int WIDTH = 400;
        int[,] path;
        String imageIndex;

        public Decoding(String url, string index)
        {

            imageIndex = index;
            path = new int[SWAPS, 2];

            //retreving image from url
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
            }

            //get path for decoding from file 
            Deoding_Path_reader();

            //decodes the image
            Decode_Image();

            //save encoded image
            inputBitmap.Save("C:\\Users\\user\\pics\\stage\\DecodedImage" + imageIndex + ".jpg");


        }

        public void Deoding_Path_reader()
        {
            StreamReader sr = new StreamReader("C:\\Users\\user\\pics\\stage\\path" + imageIndex + ".txt");
            string[] words = sr.ReadToEnd().Split(' ');

            for (int i = 0; i < SWAPS * 2; i = i + 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    path[i / 2, j] = Convert.ToInt32(words[i + j]);
                }
            }
            
        }

        public void Decode_Image()
        {
            for (int j = SWAPS - 1; j >= 0; j--)
            {
                switch_line(path[j, 0], path[j, 1]);
            }
        }

        public void switch_line(int y1, int y2)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                Color temp = inputBitmap.GetPixel(i, y1);
                inputBitmap.SetPixel(i, y1, inputBitmap.GetPixel(i, y2));
                inputBitmap.SetPixel(i, y2, temp);
            }
        }



    }
}
