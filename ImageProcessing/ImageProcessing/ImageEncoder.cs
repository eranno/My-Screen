using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using DataHandler;

namespace ImageProcessing
{
    class ImageEncoder
    {

        public static String PROGRAM_ID = "1101000100001";
        public static int SWAPS = 300;
        public static int HIGHT = 300;
        public static int WIDTH = 400;

        public static void EncodeImage(String dir, EncryptedImage imageData)
        {
            Image inputImage;
            Bitmap inputBitmap;
            int[,] path = new int[SWAPS, 2];
            String ImageKey;



            //retreving image from directory
            inputImage = Image.FromFile(dir);
            inputBitmap = new Bitmap(inputImage);


            //resize the pic to 400 x 300 pix
            inputBitmap = Resize_Image(inputBitmap, WIDTH, HIGHT);

            //save program id 13 bit in image <0 .. 12>
            make_id(inputBitmap);

            //save user id 32 bit in image <13 .. 44>
            make_user_id(inputBitmap);

            //get image id
            String imageID = LocalData.getUserProperties().idx;

            //save image id 32 bit in image <45 .. 76>
            make_image_id(inputBitmap, imageID);

            //Encode the image
            Random_Shuffle(path);
            ImageKey = Save_Path(path);
            Encode_Image(path, inputBitmap);

            //send image info to server
            bool send = send_to_server(ImageKey);
            if (send)
            {
                //save encoded image
                string loc = "EncodedImages\\" + Path.GetFileName(dir);
                inputBitmap.Save(loc);

                //save image in dataBase
                save_in_dataBase(imageData, imageID, ImageKey, loc);
            }

        }



        private static void save_in_dataBase(EncryptedImage imageData, String imageId, String imageKey, String imagePath)
        {
            imageData.Idx = imageId;
            imageData.Key = imageKey;
            imageData.PathEncrypted = imagePath;
            LocalData.updateEncryptedImage(imageData);
        }

        private static bool send_to_server(String ImageKey)
        {


            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                User user = LocalData.getUserProperties();
                data["email"] = user.Email;
                data["password"] = user.Password;
                data["serial"] = user.ImageId;

                //idx ++;

                data["rsa"] = ImageKey;

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/add_image.php", "POST", data);
                String body = Encoding.UTF8.GetString(response);
                char code = body[0];
                if (code != '0')
                    return false;

            }
            return true;
        }

        public static void make_user_id(Bitmap inputBitmap)
        {
            String USER_ID = "00000000000000000000000000000000";
            //String USER_ID = LocalData.getUserProperties().UserId;
            if (USER_ID != null)
            {
                int pos;
                for (int x = 0; x < USER_ID.Length; x++)
                {
                    pos = x + PROGRAM_ID.Length;
                    if (USER_ID[x] == '0')
                        inputBitmap.SetPixel(pos, 0, Color.White);
                    else
                        inputBitmap.SetPixel(pos, 0, Color.Black);
                }
            }
            else
            {
                //Error
            }


        }

        public static void make_image_id(Bitmap inputBitmap, String imageID)
        {

            String IMAGE_ID = "11111111111111111111111111111111";
            int pos;
            for (int x = 0; x < IMAGE_ID.Length; x++)
            {
                pos = x + PROGRAM_ID.Length + 32;
                if (IMAGE_ID[x] == '0')
                    inputBitmap.SetPixel(pos, 0, Color.White);
                else
                    inputBitmap.SetPixel(pos, 0, Color.Black);
            }
        }

        public static System.Drawing.Bitmap Resize_Image(System.Drawing.Bitmap value, int newWidth, int newHeight)
        {
            System.Drawing.Bitmap resizedImage = new System.Drawing.Bitmap(newWidth, newHeight);
            System.Drawing.Graphics.FromImage((System.Drawing.Image)resizedImage).DrawImage(value, 0, 0, newWidth, newHeight);
            return (resizedImage);
        }


        public static void Random_Shuffle(int[,] path)
        {

            Random rand = new Random();

            for (int i = 0; i < (path.Length / 2); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    path[i, j] = rand.Next(HIGHT - 1) + 1;//[1,HIGHT]
                }
            }

        }


        private static String Save_Path(int[,] path)
        {
            String ImageKey = "";
            //System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Public\\path" + imageIndex + ".txt");
            for (int j = 0; j < SWAPS; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    //file.Write(path[j, k] + " ");
                    ImageKey += (path[j, k] + " ");
                }

            }

            return ImageKey;
            //file.Close();
        }

        public static void Encode_Image(int[,] path, Bitmap inputBitmap)
        {
            for (int j = 0; j < SWAPS; j++)
            {
                switch_line(path[j, 0], path[j, 1], inputBitmap);
            }
        }

        public static void switch_line(int y1, int y2, Bitmap inputBitmap)
        {
            for (int i = 0; i < inputBitmap.Width; i++)
            {
                Color temp = inputBitmap.GetPixel(i, y1);
                inputBitmap.SetPixel(i, y1, inputBitmap.GetPixel(i, y2));
                inputBitmap.SetPixel(i, y2, temp);
            }
        }


        public static void make_id(Bitmap inputBitmap)
        {
            for (int x = 0; x < PROGRAM_ID.Length; x++)
            {
                if (PROGRAM_ID[x] == '0')
                    inputBitmap.SetPixel(x, 0, Color.White);
                else
                    inputBitmap.SetPixel(x, 0, Color.Black);
            }
        }


    }
}
