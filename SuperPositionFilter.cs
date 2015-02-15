using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Aero.IP.ComputerVision
{
    using DataTypes;
    /// <summary>
    /// Takes the output of the canny edge detector as input, dilates the image, applies hough transform,
    /// and returns a matrix of 2D line segments found in the image
    /// </summary>
    public class SuperPositionFilter : Filter<ImageData, ImageData>
    {
        int dilations;
        double rhoResolution;
        double thetaResolution;
        int threshold;
        double minLineWidth;
        double gapBetweenLines;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dilations">The number of dilate iterations</param>
        /// <param name="rhoResolution">Distance resolution in pixel-related units (Try a default of 1)</param>
        /// <param name="thetaResolution">Angle resolution measured in radians (Try a default of pi/180)</param>
        /// <param name="threshold">A line is returned by the function if the corresponding accumulator value is greater than threshold</param>
        /// <param name="minLineWidth">Minimum width of a line</param>
        /// <param name="gapBetweenLines">Minimum gap between lines</param>
        public SuperPositionFilter(int dilations, double rhoResolution, double thetaResolution, int threshold, double minLineWidth, double gapBetweenLines)
            : base()
        {
            this.dilations = dilations;
            this.rhoResolution = rhoResolution;
            this.thetaResolution = thetaResolution;
            this.threshold = threshold;
            this.minLineWidth = minLineWidth;
            this.gapBetweenLines = gapBetweenLines;
        }


        public override ImageData ProcessAndPass(ImageData Data)
        {
            //Sanity Check
            Debug.Assert(Data != null, "Data cannot be null!");

            Image<Bgra, Byte> DilatedImage = Data.Image.Dilate(dilations);
            Image<Bgra, Byte> LineImage = new Image<Bgra, Byte>(DilatedImage.Size);

            // We only take lines from the first channel
            LineSegment2D[] Lines = DilatedImage.HoughLinesBinary(rhoResolution, thetaResolution, threshold, minLineWidth, gapBetweenLines)[0];

            for (int i = 0; i < Lines.GetLength(0); i++)
            {
                   LineImage.Draw(Lines[i], new Bgra(255, 255, 255, 255), 5);
            }

            Data.Image = LineImage;
            return Data;
        }
    }
}
