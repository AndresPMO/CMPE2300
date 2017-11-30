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
    class Blob : BaseShape, IAnimatable
    {
        private int radius;
        private Point center;
        private double animationAngle;

        public Blob(Point location, int radii) : base(location, Color.Blue)
        {
            radius = radii;
            center = location;
            animationAngle = 0;
        }

        protected override Point VirtualMove()
        {
            center = base.VirtualMove();
            return center;
        }

        protected override void VirtualPaint()
        {
            //radius = (int)(radius + Math.Cos(animationAngle));

            _canvas.AddCenteredEllipse(center, (int)(radius + Math.Cos(animationAngle)) * 2, (int)(radius + Math.Cos(animationAngle)) * 2, _color);
        }

        public void Animate(CDrawer canvas)
        {
            animationAngle += Math.PI / 8;
        }
    }
}
