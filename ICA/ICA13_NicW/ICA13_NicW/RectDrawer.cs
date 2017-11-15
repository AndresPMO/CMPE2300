using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA13_NicW
{
    class RectDrawer : CDrawer
    {
        RandomSquare randSquare = null;
        List<Rectangle> backRectangles = new List<Rectangle>(100);
        public RectDrawer(int width = 800, int height = 400) : base(width, height)
        {
            randSquare = new RandomSquare(ScaledWidth / 5);
            BBColour = Color.White;

            for(int i = 0; i < 100; i++)
            {
                backRectangles.Add(randSquare.NextDrawerRect(this));
            }
            for (int i = 0; i < 100; i++)
            {
                AddRectangle(backRectangles[i], Color.White, 1, Color.Blue);
            }
        }

        public new void Clear()
        {
            //Clear the screen
            base.Clear();
            //Re-add rectangles
            for (int i = 0; i < 100; i++)
            {
                AddRectangle(backRectangles[i], Color.Transparent, 1, Color.Blue);
            }
        }

        public new void Render()
        {
            AddText($"{ScaledWidth} x {ScaledHeight} : {this.GetType().ToString()}", 10, 0, 0, 300, 50, Color.Red);
            base.Render();
        }
    }
}
