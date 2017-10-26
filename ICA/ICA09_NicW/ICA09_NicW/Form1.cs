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

namespace ICA09_NicW
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> stackSheeple = new Stack<Sheeple>();
        List<Queue<Sheeple>> ListQueue = new List<Queue<Sheeple>>();
        CDrawer canvas = null;
        const int scale = 20;
        int Processed = 0;
        bool running = false;

        object key = new object();
        

        public Form1()
        {
            InitializeComponent();
        }
        
        private void UI_button_Simulate_Click(object sender, EventArgs e)
        {
            running = false;
            stackSheeple.Clear();
            ListQueue.Clear();
            Processed = 0;
            if (canvas != null)
                canvas.Close();
            canvas = new CDrawer(1600, (int)UI_numericUpDown_Queues.Value * scale, true);
            canvas.Scale = scale;

            for(int i = 0; i < 200; i++)
            {
                stackSheeple.Push(new Sheeple());
            }

            for(int i = 0; i < UI_numericUpDown_Queues.Value; i++)
            {
                ListQueue.Add(new Queue<Sheeple>());
            }

            Thread thread;
            running = true;

            lock (key)
            {
                foreach (Queue<Sheeple> q in ListQueue)
                {
                    thread = new Thread(new ParameterizedThreadStart(ThreadProcess));
                    thread.IsBackground = true;
                    thread.Start(q);
                }
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //need a canvas to do anything
            if(canvas == null)
            {
                return;
            }

            //#1
            if(stackSheeple.Count > 0)
            {
                //If we have something to add, try to add it to a queue
                lock (key)
                {
                    ListQueue.ForEach(q =>
                    {
                        //Add a sheeple if we have less than 10 and there is one to add
                        if (q.Count < 10 && stackSheeple.Count > 0)
                        {
                            q.Enqueue(stackSheeple.Pop());
                        }

                    });
                }
            }
            if(stackSheeple.Count > 0)
            {
                UI_label_Sheeple.Text = stackSheeple.Peek().TotalItems.ToString();
                UI_label_Sheeple.BackColor = stackSheeple.Peek().Colour;
            }
            //#2
            canvas.Clear();
            int y = 0;
            lock (key)
            {
                ListQueue.ForEach(lq =>
                {
                    int x = 0;
                    foreach (Sheeple sheep in lq)
                    {
                        sheep.ShowSheeple(canvas, sheep, x, y);
                        x += sheep.TotalItems;
                    }
                    y++;
                });
            }
        }

        private void ThreadProcess(object obj)
        {
            //Getting the valid input
            if (!(obj is Queue<Sheeple>)) return; //Bad input, not a queue, or null
            Queue<Sheeple> queue = obj as Queue<Sheeple>;
            
            //Getting the sleep time
            Random randNum = new Random();
            int sleepTime = randNum.Next(20, 41) * 10;

            //While the flag is true
            while (running)
            {
                //Sleep the thread
                Thread.Sleep(sleepTime);

                lock (key)
                {
                    //Make sure the queue has something in it
                    if (queue.Count > 0)
                    {
                        queue.Peek().Process();
                        if (queue.Peek().CurrentItems == 0)
                        {
                            Processed += queue.Dequeue().TotalItems;
                        }
                    }
                }
            }
        }
    }
}
