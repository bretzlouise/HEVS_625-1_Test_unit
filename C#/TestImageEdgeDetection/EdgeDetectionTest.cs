using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ImageEdgeDetection;
using System.Collections.Generic;




namespace TestImageEdgeDetection
{
    [TestClass]
    public class EdgeDetectionTest
    {

        public Bitmap result, initialPicture, beachKirsch,beachPrewitt, beachSobel;
        public List<Bitmap> pictureList = new List<Bitmap>();
        public string resultImageHash, realResultImageHash,resultPictureAfterFilter_ref, resultSavedBitmap_ref;

        [TestInitialize]
        public void Init()
        {
            //Charging all the pictures needed for the test from the Resources of the projecz
            initialPicture = Properties.Resources.beach;
            beachKirsch = Properties.Resources.beachKirsch;
            beachPrewitt = Properties.Resources.beachPrewitt;
            beachSobel = Properties.Resources.beachSobel;

            pictureList.Add(initialPicture);
            pictureList.Add(beachKirsch);
            pictureList.Add(beachPrewitt);
            pictureList.Add(beachSobel);
        }

        [TestMethod]
        public void pictureListTest()
        {
            Assert.IsNotNull(pictureList);
        }

        [TestMethod]
        public void allResourcePictureTest()
        {
            foreach (Bitmap picture in pictureList)
            {
                Assert.IsNotNull(picture);
            }

        }

        [TestMethod]
        public void Sobel3x3EdgeDetectionTest()
        {
            //Act
            Bitmap resultPictureAfterFilter = initialPicture.Sobel3x3Filter(false);
            //Bitmap resultSavedBitmap = beachSobel;
            Bitmap resultSavedBitmap = beachKirsch;

            Boolean isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(false, isSame);
        }


        [TestMethod]
        public void KirschEdgeDetectionTest()
        {
            //Arrange
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.KirschFilter(false);
            Bitmap resultSavedBitmap = beachKirsch;

            //Assert
            if (resultPictureAfterFilter.Width == resultSavedBitmap.Width && resultPictureAfterFilter.Height == resultSavedBitmap.Height)
            {
                for (int i = 0; i < resultPictureAfterFilter.Width; i++)
                {
                    for (int j = 0; j < resultPictureAfterFilter.Height; j++)
                    {
                        Console.WriteLine("i " + i + " j " + j);
                        resultPictureAfterFilter_ref = resultPictureAfterFilter.GetPixel(i, j).ToString();
                        resultSavedBitmap_ref = resultSavedBitmap.GetPixel(i, j).ToString();

                        Assert.AreEqual(resultPictureAfterFilter_ref, resultSavedBitmap_ref);
                    }
                }
            }
        }

        [TestMethod]
        public void PrewittEdgeDetectionTest()
        {

            //Arrange
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.PrewittFilter(false);
            Bitmap resultSavedBitmap = beachPrewitt;

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

    }
}
