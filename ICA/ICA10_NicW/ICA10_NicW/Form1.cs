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
        List<Point> listPoint = new List<Point>();
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
            listPoint.Clear();

            //Go through all the x values for every y value (X then Y)
            for(int y = 0; y < canvas.ScaledHeight; y += divisor)
            {
                for(int x = 0; x < canvas.ScaledWidth; x += divisor)
                {
                    listPoint.Add(new Point(x, y));
                }
            }

            //All but the last in the list
            //Draw a fuchsia line to the next point
            canvas.Clear();
            for(int i = 0; i < listPoint.Count - 1; i++)
            {
                canvas.AddLine(listPoint[i].X, listPoint[i].Y, listPoint[i + 1].X, listPoint[i + 1].Y, Color.Fuchsia, 1);
            }
            canvas.Render();

            UI_button_MakeList.Text = $"List contains: {listPoint.Count} points";
        }

        private void UI_button_Shuffle_Click(object sender, EventArgs e)
        {
            //Need something in our list
            if (listPoint.Count == 0) return;

            //Shuffle our list
            listPoint = listPoint.shuffle();

            //All but the last in the list
            //Draw a fuchsia line to the next point
            canvas.Clear();
            for (int i = 0; i < listPoint.Count - 1; i++)
            {
                canvas.AddLine(listPoint[i].X, listPoint[i].Y, listPoint[i + 1].X, listPoint[i + 1].Y, Color.Green, 1);
            }
            canvas.Render();
        }
        
        private void UI_button_LinkedList_Click(object sender, EventArgs e)
        {
            //Need something in our list
            if (listPoint.Count == 0) return;

            //Do a sort!
            Linked.Clear();
            foreach(Point p in listPoint)
            {
                LinkedListNode<Point> sort;
                for (sort = Linked.First; sort != null; sort = sort.Next)
                {
                    //if sort is greater than p
                    if ((sort.Value.X * canvas.ScaledHeight + sort.Value.Y) > (p.X * canvas.ScaledHeight + p.Y))
                    {
                        break;
                    }
                }

                if(sort == null)
                {
                    //Got to the end of the list
                    Linked.AddLast(p);
                }
                else
                {
                    //Got to a node that was bigger than our point
                    Linked.AddBefore(sort, p);
                }
            }

            //Draw some lines!
            LinkedListNode<Point> current = Linked.First;
            canvas.Clear();
            while(current.Next != null)
            {
                canvas.AddLine(current.Value.X, current.Value.Y, current.Next.Value.X, current.Next.Value.Y, Color.Yellow, 1);

                current = current.Next;
            }
            canvas.Render();

            UI_button_LinkedList.Text = $"LinkedList contains: {Linked.Count} points";
        }

        
    }

    public static class MyLibrary
    {
        static public List<Point> shuffle(this List<Point> inList)
        {
            Random randNum = new Random();
            List<Point> outList = new List<Point>(inList);

            //Do a shuffle! Fischer-Yates
            Point temp;
            for (int i = outList.Count - 1; i > 1; i--)
            {
                int j = randNum.Next(0, i + 1); // 0 <= j <= i
                //Hold onto i
                temp = outList[i];
                //swap j to i
                outList[i] = outList[j];
                //swap i to j
                outList[j] = temp;
            }

            return outList;
        }
    }
}
