using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Aero.IP.ComputerVision
{
    using System.Drawing;
    using DataTypes;
    
    public class CannyEdgeDetectorFilter : Filter<ColourImageData, ColourImageData>
    {
        double thresh;
        double threshLinking;

        Contour<System.Drawing.Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

        public CannyEdgeDetectorFilter()
            : base()
        {

            // thresh is the threshhold to find initial segments of strong edges
            // thresh linking is the threshold used for edge Linking

            thresh = 5.0;
            threshLinking = 5.0;
        }


        public override ColourImageData ProcessAndPass(ColourImageData Data)
        {
            Emgu.CV.Image<Gray, Byte> img = Data.ColorImage.Canny(thresh, threshLinking);
            return Data;
        }

    }
}
