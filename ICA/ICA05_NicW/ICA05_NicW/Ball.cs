using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA05_NicW
{
    public enum ESortType { eRadius, eDistance, eColour }

    class Ball : IComparable
    {
        //Static members
        static private CDrawer canvas;
        static private Random randNum;
        static public ESortType sort { get; set; }

        //Instance members
        private float _radius;
        private float Radius {
            //Positive & !0
            set {
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
            return (float)Math.Abs(Math.Sqrt(Math.Pow((other._center.X - this._center.X) ,2) + Math.Pow(other._center.Y - this._center.Y, 2))); //|Sqrt((x2-x1)^2 + (y2-y1)^2)|
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ball)) return false; //Null, or not ball type

            Ball input = obj as Ball; //Get the input as type ball
            float distance = this.GetDistance(input); //Find the distance between the two balls

            return distance <= this._radius || distance <= input._radius; //If the distance is less than either balls radius, we have overlap
        }

        public override int GetHashCode()
        {
            return 1; //Everything goes through our Equals override
        }

        public int CompareTo(object obj)
        {
            //Have to have a ball or we cry
            if (!(obj is Ball)) throw new ArgumentException("Not a valid ball, or null.");

            //We have our ball
            Ball temp = (Ball)obj;

            //Make our origin point
            Ball origin = new Ball(1);
            origin._center.X = 0;
            origin._center.Y = 0;

            //Need something to output since we only want one return
            int outCompare;

            switch (Ball.sort){
                case ESortType.eColour:
                    //Check if our colour is higher than their colour
                    outCompare = this._colour.ToArgb() - temp._colour.ToArgb();
                    break;
                case ESortType.eDistance:
                    //Check if our distance from (0,0) is higher than theirs
                    outCompare = (int)(this.GetDistance(origin) - temp.GetDistance(origin));
                    break;
                case ESortType.eRadius:
                    //Check if our radius is higher than their radius
                    outCompare = this._radius.CompareTo(temp._radius);
                    break;
                default:
                    throw new Exception("Unable to find compare type");
            }

            return outCompare;
        }
    }
}
