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

            greenList.ForEach(o => o.MoveBall(bgCanvas));
            blueList.ForEach(o => o.MoveBall(bgCanvas));
            redList.ForEach(o => o.MoveBall(bgCanvas));

            List<BouncingBalls> templist = greenList.Intersect(blueList).ToList();
        }
    }
}
