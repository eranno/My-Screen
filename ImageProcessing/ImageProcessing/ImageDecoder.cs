using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Collections.Specialized;

namespace ImageProcessing
{
    public static class ImageDecoder
    {
        public static String PROGRAM_ID = "1101000100001";
        public static int SWAPS = 300;
        public static int HIGHT = 300;
        public static int WIDTH = 400;

        public static void decode_image(Bitmap image, int user_id, int image_id)
        {
            int[,] path = new int[SWAPS, 2];

            //get image key from Server
            String key = get_key();

            //split the key in to path
            split_key(image, key, path);

            //decode the image
            Decode_Image(image, path);

            //save image in DataBase



        }


        private static String get_key()
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["email"] = "noam185@gmail.com";
                data["password"] = "1234";


                var response = wb.UploadValues("http://myscreen.cu.cc/act/key.php", "POST", data);
                String key = Encoding.UTF8.GetString(response);

                return key;

            }
        }

        private static void split_key(Bitmap image, String key, int[,] path)
        {
            String[] location = key.Split(' ');
            for (int i = 0; i < SWAPS * 2; i = i + 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    path[i / 2, j] = Convert.ToInt32(location[i + j]);
                }
            }

        }

        private static void Decode_Image(Bitmap image, int[,] path)
        {
            for (int j = SWAPS - 1; j >= 0; j--)
            {
                switch_line(path[j, 0], path[j, 1], image);
            }
        }

        private static void switch_line(int y1, int y2, Bitmap image)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                Color temp = image.GetPixel(i, y1);
                image.SetPixel(i, y1, image.GetPixel(i, y2));
                image.SetPixel(i, y2, temp);
            }
        }



    }
}