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
        int SWAPS = 300;
        int HIGHT = 300;
        int WIDTH = 400;
        int[,] path;
        String imageIndex;
       

        public Encoding(String dir, string index)
        {
            imageIndex = index;
            path = new int[SWAPS, 2];

            //retreving image from directory
            inputImage = Image.FromFile(dir);
            inputBitmap = new Bitmap(inputImage);


            //resize the pic to 400 x 300 pix
            inputBitmap = Resize_Image(inputBitmap, 400, 300);

            //Encode the image
            Random_Shuffle();
            Save_Path();
            Encode_Image();

            //save encoded image
            inputBitmap.Save("C:\\Users\\user\\pics\\stage\\EncodedImage" + imageIndex + ".jpg");

        }




        public System.Drawing.Bitmap Resize_Image(System.Drawing.Bitmap value, int newWidth, int newHeight)
        {
            System.Drawing.Bitmap resizedImage = new System.Drawing.Bitmap(newWidth, newHeight);
            System.Drawing.Graphics.FromImage((System.Drawing.Image)resizedImage).DrawImage(value, 0, 0, newWidth, newHeight);
            return (resizedImage);
        }


        public void Random_Shuffle()
        {
            Random rand = new Random();

            for (int i = 0; i < (path.Length / 2); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    path[i, j] = rand.Next(HIGHT);
                }
            }
        }


        void Save_Path()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\user\\pics\\stage\\path" + imageIndex + ".txt");
            for (int j = 0; j < SWAPS; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    file.Write(path[j, k] + " ");
                }

            }
            file.Close();
        }

        public void Encode_Image()
        {
            for (int j = 0; j < SWAPS; j++)
            {
                switch_line(path[j, 0], path[j, 1]);
            }
        }

        public void switch_line(int y1, int y2)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                Color temp =inputBitmap.GetPixel(i, y1);
                inputBitmap.SetPixel(i, y1, inputBitmap.GetPixel(i, y2));
                inputBitmap.SetPixel(i, y2, temp);
            }
        }



    }
}
