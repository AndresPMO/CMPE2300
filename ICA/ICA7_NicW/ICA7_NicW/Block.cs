using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA7_NicW
{
    class Block
    {
        //Static variables
        public static CDrawer canvas { get; private set; }
        public static int height { get; private set; }
        private static Random randNum = new Random(1);

        //Instance variables
        public int width { get;  private set; }
        public bool Highlight { get; private set; }
        private Color colour;

        //Static constructor
        static Block()
        {
            //White canvas
            canvas = new CDrawer(800, 600, false);
            canvas.BBColour = Color.White;
            //20px block height
            height = 20;
        }

        //Instance constructor
        public Block()
        {
            width = 10 * randNum.Next(1, 20); //Random number from 10 - 190, by 10s.
            Highlight = false;
            colour = Color.FromArgb(randNum.Next(3, 8) * 32 - 1, randNum.Next(3, 8) * 32, randNum.Next(3, 8) * 32); // generate a specific range of colour as determined by spec sheet
        }

        //Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Block)) return false; //Object is null or wrong type
            Block temp = (Block)obj;
            //If width and colour are equal, same block
            return this.width == temp.width && this.colour == temp.colour;
        }

        //Methods
        public void ShowBlock(Point inPoint)
        {
            if(Highlight)
                canvas.AddRectangle(inPoint.X, inPoint.Y, this.width, height, this.colour, 2, Color.Yellow);
            else
                canvas.AddRectangle(inPoint.X, inPoint.Y, this.width, height, this.colour, 1, Color.Black);
        }
    }
}
