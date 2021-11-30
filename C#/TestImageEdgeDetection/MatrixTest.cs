using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ImageEdgeDetection;
using System.Reflection;
using System.IO;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace TestImageEdgeDetection
{
    [TestClass]
    public class MatrixTest
    {

        [TestMethod]
        public void Sobel3x3EdgeDetectionTest()
        {
            //Arrange
            Bitmap initialPicture = new Bitmap(Properties.Resources.test);
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.Sobel3x3Filter(false);
            Bitmap resultSavedBitmap = new Bitmap(Properties.Resources.testSobel3x3);

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
        public void KirschEdgeDetectionTest()
        {
            //Arrange
            Bitmap initialPicture = new Bitmap(Properties.Resources.test);
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.KirschFilter(false);
            Bitmap resultSavedBitmap = new Bitmap(Properties.Resources.testKirsch);

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
        public void TestLaMemeImage()
        {
            //Arrange
            Bitmap initialPicture = new Bitmap(Properties.Resources.openSuseKirsch2);
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture;
            Bitmap resultSavedBitmap = new Bitmap(Properties.Resources.openSuseKirsch);

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
        public void PrewittEdgeDetectionTest()
        {

            //Arrange
            Bitmap initialPicture = new Bitmap(Properties.Resources.test);
            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.PrewittFilter(false);
            Bitmap resultSavedBitmap = new Bitmap(Properties.Resources.testprewitt2);

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
