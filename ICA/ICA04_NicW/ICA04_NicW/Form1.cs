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

namespace ICA04_NicW
{
    public partial class Form1 : Form
    {
        private int blockSize = 80;
        private List<Block> blockList = new List<Block>();
        private Block mouseBlock;

        public Form1()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
            Block.Canvas.MouseMoveScaled += Canvas_MouseMoveScaled;
            Block.Canvas.MouseLeftClickScaled += Canvas_MouseLeftClickScaled;
        }

        private void Canvas_MouseLeftClickScaled(Point pos, CDrawer dr)
        {
            //Get a block that is identical to the block we clicked
            Block clickBlock = new Block(blockSize, pos);

            if (true)
            {
                lock (blockList)
                {
                    while (blockList.Remove(clickBlock)) ;
                }
            }
            else
            {
                //Check to see if we have deleted something
                bool deleteFlag = false;
                //While we haven't deleted something, remove blocks overlapping the clickBlock
                do
                {
                    //assume that nothing is deleted
                    deleteFlag = false;
                    lock (blockList)
                    {
                        //Go through until you find a block that overlaps
                        for (int i = 0; i < blockList.Count; i++)
                        {
                            if (blockList[i].Equals(clickBlock))
                            {
                                //Delete the overlapping block and tell it to restart the checking
                                blockList.RemoveAt(i);
                                deleteFlag = true;
                                break;
                            }
                        }
                    }

                } while (deleteFlag);

            }

            //Clear the canvas and then render the blocks
            Block.Load = true;
            //Make sure the list doesn't change, lock it down
            lock (blockList)
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    blockList[i].ShowBlock();
                }
            }
            //Show the mouse block
            mouseBlock.ShowBlock();
            //Render
            Block.Load = false;
        }

        private void Canvas_MouseMoveScaled(Point pos, CDrawer dr)
        {
            //Follow the mouse with a block
            mouseBlock = new Block(blockSize, pos);

            //Check if the blocks collide with the mouse
            lock (blockList)
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    //Assume that it isn't highlighted
                    blockList[i].Highlight = false;
                    //Check if it is highlighted
                    if (blockList[i].Equals(mouseBlock))
                        blockList[i].Highlight = true;
                }
            }

            //Clear the canvas and then render the blocks
            Block.Load = true;
            //Make sure the list doesn't change, lock it down
            lock (blockList)
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    blockList[i].ShowBlock();
                }
            }
            //Show the mouse block
            mouseBlock.ShowBlock();
            //Render
            Block.Load = false;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //Scrolling the mouse wheel makes the blocks bigger
            if (e.Delta > 0)
                blockSize++;
            else
                blockSize--;

            //Reflect this change on the add button
            UI_button_Add.Text = "Add Blocks: Size - " + blockSize.ToString();
        }

        private void UI_button_Add_Click(object sender, EventArgs e)
        {
            //How many blocks were added or removed from the list
            int blocksAdded = 0;
            int blocksRemoved = 0;
            //Block to check if we can add it
            Block temp;

            //only add 25 blocks or have 1000 failed blocks
            while(blocksAdded < 25 && blocksRemoved < 1000)
            {
                //make a new block
                temp = new Block(blockSize);
                //Doing stuff to the list, lock it down
                lock (blockList)
                {
                    //Found an overlap
                    if (blockList.IndexOf(temp) >= 0)
                    {
                        //Didn't add a block, counts as removed
                        blocksRemoved++;
                    }
                    //No overlapping
                    else
                    {
                        //Add the block to the list
                        blockList.Add(temp);
                        blocksAdded++;
                    }
                }
            }
            
            //Clear the canvas and then render the blocks
            Block.Load = true;
            //Make sure the list doesn't change, lock it down
            lock (blockList)
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    blockList[i].ShowBlock();
                }
            }
            Block.Load = false;

            //Display the blocks removed on the progress bar
            UI_progressBar_Discard.Value = blocksRemoved;
            //Display how succesful we were on the form title
            Text = "Loaded " + blocksAdded.ToString() + " unique blocks, with " + blocksRemoved.ToString() + " discards";
        }
    }
}
