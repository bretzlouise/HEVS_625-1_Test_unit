using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;
using System.IO;

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
        }
        [TestMethod]
        public void KirschEdgeDetectionTest()
        {

            //Arrange
            //Bitmap initialPicture = new Bitmap(@"..\\..\\..\\Pictures\\forrest.png");
            //Bitmap initialPicture = new Bitmap(@"Pictures\forrest.png");
            //Bitmap initialPicture = new Bitmap(@"C:\src\Pictures\forrest.png");
            //Bitmap initialPicture = (Bitmap)Image.FromFile(@"C:\src\Pictures\forrest.png");
            /*StreamReader streamReader = new System.IO.StreamReader(@"C:\src\Pictures\forrest.png");
            Bitmap initialPicture = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
            streamReader.Close();*/

            const string original = @"C:\src\Pictures\forrest.png";
            const string swapped = @"C:\src\Pictures\forrest_none_kirsch.png";

            Bitmap initialPicture = new Bitmap(original);

            string resultPictureAfterFilter_ref;
            string resultSavedBitmap_ref;

            //Act
            Bitmap resultPictureAfterFilter = initialPicture.KirschFilter();
            Bitmap resultSavedBitmap = new Bitmap(swapped);

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
