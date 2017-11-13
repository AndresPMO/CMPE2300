using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA12_NicW
{
    class RectDrawer : CDrawer
    {
        RandomSquare randSquare = null;
        
        public RectDrawer() : base(800, 400)
        {
            randSquare = new RandomSquare(ScaledWidth / 5);
            BBColour = Color.White;

            for(int i = 0; i < 100; i++)
            {
                AddRectangle(randSquare.NextDrawerRect(this), RandColor.GetColor());
            }
        }
    }
}
