using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using System.Net;

namespace CVApp.Server.Common
{
    public static class Utils
    {
        public static Image GetImageFromBase64(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image;
                try
                {
                    image = Image.FromStream(ms, true);
                }
                catch (Exception ex)
                {
                    image = null;
                }

                return image;
            }
        }

        public static Image GetImageFromUrl(string urlString)
        {
            WebClient client = new WebClient();
            Stream stream;
            Image image;
            try
            {
                stream = client.OpenRead(urlString);
                image = Image.FromStream(stream, true);
            }
            catch (Exception ex)
            {
                image = null;
            }

            return image;
        }

        public static Mat GetGrayMatFromSDImage(Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            Image<Gray, Byte> grayImage = cvImage.Convert<Gray, Byte>();
            return grayImage.Mat;
        }
    }
}
