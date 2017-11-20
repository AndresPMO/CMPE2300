using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA14_NicW
{
    class Block
    {
        //The rectangle for the block
        protected RectangleF rect;
        //Check if the block is outside the screen
        public bool Outside { get; private set; }

        //Random number generator, shared by all blocks and derivatives
        protected static Random randNum = new Random();

        //Constructor
        public Block(PointF location)
        {
            rect = new RectangleF();
            rect.X = location.X;
            rect.Y = location.Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Block)) return false; //Object isn't a block, or null

            Block temp = (Block)obj;

            if(ReferenceEquals(this, temp)) //Are they the same rectangle? False if same rectangle
            {
                return false;
            }
            else
            {
                return this.rect.IntersectsWith(temp.rect); //Equal if rectangles overlap
            }
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public virtual void Move(List<Block> inList)
        {

        }

        public virtual void Show(CDrawer canvas)
        {
            RectangleF copy = this.rect;
            copy.Inflate(3, 3);

            //Add the inflated copy of our rectangle first, in black
            canvas.AddRectangle((int)copy.X, (int)copy.Y, (int)copy.Width, (int)copy.Height, Color.Black);
            //Add our rectangle
            canvas.AddRectangle
        }
    }
}
