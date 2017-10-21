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
            //Always have a selected index for the combo boxes
            UI_toolStripComboBox_Algorithm.SelectedIndex = 0;
            UI_toolStripComboBox_View.SelectedIndex = 0;
        }

        private void UI_toolStripButton_Load_Click(object sender, EventArgs e)
        {
            //Make sure the user opened a file
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
            //Make sure there is something to analyze
            if(plLoaded.Count > 0)
            {
                plUnInstalled = new List<Package>(plLoaded);
                plInstalled = new List<Package>();
            }

            //Stopwatch to see how long each sort takes
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //Figure out the algorithm to use
            SortType sort = (SortType)UI_toolStripComboBox_Algorithm.SelectedIndex;
            stopwatch.Restart();
            switch (sort)
            {
                case SortType.eRawList:
                    RawInstall();
                    break;
                case SortType.eLibraryList:
                    LibraryInstall();
                    break;
                case SortType.eSortedList:
                    SortedInstall();
                    break;
            }
            stopwatch.Stop();

            Text = stopwatch.Elapsed.TotalSeconds.ToString("F4");

            //Show the installed selection
            UI_toolStripComboBox_View.SelectedIndex = 1;
            //Display the analysed data
            ShowSelectedLoad();
        }

        private void UI_toolStripComboBox_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedLoad();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UI_listView_Packages.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
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
            
            foreach(Package p in reference)
            {
                //Give temp the package as two strings in an array
                ListViewItem temp = new ListViewItem(new[] { p.Name, p.ToString() });
                //Add it to the listview
                UI_listView_Packages.Items.Add(temp);
            }
            
            //Show on the status strip how many things are in each list
            UI_toolStripStatus_Loaded.Text = $"{plLoaded.Count} Packages Loaded";
            UI_toolStripStatus_Installable.Text = $"{plInstalled.Count} Packages Installable";
            UI_toolStripStatus_UnInstallble.Text = $"{plUnInstalled.Count} Packages UnInstallable";
        }

        private void RawInstall()
        {
            //bool to see if something was installed
            bool install;
            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;

                foreach (Package p in plUnInstalled)
                {
                    //Can be installed if it has zero dependancies
                    //OR if all its dependancies have already been installed
                    if (p.Dependacies.Count == 0 || p.Dependacies.All(o => plInstalled.Contains(new Package(new[] { o }))))
                    {
                        //Say it can be installed
                        plInstalled.Add(p);
                        //Keep looping since we installed something
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(p);
                        break;
                    }
                }
            } while (install);
        }

        private void LibraryInstall()
        {

        }

        private void SortedInstall()
        {

        }

    }
}
