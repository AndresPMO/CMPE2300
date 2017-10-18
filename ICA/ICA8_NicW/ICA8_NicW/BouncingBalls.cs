using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA8_NicW
{
    class BouncingBalls
    {
        //Static variables
        static private Random randNum = new Random();

        //Instance variables
        private PointF center;
        private float xVelocity;
        private float yVelocity;
        private int radius;
        public Color colour { get; set; }
        
        //Instance Constructor
        public BouncingBalls(PointF inPoint, Color inColour)
        {
            center = inPoint;
            colour = inColour;
            xVelocity = (float)randNum.NextDouble() * 10 - 5;
            yVelocity = (float)randNum.NextDouble() * 10 - 5;
            radius = randNum.Next(20, 51);
        }

        //Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is BouncingBalls)) return false; //Null, or not ball type

            BouncingBalls  input = obj as BouncingBalls; //Get the input as type ball
            float distance = this.GetDistance(input); //Find the distance between the two balls

            return distance <= this.radius + input.radius; //If the distance is less than either balls radius, we have overlap
        }

        public override int GetHashCode()
        {
            return 1;
        }

        //Methods
        private float GetDistance(BouncingBalls other)
        {
            return (float)Math.Abs(Math.Sqrt(Math.Pow((other.center.X - this.center.X), 2) + Math.Pow(other.center.Y - this.center.Y, 2))); //|Sqrt((x2-x1)^2 + (y2-y1)^2)|
        }

        public void ShowBall(CDrawer canvas, int num)
        {
            //Draw the circle
            canvas.AddCenteredEllipse((int)center.X, (int)center.Y, (int)(radius * 2), (int)(radius * 2), colour);
            //Add a number to the center of the ball
            canvas.AddText(num.ToString(), 14, (int)center.X - radius, (int)center.Y - radius, radius*2, radius*2, Color.FromArgb(colour.ToArgb() ^ 0x00FFFFFF));
        }

        public void MoveBall(CDrawer canvas)
        {
            //If we would leave the horizontal screen
            if(xVelocity + radius + center.X < 0 || xVelocity + radius + center.X > canvas.ScaledWidth)
            {
                xVelocity *= -1;
            }
            //If we would leave the vertical screen
            if (yVelocity + radius + center.Y < 0 || yVelocity + radius + center.Y > canvas.ScaledHeight)
            {
                yVelocity *= -1;
            }
            //Move
            center.X += xVelocity;
            center.Y += yVelocity;
        }
    }
}
