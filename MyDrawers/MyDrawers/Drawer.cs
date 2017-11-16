using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace MyDrawers
{
    internal class RandomSquare : Random
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

    public class RectDrawer : CDrawer
    {
        List<Rectangle> backRectangles = new List<Rectangle>(100);
        public RectDrawer(int width = 800, int height = 400, bool bContinuousUpdate = false) : base(width, height, bContinuousUpdate)
        {
            RandomSquare randSquare = new RandomSquare(ScaledWidth / 5);
            BBColour = Color.White;

            for (int i = 0; i < 100; i++)
            {
                backRectangles.Add(randSquare.NextDrawerRect(this));
            }
            for (int i = 0; i < 100; i++)
            {
                AddRectangle(backRectangles[i], Color.White, 1, Color.Blue);
            }
            Render();
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
            Render();
        }

        public new void Render()
        {
            AddText($"{ScaledWidth} x {ScaledHeight} : {this.GetType().ToString()}", 10, 0, 0, 300, 50, Color.Red);
            base.Render();
        }
    }

    public class PictDrawer : CDrawer
    {
        public PictDrawer(Bitmap image, bool bContinuousUpdate = false) : base(image.Width, image.Height, bContinuousUpdate)
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
