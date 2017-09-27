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
        public int Size { set { this.size = Math.Abs(value); } }

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
            this.Size = inSize;
            this.colour = RandColor.GetColor();
            this.rectangle = new Rectangle(randNum.Next(this.size, canvas.ScaledWidth - this.size), 
                                           randNum.Next(this.size, canvas.ScaledHeight - this.size), 
                                           this.size, 
                                           this.size);
        }

        //Static Methods
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

        public bool Load
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

        public override bool Equals(object obj)
        {
            if (!(obj is Block)) return false; //Object is null, or not a block. False
            Block temp = (Block)obj;
            //Return if this rectangle intersects with the input rectangle
            return this.rectangle.IntersectsWith(temp.rectangle);
        }
    }
}
