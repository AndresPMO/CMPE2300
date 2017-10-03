using System;
using System.Drawing;
using GDIDrawer;

namespace ICA03_NicW
{
    class Ball
    {
        //Static members
        static private Random randNum = new Random();
        static private CDrawer canvas = null;
        static private int _radius;
        static public int Radius
        {
            get { return _radius; }
            set {
                //Make sure the radius is positive and not bigger than 1/4 of the screen
                if(Math.Abs(value) > Math.Min(canvas.ScaledWidth, canvas.ScaledHeight) / 4)
                {
                    value = Math.Min(canvas.ScaledWidth, canvas.ScaledHeight) / 4;
                }
                value = Math.Abs(value);
                _radius = value;
            }
        }
        //Instance members
        private Color colour;
        private Point location;
        private int xVelocity;
        private int yVelocity;
        private int lifeSpan;

        //Static constructor
        static Ball()
        {
            canvas = new CDrawer(randNum.Next(600, 901), randNum.Next(500, 801), false);
            Radius = randNum.Next(10, 81);
        }

        //Instance constructor
        public Ball()
        {
            this.lifeSpan = randNum.Next(50, 128);
            this.colour = RandColor.GetColor();
            this.xVelocity = randNum.Next(-10, 11);
            this.yVelocity = randNum.Next(-10, 11);
            this.location = new Point(randNum.Next(Radius, canvas.ScaledWidth - Radius), randNum.Next(Radius, canvas.ScaledHeight - Radius));
        }
        //Make the ball on the static CDrawer
        public void ShowBall()
        {
            canvas.AddCenteredEllipse(location, Radius*2, Radius*2, Color.FromArgb(lifeSpan, colour));
        }
        //Move the ball, staying inside the CDrawer
        public void MoveBall()
        {
            //Reincarnation code
            this.lifeSpan--;
            if (lifeSpan < 1)
            {
                this.lifeSpan = randNum.Next(50, 128);
                this.location = new Point(randNum.Next(Radius, canvas.ScaledWidth - Radius), randNum.Next(Radius, canvas.ScaledHeight - Radius));
            }

            //Movement
            //X velocity
            if (this.location.X + Radius + this.xVelocity > canvas.m_ciWidth || this.location.X - Radius + this.xVelocity < 0)
            {
                this.xVelocity *= -1;
            }
            this.location.X += this.xVelocity;
            
            //Y velocity
            if (this.location.Y + Radius + this.yVelocity > canvas.m_ciHeight || this.location.Y - Radius + this.yVelocity < 0)
            {
                this.yVelocity *= -1;
            }
            this.location.Y += this.yVelocity;

            //When we change the radius, make sure the ball stays inside the drawer
            if (this.location.X + Radius < 0)
                this.location.X = Radius;
            else if (this.location.X + Radius > canvas.ScaledWidth)
                this.location.X = canvas.ScaledWidth - Radius;

            if (this.location.Y + Radius < 0)
                this.location.Y = Radius;
            else if (this.location.Y + Radius > canvas.ScaledHeight)
                this.location.Y = canvas.ScaledHeight - Radius;
        }
        
        static public bool Loading {
            //If load is true, clear the drawer
            //if false, render it
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
    }
}
