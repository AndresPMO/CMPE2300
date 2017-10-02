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

    class Ball
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
            _center = new PointF(randNum.Next(_radius, canvas.ScaledWidth - _radius), randNum.Next(_radius, canvas.ScaledHeight - _radius));
        }

        //Static methods
        //Instance methods
    }
}
