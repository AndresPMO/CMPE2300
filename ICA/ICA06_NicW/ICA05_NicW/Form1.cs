using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA06_NicW
{
    
    public partial class Form1 : Form
    {
        private List<Ball> ballList = new List<Ball>();
        private int radius = -50;

        public Form1()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //Scrolling the mouse wheel makes the blocks bigger
            if (e.Delta > 0)
                radius++;
            else
                radius--;

            //Reflect this change on the add button
            UI_button_AddBalls.Text = $"Add exclusive balls ({radius.ToString()})";
        }

        private void UI_button_AddBalls_Click(object sender, EventArgs e)
        {
            int addedCounter = 0;
            int discardCounter = 0;
            Ball temp;


            //try ~1000 times to add 25 balls
            while(addedCounter < 25 && discardCounter < 1000)
            {
                temp = new Ball(radius);

                lock (ballList)
                {
                    if (ballList.IndexOf(temp) >= 0)
                    {
                        discardCounter++;
                    }
                    else
                    {
                        ballList.Add(temp);
                        addedCounter++;
                    }
                }
            }
            //draw the balls
            Ball.Load = true;
            lock (ballList)
            {
                for (int i = 0; i < ballList.Count; i++)
                {
                    ballList[i].ShowBall();
                }
            }
            Ball.Load = false;

            //show the user our effort
            progressBar_Discards.Value = discardCounter;
            Text = $"Added {addedCounter} unique balls, with {discardCounter} discarded balls";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.OemMinus)
            {
                lock (ballList)
                {
                    //clear the list
                    ballList.Clear();
                }
                //clear the drawer
                Ball.Load = true;
                Ball.Load = false;
            }
        }

        private void UI_radioButton_Radius_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, UI_radioButton_Colour))
            {
                lock (ballList)
                {
                    ballList.Sort(Ball.CompareByColour);
                }
            }
            else if (ReferenceEquals(sender, UI_radioButton_Distance))
            {
                lock (ballList)
                {
                    ballList.Sort(Ball.CompareByDistance);
                }
            }
            else if (ReferenceEquals(sender, UI_radioButton_Radius))
            {
                lock (ballList)
                {
                    ballList.Sort(Ball.CompareTo);
                }
            }

            

            Ball.Load = true;
            lock (ballList)
            {
                for(int i = 0; i < ballList.Count; i++)
                {
                    ballList[i].ShowBall();
                    Thread.Sleep(1);
                    Ball.Load = false;
                }
            }
        }
    }
}
