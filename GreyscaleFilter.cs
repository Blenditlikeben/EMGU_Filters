using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;

namespace Aero.IP.ComputerVision.Filters
{
    using DataTypes;
    /// <summary>
    /// This Filter can be used to convert an image into the Greyscale colour space.
    /// </summary>
    public class GreyscaleFilter : Filter<ImageData, ImageData>
    {
        public GreyscaleFilter() : base()     
        {
           //This filter does not require any instance specific variables.
        }

        /// <summary>
        /// Process the image, converting it from an RGBa Colourspace to Greyscale.
        /// </summary>
        /// <param name="Data">Colour Image</param>
        /// <returns>Greyscale Conversion of Image</returns>
        public override ImageData ProcessAndPass(ImageData Data)
        {
            //Sanity Checks
            Debug.Assert(Data != null, "Data cannot be null!");
            Debug.Assert(Data.Image!= null, "Colour image data is not present");

            //Conversion

            // Temporarily store greyscale image which will hold 1 byte per pixel (ex: 26 for grey pixel)
            Image<Gray, Byte> imgGrey;
            imgGrey = Data.Image.Convert<Gray, Byte>();

            // Now convert the Grey back to Bgra
            // If the grey pixel was 26, now B = 26, G = 26, R = 26, A = 255
            // So the color is still grey, but we retain full access to Bgra pixels
            Data.Image = imgGrey.Convert<Bgra, Byte>();

            return Data;
        }
    }
}
