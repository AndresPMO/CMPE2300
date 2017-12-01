using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using MyDrawers;

namespace Lab03_NicW
{
    public partial class Form1 : Form
    {
        //Create a game screen to play on
        PictDrawer canvas;
        //Create a list to hold all of our cars
        List<Car> Traffic;
        //Game score
        int score;

        //Form constructor, do initializations here
        public Form1()
        {
            InitializeComponent();
            //Initialize our canvas
            canvas = new PictDrawer(Properties.Resources.Crash, false, true);
            //Connect the canvas to all the cars
            Car.Canvas = canvas;
            //Give the cars a random
            Car.randNum = new Random();
            //No score at the start of the game
            score = 0;
            //Initialize our list of cars
            Traffic = new List<Car>() { new VSedan(4), new VSedan(-4) };
        }

        //After 2 seconds, spawn a new random car
        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            //Car tempCar;
            //switch (Car.randNum.Next(2))
            //{
            //    case 0:
            //        tempCar = new VSedan();
            //        break;
            //    case 1:
            //        tempCar = new HAmbulance();
            //        break;
            //    default:
            //        tempCar = null;
            //        break;
            //}
            //Traffic?.Add(tempCar);
        }

        //Every 100ms process the game information. ie movements and animations
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //Make sure we have a canvas and a list of cars to use
            if(canvas == null || Traffic == null)
            {
                return; //Can't do anything without a canvas or list of cars
            }

            //Check if we have a new mouse click
            Point mouse;
            if (canvas.GetLastMouseLeftClickScaled(out mouse))
            {
                //We got a new click, check if it was on a car
                //If it is, slow it down
                Traffic.ForEach(car => { if (car.PointOnCar(mouse)) car.ToggleSpeed(); }) ;
            }

            //Move all the cars
            Traffic.ForEach(car => car.Move());

            //Remove all colliding cars, decrease score
            Traffic.RemoveAll(car => Traffic.Contains(car));
            //Remove all cars that are out of bounds, increase score
            Traffic.RemoveAll(car => Car.OutOfBounds(car));

            //Write the score on the forms title
            Text = $"Score = {score} points";

            //Animate all the cars that have animations
            Traffic.ForEach(car => (car as IAnimateable)?.Animate());

            //Clear and render all the cars
            canvas.Clear();
            Traffic.ForEach(car => car.ShowCar());
            canvas.Render();
        }
    }
}
