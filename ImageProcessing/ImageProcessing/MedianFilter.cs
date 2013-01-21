using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageProcessing
{
    class MedianFilter
    {
        Image inputImage;
        Bitmap inputBitmap;
        int radius = 1;
        int[] red = new int[9];
        int[] green = new int[9];
        int[] blue = new int[9];
        Color temp, temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8;



        public MedianFilter(String dir)
        {
            inputImage = Image.FromFile(dir);
            inputBitmap = new Bitmap(inputImage);

            for (int y = radius; y < (inputBitmap.Height - radius); y++)
            {
                for (int x = radius; x < (inputBitmap.Width - radius); x++)
                {
                    temp = inputBitmap.GetPixel(x, y);
                    temp1 = inputBitmap.GetPixel(x-1, y-1);
                    temp2 = inputBitmap.GetPixel(x, y - 1);
                    temp3 = inputBitmap.GetPixel(x + 1, y - 1);
                    temp4 = inputBitmap.GetPixel(x + 1, y);
                    temp5 = inputBitmap.GetPixel(x + 1, y + 1);
                    temp6 = inputBitmap.GetPixel(x, y + 1);
                    temp7 = inputBitmap.GetPixel(x - 1, y + 1);
                    temp8 = inputBitmap.GetPixel(x - 1, y);
                    
                    red[0] = temp1.R;
                    red[1] = temp2.R;
                    red[2] = temp3.R;
                    red[3] = temp4.R;
                    red[4] = temp5.R;
                    red[5] = temp6.R;
                    red[6] = temp7.R;
                    red[7] = temp8.R;
                    red[8] = temp.R;

                    green[0] = temp1.G;
                    green[1] = temp2.G;
                    green[2] = temp3.G;
                    green[3] = temp4.G;
                    green[4] = temp5.G;
                    green[5] = temp6.G;
                    green[6] = temp7.G;
                    green[7] = temp8.G;
                    green[8] = temp.G;

                    blue[0] = temp1.B;
                    blue[1] = temp2.B;
                    blue[2] = temp3.B;
                    blue[3] = temp4.B;
                    blue[4] = temp5.B;
                    blue[5] = temp6.B;
                    blue[6] = temp7.B;
                    blue[7] = temp8.B;
                    blue[8] = temp.B;
             
                  
                    Array.Sort(red);
                    Array.Sort(blue);
                    Array.Sort(green);
                    
                    Color c = Color.FromArgb(red[4], green[4], blue[4]);
                     

                    
                    inputBitmap.SetPixel(x, y, c);



                }
            }

            inputBitmap.Save("C:\\Users\\user\\Documents\\myscreen\\My-Screen\\Client\\GUI\\bin\\Debug\\DecodedImages\\2.jpg");

        }
             
    }
}
