/*
Author: Nicholas Wasylyshyn 
Project: Lab 03 - Crash
Class: A02
*/
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
        //Public interface for the canvas
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
        protected Color Paint;      //The colour of the vehicles body

        /// <summary>
        /// Car - The constructor to make a car
        /// </summary>
        /// <param name="inSpeed">The top speed of the vehicle</param>
        /// <param name="inWidth">The X size of the vehicle</param>
        /// <param name="inHeight">The Y size of the vehicle</param>
        /// <param name="bodyCol">The colour of the vehicle</param>
        public Car(float inSpeed, int inWidth, int inHeight, Color bodyCol)
        {
            Speed = inSpeed;
            Width = inWidth;
            Height = inHeight;
            Paint = bodyCol;
            FullSpeed = true; //Cars start at full speed
        }

        /// <summary>
        /// Car - The static constructor to initialize randNum
        /// </summary>
        static Car()
        {
            randNum = new Random();
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

        /// <summary>
        /// GetSafeScore - Get the score of the car when it exits the screen
        /// </summary>
        /// <returns>The score of the car</returns>
        public abstract int GetSafeScore();

        /// <summary>
        /// GetHitScore - Get the score of the car when it hits another car
        /// </summary>
        /// <returns>The negative score of the car</returns>
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
        /// <param name="bodyCol">The colour of the vehicle</param>
        public HorizontalCar(float inSpeed, int inWidth, int inHeight, Color bodyCol) : base( inSpeed, inWidth, inHeight, bodyCol)
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
        /// <param name="bodyCol">The colour of the vehicle</param>
        public VerticalCar(float inSpeed, int inWidth, int inHeight, Color bodyCol) : base(inSpeed, inWidth, inHeight, bodyCol)
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

    /// <summary>
    /// VSedan - A vertical car that moves at 4 pixels per tick and has a blue body
    /// </summary>
    class VSedan : VerticalCar
    {
        protected Color colour = RandColor.GetColor();

        /// <summary>
        /// VSedan - Simply initializes the VerticalCar base class
        /// </summary>
        /// <param name="inSpeed">The vertical speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public VSedan(float inSpeed = 4, int inWidth = 40, int inHeight = 70) : base(inSpeed, inWidth, inHeight, Color.Blue)
        {}

        /// <summary>
        /// GetRect - Will supply the x, y, width, and height to create a rectangle of where the car is
        /// </summary>
        /// <returns>The hitbox of the car</returns>
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
            Canvas.AddRectangle(hitbox, Paint);
        }

        /// <summary>
        /// GetSafeScore - When the car leaves the boundaries of the gameboard, this is its point gain value
        /// </summary>
        /// <returns>The point gain value of this car</returns>
        public override int GetSafeScore()
        {
            return Math.Abs((int)Speed);
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

    /// <summary>
    /// VHippy - A vertical car that moves at 6 pixels per tick and has a changing body colour
    /// </summary>
    class VHippy : VerticalCar, IAnimateable
    {
        /// <summary>
        /// VHippy - Simply initializes the VerticalCar base class
        /// </summary>
        /// <param name="inSpeed">The vertical speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public VHippy(float inSpeed = 6, int inWidth = 50, int inHeight = 60) : base(inSpeed, inWidth, inHeight, Color.Green)
        { }

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
            Canvas.AddRectangle(hitbox.X - 2, hitbox.Y + 5, 2, 10, Color.Black);   //Top left
            Canvas.AddRectangle(hitbox.X - 2, hitbox.Y + hitbox.Height - 15, 2, 10, Color.Black);   //Bottom left
            Canvas.AddRectangle(hitbox.X + hitbox.Width, hitbox.Y + 5, 2, 10, Color.Black);   //Top right
            Canvas.AddRectangle(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height - 15, 2, 10, Color.Black);   //Bottom right

            //Add the body of our car in red
            Canvas.AddRectangle(hitbox, Paint);
        }

        /// <summary>
        /// Animate - Will make the body of the car change color
        /// </summary>
        public void Animate()
        {
            Paint = RandColor.GetColor();
        }

        /// <summary>
        /// GetSafeScore - When the car leaves the boundaries of the gameboard, this is its point gain value
        /// </summary>
        /// <returns>The point gain value of this car</returns>
        public override int GetSafeScore()
        {
            return Math.Abs((int)Speed);
        }
        /// <summary>
        /// GetHitScore - When the car collides with another car, this is the point loss value
        /// </summary>
        /// <returns>The point loss value of this car</returns>
        public override int GetHitScore()
        {
            return GetSafeScore() * -1;
        }
    }

    /// <summary>
    /// HAmbulance - A horizontal car that moves at 7 pixels per tick, has a white body, and flashing lights
    /// </summary>
    class HAmbulance : HorizontalCar, IAnimateable
    {
        //The colour of the lights on top of the car
        Color lightOne = Color.Blue;
        Color lightTwo = Color.Red;

        /// <summary>
        /// VSedan - Simply initializes the HorizontalCar base class
        /// </summary>
        /// <param name="inSpeed">The vertical speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public HAmbulance(float inSpeed = 7, int inWidth = 90, int inHeight = 40) : base(inSpeed, inWidth, inHeight, Color.White)
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
        /// VShowCar - Will add our rectangle to the car with tires, and animated lights
        /// </summary>
        protected override void VShowCar()
        {
            //Get our hitbox from GetRect
            Rectangle hitbox = GetRect();

            //Add tires; 10 wide, 2 high, black
            Canvas.AddRectangle(hitbox.X + 5,                   hitbox.Y - 2,              10, 2, Color.Black);   //Top left
            Canvas.AddRectangle(hitbox.X + 5,                   hitbox.Y + hitbox.Height,  10, 2, Color.Black);   //Bottom left
            Canvas.AddRectangle(hitbox.X + hitbox.Width - 15,   hitbox.Y -2,               10, 2, Color.Black);   //Top right
            Canvas.AddRectangle(hitbox.X + hitbox.Width - 15,    hitbox.Y + hitbox.Height, 10, 2, Color.Black);   //Bottom right
            
            //Add the body of our car in red
            Canvas.AddRectangle(hitbox, Paint);

            //Add the animated lights
            Canvas.AddRectangle(hitbox.X + Width / 2 - 2, hitbox.Y, 4, Height / 2, lightOne);
            Canvas.AddRectangle(hitbox.X + Width / 2 - 2, hitbox.Y + Height / 2, 4, Height / 2, lightTwo);
        }

        /// <summary>
        /// Animate - Will swap the color of the lights that are on top of the car
        /// </summary>
        public void Animate()
        {
            if(lightOne == Color.Blue)
            {
                lightOne = Color.Red;
                lightTwo = Color.Blue;
            }
            else
            {
                lightOne = Color.Blue;
                lightTwo = Color.Red;
            }
        }

        /// <summary>
        /// GetSafeScore - When the car leaves the boundaries of the gameboard, this is its point gain value
        /// </summary>
        /// <returns>The point gain value of this car</returns>
        public override int GetSafeScore()
        {
            return Math.Abs((int)Speed);
        }
        /// <summary>
        /// GetHitScore - When the car collides with another car, this is the point loss value
        /// </summary>
        /// <returns>The point loss value of this car</returns>
        public override int GetHitScore()
        {
            return GetSafeScore() * -1;
        }
    }

    /// <summary>
    /// HRacecar - A horizontal car that moves at 12 pixels per tick, has a red body, and flashing text
    /// </summary>
    class HRacecar : HorizontalCar, IAnimateable
    {
        //The changing colour on the car
        Color textColor = RandColor.GetColor();

        /// <summary>
        /// HRacecar - Simply initializes the VerticalCar base class
        /// </summary>
        /// <param name="inSpeed">The horizontal speed of the car</param>
        /// <param name="inWidth">The width of the car's hit box</param>
        /// <param name="inHeight">The height of the car's hit box</param>
        public HRacecar(float inSpeed = 12, int inWidth = 100, int inHeight = 30) : base(inSpeed, inWidth, inHeight, Color.Red)
        { }

        /// <summary>
        /// GetRect - Will supply the x, y, width, and height to create a rectangle of where the car is
        /// </summary>
        /// <returns></returns>
        public override Rectangle GetRect()
        {
            return new Rectangle((int)XPos, (int)YPos, Width, Height);
        }

        /// <summary>
        /// VShowCar - Will add our rectangle to the car with tires, and animated lights
        /// </summary>
        protected override void VShowCar()
        {
            //Get our hitbox from GetRect
            Rectangle hitbox = GetRect();

            //Add tires; 10 wide, 5 high, black
            Canvas.AddRectangle(hitbox.X + 5,                 hitbox.Y - 5,             10, 5, Color.Black);   //Top left
            Canvas.AddRectangle(hitbox.X + 5,                 hitbox.Y + hitbox.Height, 10, 5, Color.Black);   //Bottom left
            Canvas.AddRectangle(hitbox.X + hitbox.Width - 15, hitbox.Y - 5,             10, 5, Color.Black);   //Top right
            Canvas.AddRectangle(hitbox.X + hitbox.Width - 15, hitbox.Y + hitbox.Height, 10, 5, Color.Black);   //Bottom right

            //Add the body of our car in red
            Canvas.AddRectangle(hitbox, Paint);

            //Add animated text to the top of the car
            Canvas.AddText("Racecar", 12, hitbox, textColor);
        }

        /// <summary>
        /// Changes the colour of the text on top of the car
        /// </summary>
        public void Animate()
        {
            textColor = RandColor.GetColor();
        }

        /// <summary>
        /// GetSafeScore - When the car leaves the boundaries of the gameboard, this is its point gain value
        /// </summary>
        /// <returns>The point gain value of this car</returns>
        public override int GetSafeScore()
        {
            return Math.Abs((int)Speed);
        }
        /// <summary>
        /// GetHitScore - When the car collides with another car, this is the point loss value
        /// </summary>
        /// <returns>The point loss value of this car</returns>
        public override int GetHitScore()
        {
            return GetSafeScore() * -1;
        }
    }
}