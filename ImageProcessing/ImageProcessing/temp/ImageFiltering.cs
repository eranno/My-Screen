using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using GUI;
using System.Collections.Specialized;

 
 
namespace ImageProcessing
{
    class ImageFiltering
    public static class ImageFiltering
    {
        Dictionary<String, String> images;
        String PROGRAM_ID = "1101000100001";
        
        public static String PROGRAM_ID = "1101000100001";

        public static void ImageFilter()
        {
            String url;
            while (true)
            {
                url = Messages.read();
                if (url != null)
                {
                    filter_by_image(url);
                }
            }

        }

        private static void filter_by_image(String url)
        {
            if (url.EndsWith(".jpg"))
            {
                filter_by_imageID(url);
            }
        }


        private static void filter_by_imageID(String url)
        {
            Bitmap image = get_image_from_url(url);
            bool result2 = image.Width == 400 && image.Height == 300;
            int program_id = get_program_id(image);
            bool result1 = program_id == Convert.ToInt32(PROGRAM_ID, 2); 
            if (result1 && result2)
            {
                //anlyse image id
                filter_by_Permissions(image);
            }
 
        }

 


        private static void filter_by_Permissions(Bitmap image)
        {

            //check permission from server/Data Base
            int user_id = get_user_id(image);
            int image_id = get_image_id(image);

            //check permission
            using (var wb = new WebClient())
             {
                var data = new NameValueCollection();
                data["email"] = "noam185@gmail.com";
                data["password"] = "1234";


                var response = wb.UploadValues("http://myscreen.cu.cc/act/permission.php", "POST", data);
                String permission = Encoding.UTF8.GetString(response);

                if (permission[0] == 0)//check with eran
                {
                    //Decode
                    ImageDecoder.decode_image(image);
                }

             }

        }

        private static int  get_user_id(Bitmap image)
        {
            String str_id = "";
            int pos;
            for (int x = 0; x < 32; x++)
            {
                pos = x + PROGRAM_ID.Length + 32;
                Color temp = image.GetPixel(pos, 0);
                int avg_color = (temp.R + temp.G + temp.B) / 3;
                if (avg_color >= 128)//White
                {
                    str_id += "0";
                }
                else//Black
                {
                    str_id += "1";
                }
            }
            int id = Convert.ToInt32(str_id,2);
            return id;
        }

 
         

        private static int get_image_id(Bitmap image)
        {
            String str_id = "";
            int pos;
            for (int x = 0; x < 32; x++)
            {
                pos = x + PROGRAM_ID.Length;
                Color temp = image.GetPixel(pos, 0);
                int avg_color = (temp.R + temp.G + temp.B) / 3;
                if (avg_color >= 128)//White
                {
                    str_id += "0";
                }
                else//Black
                {
                    str_id += "1";
                }
            }
            int id = Convert.ToInt32(str_id,2);
            return id;
        }

        private static int get_program_id(Bitmap inputBitmap)
        {
            String str_id = "";
            int pos;
            for (int x = 0; x < 32; x++)
            {
                pos = x ;;
                Color temp = image.GetPixel(pos, 0);
                int avg_color = (temp.R + temp.G + temp.B) / 3;
                if (avg_color >= 128)//White
                {
                    str_id += "0";
                }
                else//Black
                {
                    str_id += "1";
                }
            }
 

            int id = Convert.ToInt32(num_str, 2);
            return id;
        }
 

        private static Bitmap get_image_from_url(String url)
        {

             Bitmap inputBitmap;
             using (WebClient wc = new WebClient())
             {
                Stream strm = null;
                try
                {
					strm = wc.OpenRead(url);

					Image inputImage = Image.FromStream(strm);
					inputBitmap = new Bitmap(inputImage);
                }
                finally
				{
					strm.Close();
                }
             }

             return inputBitmap;
         }

     }
 }
