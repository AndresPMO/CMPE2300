using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA12_NicW
{
    class RandomSquare : Random
    {
        private int maxSize;

        public RandomSquare(int inMaxSize)
        {
            maxSize = inMaxSize;
        }

        public Rectangle NextDrawerRect(CDrawer canvas)
        {
            if (canvas == null) throw new ArgumentException("CDrawer is null");

            if (maxSize > canvas.ScaledWidth)
                maxSize = canvas.ScaledWidth;

            int xSize = Next(10, maxSize);
            int ySize = Next(10, maxSize);

            Rectangle output = new Rectangle(Next(0, canvas.ScaledWidth - xSize), Next(0, canvas.ScaledHeight - ySize), xSize, ySize);

            return output;
        }
    }
}
