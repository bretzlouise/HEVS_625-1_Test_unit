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

        [TestMethod]
        public void KirschEdgeDetectionTest()
        {
             //Arrange
            Bitmap initialPicture = new Bitmap(@"..\\..\\Pictures\\pikachu.jpeg");
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.Laplacian3x3Filter(false);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Pictures\\Lapalacian3x3Pikachu.png");

            //Assert
            if (resultPictureAfterFilter.Width == resultSavedBitmap.Width && resultPictureAfterFilter.Height == resultSavedBitmap.Height)
            {
                for (int i = 0; i < resultPictureAfterFilter.Width; i++)
                {
                    for (int j = 0; j < resultPictureAfterFilter.Height; j++)
                    {
                        resultPictureAfterFilter_ref = resultPictureAfterFilter.GetPixel(i, j).ToString();
                        resultSavedBitmap_ref = resultSavedBitmap.GetPixel(i, j).ToString();

                        Assert.AreEqual(resultPictureAfterFilter_ref, resultSavedBitmap_ref);
                    }
                }
            }

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
