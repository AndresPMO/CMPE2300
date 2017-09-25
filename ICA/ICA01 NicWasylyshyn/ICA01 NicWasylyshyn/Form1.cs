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

namespace ICA01_NicWasylyshyn
{
    public partial class Form1 : Form
    {
        CDrawer canvas = new CDrawer(900, 600, false);
        List<TrekLamp> lampList = new List<TrekLamp>();
        public Form1()
        {
            InitializeComponent();
            canvas.Scale = 50;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            canvas.Clear();
            
            //Go through all the lamps
            for(int i = 0; i < lampList.Count; i++)
            {
                //Tick through
                lampList[i].Tick();
            }
            for (int i = 0; i < lampList.Count; i++)
            {
                //Then render
                lampList[i].RenderLamp(canvas, i);
            }
            canvas.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                lampList.Add(new TrekLamp());
            }
            else if (e.KeyCode == Keys.F2)
            {
                lampList.Add(new TrekLamp(Color.Orange, 180));
            }
            else if (e.KeyCode == Keys.F3)
            {
                Random rand = new Random();
                lampList.Add(new TrekLamp(RandColor.GetColor(), (byte)rand.Next(60, 221), 4));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Remove the last lamp, if there are lamps
                if(lampList.Count>0)
                    lampList.RemoveAt(lampList.Count - 1);
            }
        }
    }
}
