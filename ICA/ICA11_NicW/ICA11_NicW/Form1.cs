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
            }
        }

        private void UI_button_Average_Click(object sender, EventArgs e)
        {
            //Only keep the values that are above the average.
            //                 |    Find the average value, only accepts values higher than average        ||Return the enumerable to dictionary, key-key and val-val|
            byteDict = byteDict.Where(input => input.Value > byteDict.Average(frequency => frequency.Value)).ToDictionary(input => input.Key, value => value.Value);

            ShowDictionary();
        }

        private void UI_listView_Bytes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Put the dictionary in a list
            List<KeyValuePair<byte, int>> temp = byteDict.ToList();

            if(e.Column == 0)
            {
                //Column Byte
                temp.Sort((arg1, arg2) => arg1.Key.CompareTo(arg2.Key));
            }
            else if (e.Column == 1)
            {
                //Column Count
                temp.Sort((arg1, arg2) => arg1.Value.CompareTo(arg2.Value));
            }

            //Put the list back into the dictionary
            byteDict = temp.ToDictionary(key => key.Key, val => val.Value);

            ShowDictionary();
        }

        private void ShowDictionary()
        {
            //have to have something to show
            if (byteDict.Count == 0)
            {
                //Clear the listview
                UI_listView_Bytes.Items.Clear();
                UI_button_Average.Text = $"Average";
                return;
            }

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
                temp = new ListViewItem(entry.Key.ToString("X2"));
                //Add the frequency with a background colour.
                //Light green for higher than average, light coral for lower than average.
                temp.SubItems.Add(entry.Value.ToString(), Color.Black, entry.Value > average ? Color.LightGreen : Color.LightCoral, Font);
                temp.UseItemStyleForSubItems = false;
                UI_listView_Bytes.Items.Add(temp);
            }
        }
    }
}
