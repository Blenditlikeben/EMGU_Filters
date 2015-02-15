
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Aero.IP.ComputerVision
{
    /// <summary>
    /// This filter simply tests the creation and conversion of a CV image, and passes it to the UI through
    /// the VisualizationFilter
    /// </summary>
    public class VisTestFilter : Filter<ImageData, ImageData>
    {
        public VisTestFilter()
            : base()
        {

        }

        Random r = new Random((int)DateTime.Now.Ticks);

        public override void PreProcess(ImageData Data)
        {
            base.PreProcess(Data);
        }

        public override ImageData ProcessAndPass(ImageData Data)
        {
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(1000, 1000);

            image.SetValue(new Bgr(100, 100 + r.Next(155), 100 + r.Next(155)));

            image.Draw(new CircleF(new System.Drawing.PointF(250, 250), 100), new Bgr(100 + r.Next(155), 100 + r.Next(155), 100 + r.Next(155)), 100);

            Data.Bitmap = Utils.ImageConverter.ImageToBitmapConverter<Bgr, Byte>(image);

            return Data;
        }

        public override void PostProcess(ImageData Data)
        {

            base.PostProcess(Data);
        }

    }
}
