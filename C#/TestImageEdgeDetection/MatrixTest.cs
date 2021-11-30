using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ImageEdgeDetection;
using System.Reflection;
using System.IO;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace TestImageEdgeDetection
{
    [TestClass]
    public class MatrixTest
    {

        public Bitmap originalPictureOpenSuse;
        public Bitmap originalPictureForest;
        public Bitmap rainbowedPicture;
        public Bitmap swapedPicture;
        public Bitmap result;
        public List<Bitmap> pictureList = new List<Bitmap>(); 
        public IImageFilters imageFilters = new ImageFilters();
        public string resultImageHash;
        public string realResultImageHash;



        [TestMethod]
        public void KirschEdgeDetectionTest()
        {
            //Image in color
            Bitmap original;
            Bitmap original2 = new Bitmap(Properties.Resources.forest);
            Bitmap effectue = new Bitmap(Properties.Resources.openSuseRainbow);

            Bitmap result = ExtBitmap.KirschFilter(original2, false);

            bool test = true;
            for (int y = 0; y < result.Height; y++)
                for (int x = 0; x < result.Width; x++)
                {
                    if (result.GetPixel(x, y) != effectue.GetPixel(x, y))
                    {
                        test = false;
                    }
                }

            Assert.IsTrue(test);
        }
        [TestMethod]
        public void Sobel3x3EdgeDetectionTest()
        {
        }

        [TestMethod]
        public void PrewittEdgeDetectionTest()
        {
        }
    }
}
