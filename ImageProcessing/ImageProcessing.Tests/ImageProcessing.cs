using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageProcessing;
using System.Drawing;

namespace ImageProcessing.Tests
{
    [TestClass]
    public class ImageProcessing
    {
        //id found in encoded image
        [TestMethod]
        public void TestMethod1()
        {
            Encoding e = new Encoding("C:\\Users\\Public\\view.jpg", "0");
            Image inputImage = Image.FromFile("C:\\Users\\Public\\EncodedImage0.jpg");
            Bitmap inputBitmap = new Bitmap(inputImage);

            String str = "";
            for (int i = 0; i < 13; i++)
            {
                if (inputBitmap.GetPixel(i, 0).R > 200)
                {
                    str += "0";
                }
                else
                {
                    str += "1";
                }
            }

            Assert.AreEqual("1101000100001", str);
        }


        //id found in encoded image from Facebook 
        [TestMethod]
        public void TestMethod2()
        {

            Decoding d = new Decoding("http://sphotos-e.ak.fbcdn.net/hphotos-ak-ash3/425478_10152387860320595_1102652424_n.jpg", "0");
            Image inputImage = Image.FromFile("C:\\Users\\Public\\DecodedImage0.jpg");
            Bitmap inputBitmap = new Bitmap(inputImage);
            String str = "";
            for (int i = 0; i < 13; i++)
            {
                if (inputBitmap.GetPixel(i, 0).R > 200)
                {
                    str += "0";
                }
                else
                {
                    str += "1";
                }
            }

            Assert.AreEqual("1101000100001", str);
        }



        //real image and encoded image are not the same
        [TestMethod]
        public void TestMethod3()
        {
            Image inputImage = Image.FromFile("C:\\Users\\Public\\EncodedImage0.jpg");
            Bitmap inputBitmap = new Bitmap(inputImage);

            Image inputImage2 = Image.FromFile("C:\\Users\\Public\\view.jpg");
            Bitmap inputBitmap2 = new Bitmap(inputImage);

            Assert.AreNotEqual(inputBitmap2, inputBitmap);
        }

        //reall image and Decoded image are exactly the same
        [TestMethod]
        public void TestMethod4()
        {
            Image inputImage = Image.FromFile("C:\\Users\\Public\\DecodedImage0.jpg");
            Bitmap inputBitmap = new Bitmap(inputImage);

            Image inputImage2 = Image.FromFile("C:\\Users\\Public\\view.jpg");
            Bitmap inputBitmap2 = new Bitmap(inputImage);

            Assert.AreEqual(inputBitmap2, inputBitmap);

        }


    }
}
