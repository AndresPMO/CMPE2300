/*
Author: Nicholas Wasylyshyn 
Project: Lab 03 - Crash
Class: A02
*/
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
            //No score at the start of the game
            score = 0;
            //Initialize our list of cars
            Traffic = new List<Car>();
        }

        //After 4 seconds, spawn a new random car, decrease interval by 10ms every tick
        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Car tempCar = null;

            //Pick a random car type with a +/- speed
            switch (Car.randNum.Next(8))
            {
                case 0:
                    tempCar = new VSedan(4);
                    break;
                case 1:
                    tempCar = new VSedan(-4);
                    break;
                case 2:
                    tempCar = new HAmbulance(7);
                    break;
                case 3:
                    tempCar = new HAmbulance(-7);
                    break;
                case 4:
                    tempCar = new HRacecar(12);
                    break;
                case 5:
                    tempCar = new HRacecar(-12);
                    break;
                case 6:
                    tempCar = new VHippy(6);
                    break;
                case 7:
                    tempCar = new VHippy(-6);
                    break;
            }

            //If traffic is not null, add the car
            Traffic?.Add(tempCar);
            //decrease interval
            if(SpawnTimer.Interval > 1000)
                SpawnTimer.Interval -= 10;
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

            //A temporary car to compare
            Car temp;
            foreach(Car vehicle in Traffic.ToList())
            {
                //The foreach only changes score
                if (Traffic.Contains(vehicle))
                {
                    //Get the car you hit
                    temp = Traffic[Traffic.IndexOf(vehicle)];
                    //Decrease score from both cars
                    score += (vehicle.GetHitScore() + temp.GetHitScore());

                    //Remove the cars
                    Traffic.RemoveAll(input => object.ReferenceEquals(input, vehicle));
                    Traffic.RemoveAll(input => object.ReferenceEquals(input, temp));
                }
                if (Car.OutOfBounds(vehicle))
                {
                    //Car made it safely, increase the score
                    score += vehicle.GetSafeScore();
                    //Remove the car
                    Traffic.RemoveAll(input => object.ReferenceEquals(input, vehicle));


                }
            }

            //Write the score on the forms title
            Text = $"Score = {score} points";

            //Animate all the cars that have animations
            Traffic.ForEach(car => (car as IAnimateable)?.Animate());

            //Clear and render all the cars
            canvas.Clear();
            Traffic.ForEach(car => car.ShowCar());
            canvas.Render();

            //End the game if score is too low
            if(score < 0)
            {
                canvas.Clear();
                canvas.AddText("Game Over", 35, Color.Red);
                canvas.Render();
                SpawnTimer.Enabled = false;
                GameTimer.Enabled = false;
            }
        }
    }
}