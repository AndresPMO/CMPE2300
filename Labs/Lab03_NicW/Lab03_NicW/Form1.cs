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
        //Create a list of all of our car types
        Car[] Types = { new VSedan(4), new VSedan(-4), new HAmbulance(7), new HAmbulance(-7), new HRacecar(12), new HRacecar(-12), new VHippy(6), new VHippy(-6) };
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
            Traffic = new List<Car>();
        }

        //After 2 seconds, spawn a new random car
        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Car tempCar = Types[Car.randNum.Next(Types.Length)];
            Traffic?.Add(tempCar);
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
            foreach(Car vehicle in Traffic)
            {
                //The foreach only changes score
                //It doesn't have the ability to remove cars
                if (Traffic.Contains(vehicle))
                {
                    //Get the car you hit
                    temp = Traffic[Traffic.IndexOf(vehicle)];
                    //Decrease score from both cars
                    score += (vehicle.GetHitScore() + temp.GetHitScore());
                }
                if (Car.OutOfBounds(vehicle))
                {
                    //Car made it safely, increase the score
                    score += vehicle.GetSafeScore();
                }
            }
            //Remove all colliding cars
            Traffic.RemoveAll(car => Traffic.Contains(car));

            //Remove all cars that are out of bounds
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