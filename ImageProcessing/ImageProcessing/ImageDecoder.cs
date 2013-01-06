using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUI;
using System.Net;
using System.IO;
using System.Drawing;
using System.Collections.Specialized;

namespace ImageProcessing
{
    public static class ImageDecoder
    {
        public static String PROGRAM_ID = "1101000100001";

        public static void decode_image(Bitmap image)
        {

            get_key();
        }


        private static void get_key()
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["email"] = "noam185@gmail.com";
                data["password"] = "1234";


                var response = wb.UploadValues("http://myscreen.cu.cc/act/key.php", "POST", data);
                String key = Encoding.UTF8.GetString(response);

            }
        }


    }
}