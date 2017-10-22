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
                //Want all new data
                plLoaded = new List<Package>();
                //Can't have anything installed or uninstalled if we loaded a new file
                plInstalled = new List<Package>();
                plUnInstalled = new List<Package>();

                //Make places to store the data temporarily
                string[] allLines = System.IO.File.ReadAllLines(UI_openFileDialog.FileName);
                string[] packInput;
                Package tempPackage;

                foreach (string line in allLines)
                {
                    //split each input with a space
                    packInput = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

                    //Put those strings into a package
                    tempPackage = new Package(packInput);

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
                
                //Show all packages loaded
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

        private void UI_listView_Packages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Sort the selected list by name, then dependancy count
            if(UI_toolStripComboBox_View.SelectedIndex == 0)
            {
                plLoaded.Sort(Package.CompareNameDepCount);
                ShowSelectedLoad();
            }
            else if (UI_toolStripComboBox_View.SelectedIndex == 1)
            {
                plInstalled.Sort(Package.CompareNameDepCount);
                ShowSelectedLoad();
            }
            else
            {
                plUnInstalled.Sort(Package.CompareNameDepCount);
                ShowSelectedLoad();
                
            }
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
            bool install = false;
            //Used to see if all of the dependancies are installed
            bool allDepend = false;
            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;

                foreach (Package uninstalled in plUnInstalled)
                {
                    //Can be installed if it has zero dependancies
                    //OR if all its dependancies have already been installed
                    if (uninstalled.Dependacies.Count == 0)
                    {
                        //Say it can be installed
                        plInstalled.Add(uninstalled);
                        //Keep looping since we installed something
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }

                    
                    //for every uninstalled package, look through all the dependant packages
                    foreach(string depend in uninstalled.Dependacies)
                    {
                        //We assume it doesn't have all the dependancies until we learn it doesn't
                        allDepend = false;

                        //for all the installed packages, check the names of the uninstalled package
                        foreach (Package ins in plInstalled)
                        {
                            if (ins.Name == depend)
                            {
                                allDepend = true;
                                break;
                            }
                        }
                    }

                    //We can install it!
                    if (allDepend)
                    {
                        //Say it can be installed
                        plInstalled.Add(uninstalled);
                        //Keep looping since we installed something
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }
                }
            } while (install);
        }

        private void LibraryInstall()
        {
            //bool to see if something was installed
            bool install = false;
            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;

                foreach(Package uninstalled in plUnInstalled)
                {
                    if (uninstalled.Dependacies.Count == 0)
                    {
                        //No dependancies? Install
                        plInstalled.Add(uninstalled);
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }
                    else if ()
                    {
                        //Go through every dependancy, check if it is contained in the installed list.
                        plInstalled.Add(uninstalled);
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }

                    
                }
            } while (install);
        }

        private void SortedInstall()
        {
            //bool to see if something was installed
            bool install = false;
            //Used to see if all of the dependancies are installed
            bool allDepend = false;
            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;

                //Make sure the installed list is sorted before we search it.
                plInstalled.Sort();

                foreach (Package uninstalled in plUnInstalled)
                {
                    if (uninstalled.Dependacies.Count == 0)
                    {
                        //No dependancies? Install
                        plInstalled.Add(uninstalled);
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }

                    //Check if all dependancies are installed
                    foreach(string depend in uninstalled.Dependacies)
                    {
                        allDepend = false;
                        //If the name of an installed package matches the name of a dependancy,
                        //Say that we might have a match!
                        if(plInstalled.BinarySearch(new Package(new[] { depend })) >= 0)
                        {
                            allDepend = true;
                        }
                        
                    }

                    if (allDepend)
                    {
                        plInstalled.Add(uninstalled);
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }
                }
            } while (install);
        }
        
    }
}
