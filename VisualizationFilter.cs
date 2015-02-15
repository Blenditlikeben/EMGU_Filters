using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Aero.IP.ComputerVision.Filters
{
    /// <summary>
    /// This filter receives image data and passes it to the UI for viewing.
    /// </summary>
    class VisualizationFilter : TerminalFilter<ImageData>
    {
        public VisualizationFilter(String FilterName)
            : base()
        {
            mFilterName = FilterName;
        }

        public override void PreProcess(ImageData Data)
        {
            base.PreProcess(Data);
        }

        public override void Process(ImageData Data)
        {
            Data.Bitmap = Utils.ImageConverter.ImageToBitmapConverter<Bgra, Byte>(Data.Image);
            Data.Bitmap.Freeze();

            UI.MainWindow.ApplicationWindow.FilterImageReceived(mFilterName, Data);
        }

        public override void PostProcess(ImageData Data)
        {
            base.PostProcess(Data);
        }

        private String mFilterName;
    }
}
