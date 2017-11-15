using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA13_NicW
{
    class PictDrawer : CDrawer
    {
        public PictDrawer(Bitmap image) : base(image.Width, image.Height)
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

        public new void Render()
        {
            AddText($"{ScaledWidth} x {ScaledHeight} : {this.GetType().ToString()}", 10, 0, 0, 300, 50, Color.Red);
            base.Render();
        }
    }
}
