using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using MyDrawers;

namespace Lab03_NicW
{
    abstract class Car
    {
        //Canvas is where the gameboard is
        public static PictDrawer Canvas {
            get
            {
                return Canvas;
            }
            set
            {
                Canvas.Close();
                Canvas = value;
            }
        }
        public static Random randNum { get; set; }

        //Locations that the cars can spawn at
        protected static readonly int[] Up;
        protected static readonly int[] Down;
        protected static readonly int[] Left;
        protected static readonly int[] Right;

        //Location, Size, Speed of the car and its children
        protected float XPos;
        protected float YPos;
        protected float Speed;
        protected int Width;
        protected int Height;
        protected bool FullSpeed;

        public Car(float inSpeed, int inWidth, int inHeight)
        {
            Speed = inSpeed;
            Width = inWidth;
            Height = inHeight;
        }

        public abstract Rectangle GetRect();

        protected abstract void VShowCar();
        public void ShowCar()
        {
            VShowCar();
        }

        protected abstract void VMove();
        public void Move()
        {
            VMove();
        }

        //Checks if the rectangles of either cars are overlapping
        public override bool Equals(object obj)
        {
            if (!(obj is Car)) return false; //Must be a car
            Car temp = obj as Car;           //Cast as a car
            //Compare via rectangle
            return GetRect().Contains(temp.GetRect());
        }
        //Make sure to use .Equals for all comparisons
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
