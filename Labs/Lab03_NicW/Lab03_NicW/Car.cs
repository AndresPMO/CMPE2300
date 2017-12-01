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
    /// <summary>
    /// IAnimateable - An interface to determine if our cars have an animation
    /// </summary>
    interface IAnimateable
    {
        /// <summary>
        /// Changes member data to give the illusion of animation
        /// </summary>
        void Animate();
    }

    /// <summary>
    /// Car - A base class that provides basic members and functionality for a moving car on a canvas
    /// </summary>
    abstract class Car
    {
        //Canvas is the game screen, shared by all vehicles
        private static PictDrawer canvas;
        public static PictDrawer Canvas {
            get
            {
                return canvas;
            }
            set
            {
                //Close the current canvas before making a new one
                canvas?.Close();
                canvas = value;
            }
        }
        //A shared random number generator
        public static Random randNum { get; set; }

        //Locations that the cars can spawn at
        protected static readonly int[] Up = { 270, 590 };      //The X locations to spawn cars
        protected static readonly int[] Down = { 170, 490 };    //The X locations to spawn cars
        protected static readonly int[] Left = { 164 };         //The Y locations to spawn cars
        protected static readonly int[] Right = { 260 };        //The Y locations to spawn cars

        //Location, Size, Speed of the car and its children
        protected float XPos;       //The leftmost point of the collision rectangle
        protected float YPos;       //The topmost point of the collision rectangle
        protected float Speed;      //The top speed of the vehicle
        protected int Width;        //The X size of the vehicle
        protected int Height;       //The Y size of the vehicle
        protected bool FullSpeed;   //Whether to use the top speed of the vehicle or half

        /// <summary>
        /// Car - The constructor to make a car
        /// </summary>
        /// <param name="inSpeed">The top speed of the vehicle</param>
        /// <param name="inWidth">The X size of the vehicle</param>
        /// <param name="inHeight">The Y size of the vehicle</param>
        public Car(float inSpeed, int inWidth, int inHeight)
        {
            Speed = inSpeed;
            Width = inWidth;
            Height = inHeight;
            FullSpeed = true;
        }

        /// <summary>
        /// GetRect - This will make a rectangle of the vehicle
        /// </summary>
        /// <returns>The hit box of the vehicle</returns>
        public abstract Rectangle GetRect();

        /// <summary>
        /// VShowCar - Virtual method to add your car to the game screen
        /// </summary>
        protected abstract void VShowCar();
        /// <summary>
        /// ShowCar - Will add your car to the game screen
        /// </summary>
        public void ShowCar()
        {
            VShowCar();
        }

        /// <summary>
        /// VMove - Virtual method to move your car in desired direction
        /// </summary>
        protected abstract void VMove();
        /// <summary>
        /// Move - Will move your car based on its speed and direction
        /// </summary>
        public void Move()
        {
            VMove();
        }

        //Checks if the rectangles of either cars are overlapping
        public override bool Equals(object obj)
        {
            if (!(obj is Car) || (this == obj)) return false; //Must be a car, can't be itself
            Car temp = obj as Car;           //Cast as a car
            //Compare via rectangle
            return GetRect().IntersectsWith(temp.GetRect());
        }
        //Make sure to use .Equals for all comparisons
        public override int GetHashCode()
        {
            return 0;
        }
        
        /// <summary>
        /// PointOnCar - Check if a point is inside of a rectangle
        /// </summary>
        /// <param name="inPoint">The point to check against</param>
        /// <returns>Whether the point is inside the rectangle</returns>
        public bool PointOnCar(Point inPoint)
        {
            return GetRect().Contains(inPoint);
        }
        
        /// <summary>
        /// OutOfBounds - Checks if the whole car has left the game screen
        /// </summary>
        /// <param name="inCar">The car to check boundaries on</param>
        /// <returns>True if car is out of bounds, false if car is on screen</returns>
        public static bool OutOfBounds(Car inCar)
        {
            //Make a rectangle that is the full play area
            Rectangle bounds = new Rectangle(0, 0, Canvas.ScaledWidth, Canvas.ScaledHeight);
            //Check to see if the car no longer intersects with the play area
            return !inCar.GetRect().IntersectsWith(bounds);
        }
        /// <summary>
        /// This will toggle the speed of the car between full speed and half speed
        /// </summary>
        public void ToggleSpeed()
        {
            //FullSpeed is equal to not FullSpeed (ie. toggle)
            FullSpeed = !FullSpeed;
        }

        public abstract int GetSafeScore();
        public abstract int GetHitScore();
    }

    /// <summary>
    /// HorizontalCar - A base class that provides horizontal movement to the base car class
    /// </summary>
    abstract class HorizontalCar : Car
    {
        /// <summary>
        /// HorizontalCar - Creates a horizantally moving car at a random Y position chosen from our Left/Right collection
        /// </summary>
        /// <param name="inSpeed">The horizontal speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public HorizontalCar(float inSpeed, int inWidth, int inHeight) : base( inSpeed, inWidth, inHeight)
        {
            if(inSpeed > 0)
            {
                //Going right, start just outside the left of the screen
                XPos = 0 - inWidth;
                //Get a random selection from the Right array of locations
                YPos = Right[randNum.Next(Right.Length)];
            }
            else if (inSpeed < 0)
            {
                //Going left, start just outside of the right of the screen
                XPos = Canvas.ScaledWidth;
                //Get a random selection from the Right array of locations
                YPos = Left[randNum.Next(Left.Length)];
            }
            else
            {
                //Car is not moving, not possible
                throw new ArgumentException("Speed of a vehicle cannot be 0");
            }
        }

        /// <summary>
        /// VMove - Since we are moving horizontally, increment X by our speed
        /// </summary>
        protected override void VMove()
        {
            //Check if we are supposed to move at full speed or not
            if (FullSpeed)
            {
                //Full speed ahead!
                XPos += Speed;
            }
            else
            {
                //Half speed
                XPos += Speed/2;
            }
            
        }
    }

    /// <summary>
    /// VerticalCar - A base class that provides vertical movement to the base car class
    /// </summary>
    abstract class VerticalCar : Car
    {
        /// <summary>
        /// VerticalCar - Creates a vertically moving car at a random X position chosen from our Up/Down collection
        /// </summary>
        /// <param name="inSpeed">The vertical speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public VerticalCar(float inSpeed, int inWidth, int inHeight) : base(inSpeed, inWidth, inHeight)
        {
            if(inSpeed > 0)
            {
                //Car is moving down
                XPos = Down[randNum.Next(Down.Length)];
                YPos = 0 - inHeight;
            }
            else if (inSpeed < 0)
            {
                //Car is moving up
                XPos = Up[randNum.Next(Up.Length)];
                YPos = Canvas.ScaledHeight;
            }
            else
            {
                //Car is not moving, not possible
                throw new ArgumentException("Speed of a vehicle cannot be 0");
            }
        }

        /// <summary>
        /// VMove - Since we are moving vertically, increment Y by our speed
        /// </summary>
        protected override void VMove()
        {
            //Check if we are supposed to move at full speed or not
            if (FullSpeed)
            {
                //Full speed ahead!
                YPos += Speed;
            }
            else
            {
                //Half speed
                YPos += Speed / 2;
            }
        }
    }

    class VSedan : VerticalCar
    {
        protected Color colour = RandColor.GetColor();

        /// <summary>
        /// VSedan - Simply initializes the VerticalCar base class
        /// </summary>
        /// <param name="inSpeed">The vertical speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public VSedan(float inSpeed, int inWidth = 40, int inHeight = 70) : base(inSpeed, inWidth, inHeight)
        {}

        /// <summary>
        /// GetRect - Will supply the x, y, width, and height to create a rectangle of where the car is
        /// </summary>
        /// <returns></returns>
        public override Rectangle GetRect()
        {
            return new Rectangle((int)XPos, (int)YPos, Width, Height);
        }

        /// <summary>
        /// VShowCar - Will add our rectangle to the car with tires
        /// </summary>
        protected override void VShowCar()
        {
            //Get our hitbox from GetRect
            Rectangle hitbox = GetRect();

            //Add tires; 2 wide, 10 high
            Canvas.AddRectangle(hitbox.X - 2,            hitbox.Y + 5,                  2, 10, Color.Black);   //Top left
            Canvas.AddRectangle(hitbox.X - 2,            hitbox.Y + hitbox.Height - 15, 2, 10, Color.Black);   //Bottom left
            Canvas.AddRectangle(hitbox.X + hitbox.Width, hitbox.Y + 5,                  2, 10, Color.Black);   //Top right
            Canvas.AddRectangle(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height - 15, 2, 10, Color.Black);   //Bottom right

            //Add the body of our car in red
            Canvas.AddRectangle(hitbox, Color.Blue);
        }

        /// <summary>
        /// GetSafeScore - When the car leaves the boundaries of the gameboard, this is its point gain value
        /// </summary>
        /// <returns>The point gain value of this car</returns>
        public override int GetSafeScore()
        {
            return 1;
        }
        /// <summary>
        /// GetHitScore - When the car collides with another car, this is the point loss value
        /// </summary>
        /// <returns>The point loss value of this car</returns>
        public override int GetHitScore()
        {
            return GetSafeScore()*-1;
        }
    }
}
