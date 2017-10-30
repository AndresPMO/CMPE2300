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

namespace ICA10_NicW
{
    public partial class Form1 : Form
    {
        static Random randNum = new Random();
        List<Point> list = new List<Point>();
        LinkedList<Point> Linked = new LinkedList<Point>();
        CDrawer canvas = new CDrawer(800, 600, false);

        public Form1()
        {
            InitializeComponent();
        }

        private void UI_button_MakeList_Click(object sender, EventArgs e)
        {
            //How much to go up by every pass
            int divisor = (int)UI_numericUpDown_Divisor.Value;

            //Clear our current points
            list.Clear();

            //Go through all the x values for every y value (X then Y)
            for(int y = 0; y < canvas.ScaledHeight; y += divisor)
            {
                for(int x = 0; x < canvas.ScaledWidth; x += divisor)
                {
                    list.Add(new Point(x, y));
                }
            }

            //All but the last in the list
            //Draw a fuchsia line to the next point
            canvas.Clear();
            for(int i = 0; i < list.Count - 1; i++)
            {
                canvas.AddLine(list[i].X, list[i].Y, list[i + 1].X, list[i + 1].Y, Color.Fuchsia, 1);
            }
            canvas.Render();

            UI_button_MakeList.Text = $"List contains: {list.Count} points";
        }

        private void UI_button_Shuffle_Click(object sender, EventArgs e)
        {
            //Need something in our list
            if (list.Count == 0) return;

            //Do a shuffle!


            //All but the last in the list
            //Draw a fuchsia line to the next point
            canvas.Clear();
            for (int i = 0; i < list.Count - 1; i++)
            {
                canvas.AddLine(list[i].X, list[i].Y, list[i + 1].X, list[i + 1].Y, Color.Fuchsia, 1);
            }
            canvas.Render();
        }

        private void UI_button_LinkedList_Click(object sender, EventArgs e)
        {
            //Need something in our list
            if (list.Count == 0) return;

            //Do a sort!


            //Draw some lines!
            LinkedListNode<Point> current = Linked.First;
            canvas.Clear();
            while(current.Next != null)
            {
                canvas.AddLine(current.Value.X, current.Value.Y, current.Next.Value.X, current.Next.Value.Y, Color.Yellow, 1);

                current = current.Next;
            }
            canvas.Render();
        }
    }
}
