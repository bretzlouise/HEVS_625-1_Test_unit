using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing.Imaging;
using System.Drawing;
using ImageEdgeDetection;
using System.Reflection;
using System.IO;
using NSubstitute;
using System;

namespace TestImageEdgeDetection
{
    [TestClass]
    public class ImageEdgeDetectionTest
    {
        
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void NoneFilterTest()
        {
        }

        [TestMethod]
        public void RainbowFilterTest()
        {


        }

        [TestMethod]
        public void SwapFilterTest()
        {

            const string original = @"C:\Users\openSuse.png";
            const string swapped = @"C:\Users\openSuseSwap.png";           

            Bitmap originalImage = new Bitmap(original);
            Bitmap imageSwaped = new Bitmap(swapped);

            IImageFilters imageFilters = new ImageFilters();
            Bitmap result = imageFilters.SwapFilter(originalImage);
            string resultImageHash = TestMethods.GetImageHash(result);
            string realResultImageHash = TestMethods.GetImageHash(imageSwaped);

            Assert.AreEqual(resultImageHash, realResultImageHash);

        }








        [TestMethod]
        public void KirschEdgeDetectionTest()
        {
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
