using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            xVelocity = randNum.Next(-5, 6);
            yVelocity = randNum.Next(-5, 6);
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
        //Methods
        private float GetDistance(BouncingBalls other)
        {
            return (float)Math.Abs(Math.Sqrt(Math.Pow((other.center.X - this.center.X), 2) + Math.Pow(other.center.Y - this.center.Y, 2))); //|Sqrt((x2-x1)^2 + (y2-y1)^2)|
        }
    }
}
