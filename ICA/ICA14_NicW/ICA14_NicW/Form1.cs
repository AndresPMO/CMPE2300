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
using MyDrawers;

namespace ICA14_NicW
{
    public partial class Form1 : Form
    {
        PictDrawer canvas;
        Keys inputKey = Keys.None;
        List<Block> blockList = new List<Block>();

        public Form1()
        {
            InitializeComponent();
            
            //Initialize the canvas
            canvas = new PictDrawer(Properties.Resources.HumanTransmutation);
            
            //Start the movement thread
            Thread thread = new Thread(MoveThread);
            thread.IsBackground = true;
            thread.Start();

            //Start the show thread
            thread = new Thread(ShowThread);
            thread.IsBackground = true;
            thread.Start();

            //Start the input thread
            thread = new Thread(InputThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void MoveThread()
        {
            //Run forever
            while (true)
            {
                lock (blockList)
                {
                    //Move each block in the list
                    blockList.ForEach(block => block.Move(blockList));
                }
                //Stop doing anything for 100ms
                Thread.Sleep(100);
            }
        }

        private void ShowThread()
        {
            //Run forever
            while (true)
            {
                //Clear the canvas
                canvas.Clear();
                lock (blockList)
                {
                    //Show each block in the list
                    blockList.ForEach(block => block.ShowBlock(canvas));
                }
                //Render the canvas
                canvas.Render();
                //Stop doing anything for 50ms
                Thread.Sleep(50);
            }
        }

        private void InputThread()
        {
            //Run forever
            while (true)
            {
                //Check if we have a key to process
                if(inputKey != Keys.None)
                {
                    if(inputKey == Keys.F)
                    {
                        //Add a falling block
                        lock (blockList)
                        {
                            //blockList.Add(new FallingBlock());
                        }
                    }
                    else if (inputKey == Keys.D)
                    {
                        lock (blockList)
                        {
                            //blockList.Add(new DrunkBlock());
                        }
                    }
                    else if (inputKey == Keys.C)
                    {
                        lock (blockList)
                        {
                            //blockList.Add(new ColourBlock());
                        }
                    }
                    else if (inputKey == Keys.Escape)
                    {
                        //Remove all the outside blocks
                        lock (blockList)
                        {
                            blockList.RemoveAll(block => block.Outside);
                        }
                    }
                    else if (inputKey == Keys.F1)
                    {
                        //Remove all of the blocks
                        lock (blockList)
                        {
                            blockList.Clear();
                        }
                    }

                    //Done with the key, default it
                    inputKey = Keys.None;
                }
                //Stop doing anything for 50ms
                Thread.Sleep(50);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            inputKey = e.KeyCode;
        }
    }
}
