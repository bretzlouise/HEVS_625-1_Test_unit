using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ImageEdgeDetection;
using System.Collections.Generic;

namespace TestImageEdgeDetection
{
    [TestClass]
    public class FilterTest
    {

        public Bitmap originalPictureOpenSuse, originalPictureForest, rainbowedPicture, swapedPicture,
                        kirschPicture, prewitPicture, sobelPicture, result;
        public List<Bitmap> pictureList = new List<Bitmap>(); 
        public IImageFilters imageFilters = new ImageFilters();
        public string resultImageHash, realResultImageHash;


        [TestInitialize]
        public void Init()
        {
            //Charging all the pictures needed for the test from the Resources of the projecz
            originalPictureOpenSuse = Properties.Resources.openSuse;
            rainbowedPicture = Properties.Resources.openSuseRainbow;
            swapedPicture = Properties.Resources.openSuseSwap;

            pictureList.Add(originalPictureOpenSuse);
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
