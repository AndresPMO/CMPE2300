using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA06_NicW
{
    class Ball
    {
        //Static members
        static private CDrawer canvas;
        static private Random randNum;

        //Instance members
        private float _radius;
        private float Radius
        {
            //Positive & !0
            set
            {
                if (value == 0)
                    _radius = 1;
                else
                    _radius = Math.Abs(value);
            }
        }

        private Color _colour;
        private PointF _center;

        //Static constuctor
        static Ball()
        {
            randNum = new Random();
            canvas = new CDrawer(800, 600, false);
            canvas.BBColour = Color.White;
        }
        //Instance constructor
        public Ball(int inRadius)
        {
            Radius = inRadius;
            _colour = RandColor.GetColor();
            _center = new PointF(randNum.Next((int)Math.Floor(_radius), canvas.ScaledWidth - (int)Math.Floor(_radius)),
                                 randNum.Next((int)Math.Floor(_radius), canvas.ScaledHeight - (int)Math.Floor(_radius)));

        }

        //Static methods
        static public bool Load
        {
            set
            {
                if (value)
                    canvas.Clear();
                else
                    canvas.Render();
            }
        }
        //Instance methods
        public void ShowBall()
        {
            canvas.AddCenteredEllipse((int)_center.X, (int)_center.Y, (int)(_radius * 2), (int)(_radius * 2), _colour);
        }

        private float GetDistance(Ball other)
        {
            return (float)Math.Abs(Math.Sqrt(Math.Pow((other._center.X - this._center.X), 2) + Math.Pow(other._center.Y - this._center.Y, 2))); //|Sqrt((x2-x1)^2 + (y2-y1)^2)|
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ball)) return false; //Null, or not ball type

            Ball input = obj as Ball; //Get the input as type ball
            float distance = this.GetDistance(input); //Find the distance between the two balls

            return distance <= this._radius + input._radius; //If the distance is less than either balls radius, we have overlap
        }

        public override int GetHashCode()
        {
            return 1; //Everything goes through our Equals override
        }

        static public int CompareTo(Ball arg1, Ball arg2)
        {
            //Check if our radius is higher than their radius
            return -1 * arg1._radius.CompareTo(arg2._radius);
        }

        static public int CompareByDistance(Ball arg1, Ball arg2)
        {
            Ball origin = new Ball(1);
            origin._center.X = 0;
            origin._center.Y = 0;

            return -1 * arg1.GetDistance(origin).CompareTo(arg2.GetDistance(origin));
        }

        static public int CompareByColour(Ball arg1, Ball arg2)
        {
            return -1 * arg1._colour.ToArgb().CompareTo(arg2._colour.ToArgb());
        }
        
    }
}
