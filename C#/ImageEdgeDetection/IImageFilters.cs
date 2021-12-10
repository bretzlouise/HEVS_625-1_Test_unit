// REVIEW: usings not needed
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageEdgeDetection
{
    // REVIEW: What is the goal of this interface
    // I would create an abstract class in order to abstract the way to create and return a bitmap 
    public interface IImageFilters
    {
        Bitmap RainbowFilter(Bitmap bmp);
        Bitmap SwapFilter(Bitmap bmp);
        
    }
}
