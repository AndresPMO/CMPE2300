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

namespace ICA8_NicW
{
    public partial class Form1 : Form
    {
        List<BouncingBalls> greenList = new List<BouncingBalls>();
        List<BouncingBalls> blueList = new List<BouncingBalls>();
        List<BouncingBalls> redList = new List<BouncingBalls>();

        CDrawer bgCanvas;
        CDrawer rCanvas;

        public Form1()
        {
            InitializeComponent();
            bgCanvas = new CDrawer(800, 600, false);
            rCanvas = new CDrawer(800, 600, false);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Left click, add a green ball
            if(bgCanvas.GetLastMouseLeftClickScaled(out Point lclick))
            {
                BouncingBalls temp = new BouncingBalls(lclick, Color.Green);
                if (!greenList.Contains(temp))
                {
                    greenList.Add(temp);
                }
            }
            //Right click, add a blue ball
            if(bgCanvas.GetLastMouseRightClickScaled(out Point rclick))
            {
                BouncingBalls temp = new BouncingBalls(rclick, Color.Green);
                if(blueList.IndexOf(temp) < 0)
                {
                    blueList.Insert(0, temp);
                }
            }

            //Move all the balls
            greenList.ForEach(o => o.MoveBall(bgCanvas));
            blueList.ForEach(o => o.MoveBall(bgCanvas));
            redList.ForEach(o => o.MoveBall(bgCanvas));

            //Check collisions
            List<BouncingBalls> templist = greenList.Intersect(blueList).ToList();
            //Set collisions to red, remove from green and blue list
            templist.ForEach(o => { o.colour = Color.Red; greenList.Remove(o); blueList.Remove(o); });
            //Add the temp list to the red list (Collisions)
            redList = redList.Union(templist).ToList();

            //Clear the canvases
            bgCanvas.Clear();
            rCanvas.Clear();
            //Add the counts to them
            bgCanvas.AddText($"Blue : {blueList.Count} Green : {greenList.Count}", 50, Color.DodgerBlue);
            rCanvas.AddText($"{redList.Count}", 50, Color.DodgerBlue);

            for(int i = 0; i < blueList.Count; i++)
            {
                blueList[i].ShowBall(bgCanvas, i);
            }
            for (int i = 0; i < greenList.Count; i++)
            {
                greenList[i].ShowBall(bgCanvas, i);
            }
            for (int i = 0; i < redList.Count; i++)
            {
                redList[i].ShowBall(rCanvas, i);
            }

            bgCanvas.Render();
            rCanvas.Render();
        }
    }
}
