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

namespace ICA16_NicW
{
    public partial class Form1 : Form
    {
        List<BaseShape> Shapes = new List<BaseShape>();
        PictDrawer canvas = new PictDrawer(Properties.Resources._1200px_Fairy_tail_logo, false);

        public Form1()
        {
            InitializeComponent();
            //Give the shapes a canvas to use
            BaseShape._canvas = canvas;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            canvas.Clear();

            foreach(BaseShape bs in Shapes.ToList())
            {
                if(bs is IAnimatable)
                {
                    (bs as IAnimatable).Animate(canvas);
                }
                if(bs is IMortal)
                {
                    //If it is dead, remove it
                    if(!(bs as IMortal).Step())
                        Shapes.Remove(bs);
                }
                bs.Move();
                bs.Paint();
            }

            canvas.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point mouse;
            canvas.GetLastMousePosition(out mouse);

            if(e.KeyCode == Keys.C)
            {
                Shapes.Clear();
            }
            else if (e.KeyCode == Keys.S)
            {
                Shapes.Add(new Snake(mouse, Snake._rnd.Next(20, 60)));
            }
            else if (e.KeyCode == Keys.B)
            {
                Shapes.Add(new Blob(mouse, Blob._rnd.Next(30, 50)));
            }
        }
    }
}
