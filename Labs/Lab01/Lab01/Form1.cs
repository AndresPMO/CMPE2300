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

namespace Lab01
{
    public partial class Form1 : Form
    {
        //Delegates for threads
        public delegate void delvoidint(int x);
        public delegate void delvoidstring(string x);
        public delegate void delvoidbool(bool x);
        public delegate void delvoidBitmap(Bitmap x);
        public delegate Color delColorColorint(Color x, int y);
        public delegate byte delbyteListint(List<int> x);
        
        public enum ColourDecode { Red, Green, Blue, RGB}

        public struct objectInput
        {
            public Bitmap image;
            public ColourDecode decode;

            public objectInput(Bitmap bmInput, ColourDecode numInput)
            {
                image = bmInput;
                decode = numInput;
            }
        }

        //The master copy of the loaded image. Used as input for decoding
        public Bitmap masterCopy = null;

        public Form1()
        {
            InitializeComponent();
        }

        //Colour decoding
        public void decodeRGBLoop(object input)
        {
            if(input is objectInput)
            {
                //Inputs must be objects
                Bitmap inImage;
                ColourDecode inDecode;
                //Used to transfer the input object to the local variables
                objectInput transfer;

                //Cast the input objects to required types
                transfer = (objectInput)input;
                inImage = new Bitmap(transfer.image);
                inDecode = transfer.decode;

                //Image will be changed, we need a temp bitmap to set the pixels to
                Bitmap temp = new Bitmap(inImage.Width, inImage.Height);
                float progress = 0;

                //goes through every pixel in the bitmap, Image.
                for (int y = 0; y < inImage.Height; y++)
                {
                    for (int x = 0; x < inImage.Width; x++)
                    {
                        //Check the pixel based on the chosen colour
                        //Adjust pixel accordingly

                        //Red decoding
                        if (inDecode == ColourDecode.Red)
                        {
                            //Read the bytes first bit. If set, change pixel to colour
                            if (inImage.GetPixel(x, y).R % 2 == 1)
                            {
                                temp.SetPixel(x, y, Color.Red);
                            }
                            else
                            {
                                temp.SetPixel(x, y, Color.Black);
                            }
                        }
                        //Green decoding
                        else if (inDecode == ColourDecode.Green)
                        {
                            //Read the bytes first bit. If set, change pixel to colour
                            if (inImage.GetPixel(x, y).G % 2 == 1)
                            {
                                temp.SetPixel(x, y, Color.Green);
                            }
                            else
                            {
                                temp.SetPixel(x, y, Color.Black);
                            }
                        }
                        //Blue decoding
                        else if (inDecode == ColourDecode.Blue)
                        {
                            //Read the bytes first bit. If set, change pixel to colour. Else, to black
                            if (inImage.GetPixel(x, y).B % 2 == 1)
                            {
                                temp.SetPixel(x, y, Color.Blue);
                            }
                            else
                            {
                                temp.SetPixel(x, y, Color.Black);
                            }
                        }
                        //RGB decoding
                        else if (inDecode == ColourDecode.RGB)
                        {
                            uint decodedColor = 0xFF000000;
                            //Read the bytes first bit. If set, change pixel to colour. Else, to black
                            if (inImage.GetPixel(x, y).R % 2 == 1)
                            {
                                //Add full red to the colour
                                decodedColor |= 0x00FF0000;
                            }
                            //Read the bytes first bit. If set, change pixel to colour. Else, to black
                            if (inImage.GetPixel(x, y).G % 2 == 1)
                            {
                                //Add full green to the colour
                                decodedColor |= 0x0000FF00;
                            }
                            //Read the bytes first bit. If set, change pixel to colour. Else, to black
                            if (inImage.GetPixel(x, y).B % 2 == 1)
                            {
                                //Add full blue to the colour
                                decodedColor |= 0x000000FF;
                            }
                            temp.SetPixel(x, y, Color.FromArgb((int)decodedColor));
                        }
                    }

                    //Increase progress bar
                    progress = (float)(y + 1) / inImage.Height;
                    Invoke(new delvoidint(progressBarChange), (int)(progress * 100));
                }

                //Change the picture box to the decoded image
                //imageChange(temp);
                Invoke(new delvoidBitmap(imageChange), temp);
                //Enable buttons
                Invoke(new delvoidbool(enableLoadImage), true);
                Invoke(new delvoidbool(enableDecode), true);
            }
        }//End of decodeRGBLoop

