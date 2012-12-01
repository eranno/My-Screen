using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ImageProcessing
{
    class ImageFiltering
    {
        String[] images;
        String PROGRAM_ID = "1101000100001";


        public ImageFiltering(String[] images)
        {
            this.images = images;

            Parallel.For(0, this.images.Length, (i) =>
            {
                //anlyse image id
                check_id(i);
            });

        }

        public void check_id(int index)
        {
            Bitmap imageBitmap;
            imageBitmap = get_image_from_url(images[index]);
            String id = get_id(imageBitmap);
            if (id == PROGRAM_ID)
            {
                Decoding d = new Decoding(images[index], index.ToString());
            }

           

        }

        public String get_id(Bitmap inputBitmap)
        {
            String num_str = "";
            for (int x = 0; x < PROGRAM_ID.Length; x++)
            {
                Color tempPixel = inputBitmap.GetPixel(x, 0);
                int avg_rgb = (tempPixel.R + tempPixel.G + tempPixel.B) / 3;
                if (avg_rgb >= 128)//White
                {
                    num_str += "0";
                }
                else//Black
                {
                    num_str += "1";
                }

            }

            return num_str;
        }

        public System.Drawing.Bitmap get_image_from_url(String url)
        {

            Image inputImage;
            Bitmap inputBitmap;

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

            return inputBitmap;
        }

    }
}
