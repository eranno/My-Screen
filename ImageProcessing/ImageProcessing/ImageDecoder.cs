using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace ImageProcessing
{
    public static class ImageDecoder
    {
        public static String PROGRAM_ID = "1101000100001";
        public static int SWAPS = 300;
        public static int HIGHT = 300;
        public static int WIDTH = 400;

        public static void decode_image(Bitmap image, int user_id, uint image_id)
        {
            int[,] path = new int[SWAPS, 2];

            //get image key from Server
            String key = get_key(user_id, image_id); //"116 6 97 63 187 138 232 50 248 5 259 60 120 196 210 138 102 30 204 220 266 270 200 213 31 132 128 227 29 151 131 30 34 197 105 277 72 73 139 133 144 26 122 128 116 6 185 51 141 77 290 139 155 299 249 146 106 184 33 56 11 6 21 98 173 229 27 223 91 232 66 30 191 72 76 240 149 72 97 25 246 77 87 251 160 292 174 34 247 259 171 188 41 84 123 139 5 24 255 186 278 262 260 208 11 260 247 84 224 9 297 35 87 8 109 233 219 69 237 180 56 292 276 131 61 178 289 108 249 237 236 125 116 211 46 284 116 178 241 200 45 91 110 239 262 137 101 33 274 189 220 235 86 75 131 286 286 130 147 132 271 140 134 286 73 172 218 176 261 125 117 41 128 38 136 265 182 37 168 224 78 256 133 60 17 1 39 42 81 60 297 286 32 109 228 204 256 123 167 91 218 225 71 149 73 180 108 49 239 165 104 249 261 223 55 15 7 74 270 72 134 176 95 202 127 130 9 20 110 231 9 59 170 78 6 152 185 284 286 137 193 290 103 215 255 49 25 109 54 213 197 182 153 95 256 42 130 169 22 243 171 88 239 9 157 46 79 183 217 202 129 23 87 134 179 143 74 180 246 79 105 200 265 196 34 126 206 76 121 263 22 17 262 44 265 105 51 95 59 210 269 141 191 151 84 175 95 19 215 114 268 250 222 243 138 270 123 43 274 32 139 4 63 254 181 113 60 44 168 75 93 279 121 37 109 263 9 115 112 158 31 187 160 8 295 71 94 20 206 295 281 8 120 28 71 266 79 237 270 271 115 52 151 141 21 289 129 186 134 174 261 9 231 116 1 251 144 55 258 110 19 41 137 173 93 85 159 94 265 143 184 72 144 141 44 278 37 19 286 6 242 208 185 33 34 273 77 4 27 120 122 25 278 161 252 75 215 277 49 236 130 35 220 291 289 190 164 91 73 22 215 125 68 253 168 111 155 104 140 119 8 156 68 146 21 160 93 283 188 268 63 59 270 51 176 207 287 194 44 143 110 285 230 5 205 296 257 26 293 142 219 111 138 229 228 274 267 75 270 129 98 181 202 105 259 156 155 18 78 261 123 261 61 297 10 23 225 63 240 24 203 67 290 47 49 252 221 41 122 201 239 213 223 214 45 228 83 126 46 50 142 239 248 32 19 258 51 141 220 206 50 204 134 247 226 32 191 156 57 8 234 114 195 176 22 210 39 147 252 81 239 100 18 191 182 263 118 258 28 91 201 81 121 215 152 36 79 276 287 14 38 227 69 39 115 28 44 73 11 109 219 203 188 139 267 249 187 243 66 263 213 233 128 265 106 154 293 280 25 286 ";//;
            if (key != "2")
            {
                //split the key in to path
                split_key(image, key, path);

                //decode the image
                Decode_Image(image, path);

                //save image in DataBase
                saveImage(image, user_id, image_id);
            }


        }

        private static void saveImage(Bitmap image,int user_id, uint image_id)
        {
            String time = DateTime.Now.ToString("dd-MM-yyyy");
            if (!Directory.Exists("DecodedImages\\"+time))
                Directory.CreateDirectory("DecodedImages\\"+time);

            string loc = "DecodedImages\\" + time + "\\" + Convert.ToString(user_id) + Convert.ToString(image_id) + ".jpg";
            image.Save(loc);


            string type = Path.GetExtension(loc);
            string name = Path.GetFileNameWithoutExtension(loc);

            DataHandler.DecryptedImage d = new DataHandler.DecryptedImage();
            d.Type = type;
            d.Name = name;
            d.Path = loc;


            DataHandler.LocalData.insertDecryptedImage(d);

        }


        private static String get_key(int userId, uint imageId)
        {
            using (var wb = new WebClient())
            {

                //$email 	= strtolower($_POST['email']);
                //$pass 	= $_POST['password'];
                //$serial	= $_POST['serial'];
                //$fid	= $_POST['fid'];

                var data = new NameValueCollection();
                data["email"] = "erannn@gmail.com";
                data["password"] = "1234";
                data["serial"] = Convert.ToString(imageId);//"12";
                data["fid"] = Convert.ToString(userId); //"1234";

                var response = wb.UploadValues("http://my.jce.ac.il/~eranno/act/get_image.php", "POST", data);
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