using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA14_NicW
{
    abstract class Block
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

            return this.rect.IntersectsWith(temp.rect); //Equal if rectangles overlap
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public abstract void Move(List<Block> inList);

        public virtual void ShowBlock(CDrawer canvas)
        {
            RectangleF copy = this.rect;
            copy.Inflate(3, 3);

            //Add the inflated copy of our rectangle first, in black
            canvas.AddRectangle((int)copy.X, (int)copy.Y, (int)copy.Width, (int)copy.Height, Color.Black);

            //Say if we went out of the canvas
            if(copy.X + copy.Width > canvas.ScaledWidth || copy.Y + copy.Height > canvas.ScaledHeight)
            {
                Outside = true;
            }
        }
    }

    class FallingBlock : Block
    {
        private const float velocity = 6;

        public FallingBlock(PointF location) : base(location)
        {
            rect.Width = 50;
            rect.Height = 50;
        }

        public override void Move(List<Block> inList)
        {
            //If we are not outside the screen
            if (!Outside)
            {
                //If we are not intersecting with anyone
                if(inList.TrueForAll(inblock => !inblock.Equals(this)))
                {
                    //Drop by the velocity, 6 pixels
                    this.rect.Y += velocity;
                }
            }
        }

        public override void ShowBlock(CDrawer canvas)
        {
            base.ShowBlock(canvas);
            canvas.AddRectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, Color.White);
        }
    }

    class DrunkBlock : Block
    {
        private const float yVelocity = 3;
        private float xVelocity = 0;

        public DrunkBlock(PointF location) : base(location)
        {
            rect.Width = 30;
            rect.Height = 60;
        }

        public override void Move(List<Block> inList)
        {
            //If we are not outside the screen
            if (!Outside)
            {
                //If we are not intersecting with anyone
                if (inList.TrueForAll(inblock => !inblock.Equals(this)))
                {
                    //Drop by the velocity, 6 pixels
                    rect.Y += yVelocity;
                    //Get a new xVelocity and use it
                    xVelocity = (float)randNum.NextDouble() * 2 - 1;
                    rect.X += xVelocity;
                }
            }
        }

        public override void ShowBlock(CDrawer canvas)
        {
            base.ShowBlock(canvas);
            canvas.AddRectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, Color.Pink);
            canvas.AddText("\u263A", 14, (int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, Color.Black);
        }
    }

    class ColourBlock : Block
    {
        private const float velocity = 3;
        private Color blockColour = RandColor.GetColor();

        public ColourBlock(PointF location) : base(location)
        {
            rect.Width = 60;
            rect.Height = 30;
        }

        public override void Move(List<Block> inList)
        {
            //If we are not outside the screen
            if (!Outside)
            {
                //If we are not intersecting with anyone
                if (inList.TrueForAll(inblock => !inblock.Equals(this)))
                {
                    //Drop by the velocity, 6 pixels
                    rect.Y += velocity;
                }
            }
        }

        public override void ShowBlock(CDrawer canvas)
        {
            base.ShowBlock(canvas);
            if(blockColour.A > velocity)
            {
                blockColour = Color.FromArgb(blockColour.A - (int)velocity, blockColour.R, blockColour.G, blockColour.B);
            }
            canvas.AddRectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, blockColour);
        }
    }
}
