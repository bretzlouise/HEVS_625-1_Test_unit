using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;

namespace TestImageEdgeDetection
{
    public static class TestMethods
    {
        public static bool CompareImages(Bitmap a, Bitmap b)
        {
            string a_ref, b_ref;

            // check image size
            if (a.Width != b.Width || a.Height != b.Height)
            {
                return false;
            }

            // check pixel by pixel
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < a.Height; j++)
                {
                    a_ref = a.GetPixel(i, j).ToString();
                    b_ref = b.GetPixel(i, j).ToString();

                    //if not equal return false
                    if (!a_ref.Equals(b_ref))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static string GetImageHash(Bitmap bmpSource)
        {
            List<byte> colorList = new List<byte>();
            string hash;

            int i, j;
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (j = 0; j < bmpMin.Height; j++)
            {
                for (i = 0; i < bmpMin.Width; i++)
                {
                    colorList.Add(bmpMin.GetPixel(i, j).R);
                }
            }

            SHA1Managed sha = new SHA1Managed();
            byte[] checksum = sha.ComputeHash(colorList.ToArray());
            hash = BitConverter.ToString(checksum).Replace("-", String.Empty);

            sha.Dispose();
            bmpMin.Dispose();

            return hash;
        }
    }
}
