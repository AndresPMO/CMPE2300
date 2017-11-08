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
        //has a byte as the key, an int as the frequency of that byte
        Dictionary<byte, int> byteDict = new Dictionary<byte, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
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
                ShowDictionary();
                //We have something to average, enable the button
                UI_button_Average.Enabled = true;
            }
        }

        private void UI_button_Average_Click(object sender, EventArgs e)
        {
            //Only keep the values that are above or equal to the average.
            //                 |    Find the average value, only accepts values >= to average               ||           Return the enumerable to dictionary       |
            byteDict = byteDict.Where(input => input.Value >= byteDict.Average(frequency => frequency.Value)).ToDictionary(input => input.Key, value => value.Value);

            ShowDictionary();
        }

        private void UI_listView_Bytes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Have nothing to sort, prevent problems
            if (byteDict.Count == 0) return;
            
            if(e.Column == 0)
            {
                //Column Byte
                byteDict = byteDict.OrderBy(key => key.Key).ToDictionary(key => key.Key, value => value.Value);
            }
            else if (e.Column == 1)
            {
                //Put the dictionary in a list
                List<KeyValuePair<byte, int>> temp = byteDict.ToList();
                //Column Count
                temp.Sort((arg1, arg2) => arg1.Value == arg2.Value ? arg1.Key.CompareTo(arg2.Key) : arg1.Value.CompareTo(arg2.Value));
                //Put the list back into the dictionary
                byteDict = temp.ToDictionary(key => key.Key, val => val.Value);
            }
            
            ShowDictionary();
        }

        private void ShowDictionary()
        {
            //Get the average frequency value from the dictionary
            double average = byteDict.Average(input => input.Value);
            //Write out the average, no decimal
            UI_button_Average.Text = $"Average : {(int)average}";

            //Clear the listview
            UI_listView_Bytes.Items.Clear();

            ListViewItem temp;
            //Add each item to the listview
            foreach (KeyValuePair<byte, int> entry in byteDict)
            {
                //Add the key to the first column
                temp = new ListViewItem(entry.Key.ToString("X"));
                //Add the frequency with a background colour.
                //Light green for higher than average, light coral for lower than average.
                temp.SubItems.Add(entry.Value.ToString(), Color.Black, entry.Value >= average ? Color.LightGreen : Color.LightCoral, Font);
                temp.UseItemStyleForSubItems = false;
                //Actually adding it to the listview
                UI_listView_Bytes.Items.Add(temp);
            }
        }
        
    }
}
