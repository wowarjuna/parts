using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class ImageExtensions
    {
        public static Image Resize(this Image image, int width, int height)
        {
            float scale;
            float scaleWidth = ((float)width / (float)image.Width);
            float scaleHeight = ((float)height / (float)image.Height);
            if (scaleHeight < scaleWidth)
            {
                scale = scaleHeight;
            }
            else
            {
                scale = scaleWidth;
            }

            int destWidth = (int)((image.Width * scale) + 0.5);
            int destHeight = (int)((image.Height * scale) + 0.5);

            Bitmap bitmap = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphics.DrawImage(image,
                        new Rectangle(0, 0, destWidth, destHeight),
                        new Rectangle(0, 0, image.Width, image.Height),
                        GraphicsUnit.Pixel);
            }
            return bitmap;
        }
    }
}
