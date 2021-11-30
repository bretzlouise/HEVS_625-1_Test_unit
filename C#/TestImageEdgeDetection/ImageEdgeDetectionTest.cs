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
    public class ImageEdgeDetectionTest
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


        [TestInitialize]
        public void Init()
        {
            //Charging all the pictures needed for the test from the Resources of the projecz
            originalPictureOpenSuse = Properties.Resources.openSuse;
            originalPictureForest = Properties.Resources.forest;
            rainbowedPicture = Properties.Resources.openSuseRainbow;
            swapedPicture = Properties.Resources.openSuseSwap;

            pictureList.Add(originalPictureOpenSuse);
            pictureList.Add(originalPictureForest);
            pictureList.Add(rainbowedPicture);
            pictureList.Add(swapedPicture);
        }

        [TestMethod]
        public void pictureListTest()
        {
            Assert.IsNotNull(pictureList);
        }

        [TestMethod]
        public void allResourcePictureTest()
        {
            foreach(Bitmap picture in pictureList)
            {
                Assert.IsNotNull(picture);
            }
            
        }

        [TestMethod]
        public void NoneFilterTest()
        {
            result = originalPictureOpenSuse;
            resultImageHash = TestMethods.GetImageHash(result);
            realResultImageHash = TestMethods.GetImageHash(originalPictureOpenSuse);

            Assert.AreEqual(resultImageHash, realResultImageHash);

        }

        [TestMethod]
        public void RainbowFilterTest()
        {          
            result = imageFilters.RainbowFilter(originalPictureOpenSuse);
            resultImageHash = TestMethods.GetImageHash(result);
            realResultImageHash = TestMethods.GetImageHash(rainbowedPicture);

            Assert.AreEqual(resultImageHash, realResultImageHash);
        }

        [TestMethod]
        public void SwapFilterTest()
        {
            result = imageFilters.SwapFilter(originalPictureOpenSuse);
            resultImageHash = TestMethods.GetImageHash(result);
            realResultImageHash = TestMethods.GetImageHash(swapedPicture);

            Assert.AreEqual(resultImageHash, realResultImageHash);

        }


    }
}
