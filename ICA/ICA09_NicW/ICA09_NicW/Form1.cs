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
            canvas = new CDrawer(800, (int)UI_numericUpDown_Queues.Value * scale, true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {

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
