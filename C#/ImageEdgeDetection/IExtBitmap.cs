using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEdgeDetection
{        

    //Creating interface for the image Detection 
    public interface IExtBitmap
    {
        Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght);
        Bitmap ConvolutionFilter(Bitmap sourceBitmap,
                                                double[,] xFilterMatrix,
                                                double[,] yFilterMatrix,
                                                      double factor = 1,
                                                           int bias = 0,
                                                 bool grayscale = false)
        Bitmap Sobel3x3Filter( Bitmap sourceBitmap, bool grayscale = true);
        Bitmap PrewittFilter(Bitmap sourceBitmap, bool grayscale = true);
        Bitmap KirschFilter(Bitmap sourceBitmap, bool grayscale = true);


    }
}
