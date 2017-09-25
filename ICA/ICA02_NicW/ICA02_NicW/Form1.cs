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

namespace ICA02_NicW
{
    public partial class Form1 : Form
    {
        CDrawer canvas = new CDrawer(800, 600, false);
        List<BouncingBall> BallList = new List<BouncingBall>();
        public Form1()
        {
            InitializeComponent();
        }

        private void UI_trackBar_Opacity_Scroll(object sender, EventArgs e)
        {
            UI_label_Opacity.Text = UI_trackBar_Opacity.Value.ToString();

            //If all is selected
            if (UI_checkBox_All.Checked)
            {
                for (int i = 0; i < BallList.Count; i++)
                {
                    BallList[i].Opacity = UI_trackBar_Opacity.Value;
                }
            }
            else
            {
                BallList[BallList.Count - 1].Opacity = UI_trackBar_Opacity.Value;
            }
        }

        private void UI_trackBar_X_Scroll(object sender, EventArgs e)
        {
            UI_label_X.Text = UI_trackBar_X.Value.ToString();

            //If all is selected
            if (UI_checkBox_All.Checked)
            {
                for (int i = 0; i < BallList.Count; i++)
                {
                    BallList[i].XVelocity = UI_trackBar_X.Value;
                }
            }
            else
            {
                BallList[BallList.Count - 1].XVelocity = UI_trackBar_X.Value;
            }
        }

        private void UI_trackBar_Y_Scroll(object sender, EventArgs e)
        {
            UI_label_Y.Text = UI_trackBar_Y.Value.ToString();

            //If all is selected
            if (UI_checkBox_All.Checked)
            {
                for (int i = 0; i < BallList.Count; i++)
                {
                    BallList[i].YVelocity = UI_trackBar_Y.Value;
                }
            }
            else
            {
                BallList[BallList.Count - 1].YVelocity = UI_trackBar_Y.Value;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Screen has been left clicked, add a ball
            if (canvas.GetLastMouseLeftClick(out Point LClick))
            {
                BallList.Add(new BouncingBall(LClick)); //Add a ball at the click point
            }
            //Right click, delete all balls
            if (canvas.GetLastMouseRightClick(out Point RClick))
            {
                BallList.Clear();
            }

            //Move the balls and then render them
            canvas.Clear();
            for (int i = 0; i < BallList.Count; i++)
            {
                BallList[i].MoveBall(canvas);
            }
            for (int i = 0; i < BallList.Count; i++)
            {
                BallList[i].RenderBall(canvas);
            }
            canvas.Render();

            //Change title
            if (BallList.Count > 0)
            {
                Text = BallList[BallList.Count-1].ToString();
            }
        }
    }
}
