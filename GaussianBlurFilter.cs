using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aero.IP.ComputerVision
{
    using System.Drawing;
    using DataTypes;
    /// <summary>
    /// A concrete example of a filter using the Abstract class infrastructure. 
    /// Copy and paste this file into the new Filter you are creating to avoid extra work.
    /// </summary>
    public class GaussianBlurFilter : Filter<ImageData, ImageData>
    {
        int kernelWidth;
	    int kernelHeight;
	    double sigma1;
        double sigma2;

        public GaussianBlurFilter(int kernelWidth, int kernelHeight,double sigma1, double sigma2)
            : base()     
        {
            this.kernelHeight = kernelHeight;
            this.kernelWidth = kernelWidth;
            this.sigma1 = sigma1;
            this.sigma2 = sigma2;
        }


        public override ImageData ProcessAndPass(ImageData Data)
        {
            Data.Image = Data.Image.SmoothGaussian(kernelWidth, kernelHeight, sigma1, sigma2);
            return Data;
        }

    }
}
