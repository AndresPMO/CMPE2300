using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA7_NicW
{
    class Block : IComparable
    {
        //Static variables
        public static CDrawer canvas { get; private set; }
        public static int height { get; private set; }
        private static Random randNum = new Random(1);

        //Instance variables
        public int width { get;  private set; }
        public bool Highlight { get; set; }
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

        //Comparisons
        public int CompareTo(object obj)
        {
            //Standard comparison is by colour only
            if (!(obj is Block)) throw new ArgumentException("Input is not correct type: Block");

            Block temp = (Block)obj;
            return this.colour.ToArgb().CompareTo(temp.colour.ToArgb());
        }
        public static int CompareWidth(Block arg1, Block arg2)
        {
            //Compare by the Blocks width
            return arg1.width.CompareTo(arg2.width);
        }
        public static int CompareWidthColour(Block arg1, Block arg2)
        {
            if (arg1.width == arg2.width)
                return arg1.colour.ToArgb().CompareTo(arg2.colour.ToArgb());
            return arg1.width.CompareTo(arg2.width);
        }
        
        //Methods
        public void ShowBlock(Point inPoint)
        {
            if(Highlight)
                canvas.AddRectangle(inPoint.X, inPoint.Y, this.width, height, this.colour, 2, Color.Yellow);
            else
                canvas.AddRectangle(inPoint.X, inPoint.Y, this.width, height, this.colour, 1, Color.Black);
        }

        public static bool Brightness(Block arg)
        {
            return arg.colour.GetBrightness() > 0.6;
        }
    }
}
