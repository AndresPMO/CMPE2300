using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA11_NicW
{
    public partial class Form1 : Form
    {
        Dictionary<byte, int> byteDict = new Dictionary<byte, int>();

        public Form1()
        {
            InitializeComponent();
            UI_listView_Bytes.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void UI_button_Load_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //We got a good file to open
                //Get all the bytes out of it
                byte[] arrayBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);

                //Iterate through the array we read
                foreach(byte b in arrayBytes)
                {
                    if (byteDict.ContainsKey(b))
                    {
                        //The dictionary has the byte, increment its count
                        byteDict[b]++;
                    }
                    else
                    {
                        //The dictionary doesn't have the byte, add it with one count
                        byteDict[b] = 1;
                    }
                }
            }
        }

        private void UI_button_Average_Click(object sender, EventArgs e)
        {
            //Remove the ones that are below average
        }

        private void UI_listView_Bytes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(e.Column == 0)
            {
                //Column Byte
            }
            else if (e.Column == 1)
            {
                //Column Count
            }
        }
    }
}