        //Text decoding
        public void decodeTextLoop(object input)
        {
            if(input is objectInput)
            {
                //Cast the input objects to required types
                objectInput transfer = (objectInput)input;
                Bitmap inImage = new Bitmap(transfer.image);
                ColourDecode inDecode = transfer.decode;

                //The lists to store bits, and then the formed bytes.
                List<int> bitList = new List<int>();
                List<byte> DecodeList = new List<byte>();

                //Getting a list of bits, one from every pixel
                for (int y = 0; y < inImage.Height; y++)
                {
                    for(int x = 0; x < inImage.Width; x++)
                    {
                        //Red decoding
                        if(inDecode == ColourDecode.Red)
                        {
                            //Get the least significant bit, from Red
                            bitList.Add(inImage.GetPixel(x,y).R % 2);
                        }
                        //Green decoding
                        else if (inDecode == ColourDecode.Green)
                        {
                            //Get the least significant bit, from Green
                            bitList.Add(inImage.GetPixel(x, y).G % 2);
                        }
                        //Blue decoding
                        else if(inDecode == ColourDecode.Blue)
                        {
                            //Get the least significant bit, from Blue
                            bitList.Add(inImage.GetPixel(x, y).B % 2);
                        }
                        //RGB decoding
                        else if(inDecode == ColourDecode.RGB)
                        {
                            //Get the least significant bit, from RGB
                            bitList.Add(inImage.GetPixel(x, y).R % 2);
                            bitList.Add(inImage.GetPixel(x, y).G % 2);
                            bitList.Add(inImage.GetPixel(x, y).B % 2);
                        }
                    }
                }
                
                //Put all the bits into a list of bytes
                while (bitList.Count > 8)
                {
                    //Put all the bits into the byte list
                    DecodeList.Add((byte)Invoke(new delbyteListint(bitsToByte), bitList));
                    bitList.RemoveRange(0, 8);
                }

                int textLength = 0; //the length of the encoded text
                int inHeader = 0; //Counts how many headers we have right so far
                List<int> header = new List<int>(new int[]{ 0x55, 0xaa, 0x55, 0xaa, 0x35, 0x22});
                for(int i = 0; i < DecodeList.Count; i++)
                {
                    //We have found a piece of the header, not done the header
                    if (inHeader < 6 && DecodeList[i] == header[inHeader])
                    {
                        //Show that we found a piece
                        inHeader++;
                    } 
                    //We have found the six pieces of the header
                    else if (inHeader == 6)
                    {
                        //Add the length to textLength
                        for (int shift = 0; shift < 4; shift++)
                            textLength += DecodeList[i + shift] << 8 * (3-shift);
                        //Delete all the stuff before and in the header
                        DecodeList.RemoveRange(0, i+4);
                        //We can leave the for loop
                        break;
                    }
                    //Not in the header, show that we have not found the header
                    else
                    {
                        inHeader = 0;
                    }
                }
                
                //Writing the appropriate bytes to the text field,
                //if the length isn't more than the amount of characters
                if (textLength <= DecodeList.Count)
                {
                    //Add each character to a string
                    //Don't want to add each character to the screen, we want the whole thing at once
                    string rtfString = "";
                    for (int i = 0; i < textLength; i++)
                    {
                        rtfString += (char)DecodeList[i];
                    }
                    Invoke(new delvoidstring(textBoxChange), rtfString);
                }

                //Re-enable buttons
                Invoke(new delvoidbool(enableLoadImage), true);
                Invoke(new delvoidbool(enableDecode), true);

                //One hundred percent done  
                Invoke(new delvoidint(progressBarChange), 100);
            }
        }//End of decodeTextLoop
        //Used for text decoding
        private byte bitsToByte(List<int> bits)
        {
            byte OutByte = 0;
            for(int i = 0; i < 8; i++)
            {
                OutByte += (byte)(bits[i] << (7 - i));
            }
            return OutByte;
        }

        //Callback methods for threading
        public void progressBarChange(int value)
        {
            UI_progressBar.Value = value;
        }

        public void textBoxChange(string value)
        {
            UI_richTextBox_Display.Rtf = value;
        }

        public void imageChange(Bitmap image)
        {
            UI_pictureBox_Display.Image = image;
        }
        
        public void enableLoadImage(bool enable)
        {
            UI_toolStripButton_LoadImage.Enabled = enable;
        }

        public void enableDecode(bool enable)
        {
            UI_toolStripButton_Go.Enabled = enable;
        }
        
        //Buttons on toolstrip
        private void UI_toolStripButton_LoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (UI_openFileDialog_PicSelector.ShowDialog() == DialogResult.OK)
                {
                    //Change the picture box to display the selected picture
                    UI_pictureBox_Display.Load(UI_openFileDialog_PicSelector.FileName);
                    masterCopy = (Bitmap)UI_pictureBox_Display.Image;
                    //New pic, ergo reset progress bar and textbox, enable decode button
                    progressBarChange(0);
                    textBoxChange("");
                    enableDecode(true);
                }
            }
            catch
            {
                MessageBox.Show("Unable to open file.", Text);
            }
        }

        private void UI_toolStripButton_Go_Click(object sender, EventArgs e)
        {
            if(UI_toolStrip_TextColorPick.SelectedIndex == 0) //Colour decode
            {
                if(UI_toolStrip_SelectColor.SelectedIndex >= 0) //Selected colour param
                {
                    //Start the thread
                    Thread thread = new Thread(new ParameterizedThreadStart(decodeRGBLoop));
                    thread.IsBackground = true;
                    thread.Start(new objectInput(masterCopy, (ColourDecode)UI_toolStrip_SelectColor.SelectedIndex));
                    //Disable buttons so user can't screw things up
                    enableLoadImage(false);
                    enableDecode(false);
                }
            }
            else if(UI_toolStrip_TextColorPick.SelectedIndex == 1) //Text decode
            {
                if(UI_toolStrip_SelectColor.SelectedIndex >= 0) //Selected colour parm
                {
                    //Start the thread
                    Thread thread = new Thread(new ParameterizedThreadStart(decodeTextLoop));
                    thread.IsBackground = true;
                    thread.Start(new objectInput(masterCopy, (ColourDecode)UI_toolStrip_SelectColor.SelectedIndex));
                    //Disable buttons so user can't screw things up
                    enableLoadImage(false);
                    enableDecode(false);
                }
            }
            
        }
    }
}
