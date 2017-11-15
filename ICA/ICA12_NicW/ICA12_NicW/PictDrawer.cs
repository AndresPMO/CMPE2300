using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA12_NicW
{
    class PictDrawer : CDrawer
    {
        static private Bitmap image = new Bitmap(Properties.Resources.gunFish);

        public PictDrawer() : base(image)
        {
            Color tempColour;
            int averageColour;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    tempColour = image.GetPixel(x, y);
                    averageColour = (tempColour.R + tempColour.B + tempColour.G) / 3;
                    tempColour = Color.FromArgb(averageColour, averageColour, averageColour);
                    SetBBPixel(x, y, tempColour);
                }
            }
        }
    }
}
