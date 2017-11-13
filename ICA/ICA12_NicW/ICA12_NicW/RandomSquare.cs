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
            //Check if we have a valid drawer input
            if (canvas == null) throw new ArgumentException("CDrawer is null");

            //make sure max size isn't too big
            if (maxSize > canvas.ScaledHeight)
                maxSize = canvas.ScaledHeight;
            else if (maxSize > canvas.ScaledWidth)
                maxSize = canvas.ScaledWidth;

            //Get an x and y size to make the rectangle with
            int xSize = Next(10, maxSize);
            int ySize = Next(10, maxSize);

            //make a rectangle within the bounds of the drawer
            Rectangle output = new Rectangle(Next(0, canvas.ScaledWidth - xSize), Next(0, canvas.ScaledHeight - ySize), xSize, ySize);

            //Return the rectangle made
            return output;
        }
    }
}
