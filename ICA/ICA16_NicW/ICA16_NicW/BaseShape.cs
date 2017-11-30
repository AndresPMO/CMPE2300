using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using MyDrawers;

namespace ICA16_NicW
{
    public abstract class BaseShape
    {
        public static PictDrawer _canvas { get; set; }
        public static Random _rnd { get; private set; }
        private Point _pt { get; set; } //Center of shape
        public Color _color { get; private set; } //Colour of shape
        private double _dir = 0;    //Radians vector of direction
        private double _vel = 5;    //Movement velocity

        static BaseShape()
        {
            _rnd = new Random(0);
        }
        public BaseShape(Point pt, Color c)
        {
            _pt = pt;
            _color = c;
            //0 is right, then counter clockwise, in radians
            _dir = _rnd.NextDouble() * 2 * Math.PI;
        }

        public Point Move() // NVI - public Move() 
        {
            return VirtualMove(); // invokes VirtualMove()
        }
        protected virtual Point VirtualMove()
        {
            // Adjust current direction by small random amount
            _dir = _dir + (_rnd.NextDouble() * 0.8 - 0.4);
            // Calculate new X, Y based on direction and velocity
            int iNewX = _pt.X + (int)(_vel * Math.Cos(_dir));
            int iNewY = _pt.Y - (int)(_vel * Math.Sin(_dir));
            // Bounce by adding 90 degrees to direction
            if (iNewX < 0 || iNewX >= _canvas.ScaledWidth)
            {
                _dir += Math.PI / 2;
                iNewX = _pt.X;
            }
            if (iNewY < 0 || iNewY >= _canvas.ScaledHeight)
            {
                _dir += Math.PI / 2;
                iNewY = _pt.Y;
            }
            _pt = new Point(iNewX, iNewY); // Save and return new Point
            return _pt;
        }

        public void Paint() // NVI - public Paint()
        {
            VirtualPaint(); // invokes VirtualPaint()
        }
        protected abstract void VirtualPaint();
    }
}
