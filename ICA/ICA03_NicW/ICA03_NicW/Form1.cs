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

namespace ICA03_NicW
{
    public partial class Form1 : Form
    {
        List<Ball> ballList = new List<Ball>();
        public Form1()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
            //make a thread to do all the continuous functions
            Thread thread = new Thread(new ThreadStart(threadFunction));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //Increase the ball radius using the mouse wheel
            Ball.Radius += e.Delta / 10;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Add)
            {
                lock (ballList)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ballList.Add(new Ball());
                    }
                }
            }
            if(e.KeyCode == Keys.Subtract)
            {
                lock (ballList)
                {
                    ballList.Clear();
                }
            }
        }

        private void threadFunction()
        {
            //infinite loop for thread
            while (true)
            {
                Ball.Loading = true;
                lock (ballList)
                {
                    for (int i = 0; i < ballList.Count; i++)
                    {
                        ballList[i].MoveBall();
                    }
                    for (int i = 0; i < ballList.Count; i++)
                    {
                        ballList[i].ShowBall();
                    }
                }
                Ball.Loading = false;
                Thread.Sleep(25);
            }
        }

        
    }
}
