using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA13_NicW
{
    class RandomSquare : Random
    {
        private readonly int maxSize;

        public RandomSquare(int inMaxSize)
        {
            maxSize = inMaxSize;
        }

        public Rectangle NextDrawerRect(CDrawer canvas)
        {
            //Check if we have a valid drawer input
            if (canvas == null) throw new ArgumentException("CDrawer is null");
            int tempSize = maxSize;

            //make sure max size isn't too big
            if (maxSize > canvas.ScaledHeight)
                tempSize = canvas.ScaledHeight;
            else if (maxSize > canvas.ScaledWidth)
                tempSize = canvas.ScaledWidth;

            //Get an x and y size to make the rectangle with
            int xSize = Next(10, tempSize);
            int ySize = Next(10, tempSize);

            //make a rectangle within the bounds of the drawer
            Rectangle output = new Rectangle(Next(0, canvas.ScaledWidth - xSize), Next(0, canvas.ScaledHeight - ySize), xSize, ySize);

            //Return the rectangle made
            return output;
        }
    }
}
