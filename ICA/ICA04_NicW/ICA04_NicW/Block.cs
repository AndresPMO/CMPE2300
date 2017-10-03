using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA04_NicW
{
    class Block
    {
        //Static members
        static private CDrawer canvas = null;
        static public CDrawer Canvas { get { return canvas; } }

        static private Random randNum;
        //Instance members
        private int size;
        public int Size {
            set
            {
                if (value == 0)
                {
                    this.size = 1;
                }
                else
                {
                    this.size = Math.Abs(value);
                }
            }
        }

        private Color colour;

        private Rectangle rectangle;

        public bool Highlight { get; set; } = false;

        //Static Constructor
        static Block()
        {
            randNum = new Random();
            canvas = new CDrawer(800, 600, false);
        }
        
        //Instance Constructor
        public Block(int inSize)
        {
            //Make a standard square
            this.Size = inSize;
            this.colour = RandColor.GetColor();
            this.rectangle = new Rectangle(randNum.Next(0, canvas.ScaledWidth - this.size), 
                                           randNum.Next(0, canvas.ScaledHeight - this.size), 
                                           this.size, 
                                           this.size);
        }
        public Block(int inSize, Point center)
        {
            //make the mouse pointer square
            this.Size = inSize;
            this.colour = Color.FromArgb(0);
            this.rectangle = new Rectangle(center.X - (this.size / 2),
                                           center.Y - (this.size / 2),
                                           this.size,
                                           this.size);
            this.Highlight = true;
        }

        //Static Methods
        public static bool Load
        {
            //Property
            //If set to true, clear the drawer
            //if set to false, render the drawer
            set
            {
                if (value)
                {
                    canvas.Clear();
                }
                else
                {
                    canvas.Render();
                }
            }
        }

        //Instance Methods
        public void ShowBlock()
        {
            //Will add the block to the canvas
            //If it is highlighted then add a 1px yellow border
            if (Highlight)
            {
                canvas.AddRectangle(this.rectangle, this.colour, 1, Color.Yellow);
            }
            else
            {
                canvas.AddRectangle(this.rectangle, this.colour);
            }
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is Block)) return false; //Object is null, or not a block. False
            Block temp = (Block)obj;
            //Return if this rectangle intersects with the input rectangle
            return this.rectangle.IntersectsWith(temp.rectangle);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
