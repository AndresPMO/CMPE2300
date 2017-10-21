using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_NicW
{
    public partial class Form1 : Form
    {
        private enum SortType { eRawList, eLibraryList, eSortedList }

        //The three lists for all three types of view
        List<Package> plLoaded = new List<Package>();
        List<Package> plInstalled = new List<Package>();
        List<Package> plUnInstalled = new List<Package>();

        //System.IO.ReadAllLines(Path) returns an array of string

        public Form1()
        {
            InitializeComponent();
        }

        private void UI_toolStripButton_Load_Click(object sender, EventArgs e)
        {
            if(UI_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Make something to read the data from file
                System.IO.StreamReader sReader = new System.IO.StreamReader(UI_openFileDialog.FileName);
                //Make places to store the data temporarily
                string tempString;
                string[] tempSArray;

                while (sReader.EndOfStream)
                {
                    //Read a line in the file
                    tempString = sReader.ReadLine();
                    //Split the line into seperate strings, based on spaces
                    tempSArray = tempString.Split(' ');
                }
            }
        }

        private void UI_toolStripButton_Analyze_Click(object sender, EventArgs e)
        {

        }
    }
}
