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
                Package tempPackage;

                //Read all the lines
                while (!sReader.EndOfStream)
                {
                    //Read a line in the file
                    tempString = sReader.ReadLine();

                    //Split the line into seperate strings, based on spaces
                    tempSArray = tempString.Split(' ');

                    //Put those strings into a package
                    tempPackage = new Package(tempSArray);
                    
                    if (!plLoaded.Contains(tempPackage))
                    {
                        //Not a duplicate, add to list
                        plLoaded.Add(tempPackage);
                    }
                    else
                    {
                        //A duplicate, add its dependancies to the existing package
                        plLoaded[plLoaded.IndexOf(tempPackage)].MergePackage(tempPackage);
                    }
                }
                //Don't need to read anymore data
                sReader.Close();

                //Show all packages
                UI_toolStripComboBox_View.SelectedIndex = 0;
                ShowSelectedLoad();
            }
        }

        private void UI_toolStripButton_Analyze_Click(object sender, EventArgs e)
        {

        }

        private void ShowSelectedLoad()
        {
            //Want to remove everything from the list view
            UI_listView_Packages.Items.Clear();
            //Check how we want to sort
            int sort = UI_toolStripComboBox_View.SelectedIndex;
            //The list reference to use
            List<Package> reference;
            //Assign the reference
            switch(sort)
            {
                case 0:
                    reference = plLoaded;
                    break;
                case 1:
                    reference = plInstalled;
                    break;
                case 2:
                    reference = plUnInstalled;
                    break;
                default:
                    reference = null;
                    break;
            }

            //Make a temporary item to add to the listview
            ListViewItem temp;
            foreach(Package p in reference)
            {
                //Give temp a unique name
                temp = new ListViewItem(p.Name);

                //Add the name as an item
                temp.SubItems.Add(p.Name);

                //Add the dependancies as an item
                temp.SubItems.Add(p.ToString());

                //Add it to the listview
                UI_listView_Packages.Items.Add(temp);

                //Remove the added items from temp for next pass
                temp.SubItems.Clear();
            }
            
            //Show on the status strip how many things are in each list
            UI_toolStripStatus_Loaded.Text = $"{plLoaded.Count} Packages Loaded";
            UI_toolStripStatus_Installable.Text = $"{plInstalled.Count} Packages Installable";
            UI_toolStripStatus_UnInstallble.Text = $"{plUnInstalled.Count} Packages UnInstallable";
        }
    }
}
