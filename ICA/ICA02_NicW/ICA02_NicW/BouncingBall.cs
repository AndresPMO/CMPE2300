using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA02_NicW
{
    class BouncingBall
    {
        static Random randNum = new Random();

        private Point _pCenter;
        public Point Location { get { return _pCenter; } }

        private int _iXVel;
        public int XVelocity { set { _iXVel = value; } }

        private int _iYVel;
        public int YVelocity
        {
            set {
                if (value < -10)
                    _iYVel = -10;
                else if (value > 10)
                    _iYVel = 10;
                else
                    _iYVel = value;
            }
        }

        private Color _cBallColor;
        public int Opacity { private get; set; }
        public int Radius { get; }

        public BouncingBall(Point inPoint, Color inColor, int inRadius, int inXVel, int inYVel, int inOpacity)
        {
            _pCenter = inPoint;
            _cBallColor = inColor;
            Radius = inRadius;
            XVelocity = inXVel;
            YVelocity = inYVel;
            Opacity = inOpacity;
        }

        public BouncingBall(Point Click) : this(Click, RandColor.GetColor(), 40, randNum.Next(-10, 11), randNum.Next(-10, 11), 128)
        {
        }
            

        public void MoveBall(CDrawer canvas)
        {
            //X velocity
            if(Location.X + Radius < canvas.m_ciWidth && Location.X - Radius > 0)
            {
                _pCenter.X += _iXVel;
            }
            else
            {
                _iXVel *= -1;
                _pCenter.X += _iXVel;
            }
            //Y velocity
            if(Location.Y + Radius < canvas.m_ciHeight && Location.Y - Radius > 0)
            {
                _pCenter.Y += _iYVel;
            }
            else
            {
                _iYVel *= -1;
                _pCenter.Y += _iYVel;
            }
        }

        public void RenderBall(CDrawer canvas)
        {
            canvas.AddCenteredEllipse(Location, Radius, Radius, Color.FromArgb(Opacity, _cBallColor));
        }

        public override string ToString()
        {
            //Point location, velocity x,y, opacity
            return Location.ToString() + " - Vel: " + _iXVel.ToString() + ", " + _iYVel.ToString() + ", Opacity: " + Opacity.ToString();
        }
    }
}
