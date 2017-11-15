/*
Author: Nicholas Wasylyshyn 
Project: Lab 02 - Package Installer
Class: A02
*/

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
        //This type determines the type of sort to call. Used in the Analyse button click function
        private enum SortType { eRawList, eLibraryList, eSortedList }

        //The three lists for all three types of view
        List<Package> plLoaded = new List<Package>();       //packages that have been loaded from a file
        List<Package> plInstalled = new List<Package>();    //packages that are able to be installed, must analyze before being populated
        List<Package> plUnInstalled = new List<Package>();  //packages that are not able to be installed, must analyze before being populated

        //Occurs when the form is first loaded
        //Pre-select default values for the combo boxes
        //We want the defaults to be: Raw list access and Loaded list view
        public Form1()
        {
            InitializeComponent();
            //Always have a selected index for the combo boxes
            UI_toolStripComboBox_Algorithm.SelectedIndex = 0;
            UI_toolStripComboBox_View.SelectedIndex = 0;
        }

        //Occurs when the form needs to be rendered
        //Will resize the dependancy column to fit the width of the form
        private void Form1_Resize(object sender, EventArgs e)
        {
            UI_listView_Packages.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //Occurs when the load button is clicked
        //This will clear the loaded package list,
        //read in data from a file provided by teacher,
        //add it to the loaded list as packages.
        private void UI_toolStripButton_Load_Click(object sender, EventArgs e)
        {
            //Make sure the user opened a file
            if(UI_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Want all new data
                plLoaded.Clear();
                //Can't have anything installed or uninstalled if we loaded a new file
                plInstalled.Clear();
                plUnInstalled.Clear();

                //Make places to store all the data temporarily
                string[] allLines = System.IO.File.ReadAllLines(UI_openFileDialog.FileName);
                //Each line of the file split into individual strings
                string[] packInput;
                //A temporary package to be added to the loaded list
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

        //Called when the analyze button is clicked
        //This will check if we have anything to analyze (safety check),
        //then it will create a stopwatch to time how long our function call takes.
        //Our function call is determined by the Algorithm combobox and an enumerated type.
        //Displays the time it took for the function in the form title and displays the installed list.
        private void UI_toolStripButton_Analyze_Click(object sender, EventArgs e)
        {
            //Make sure there is something to analyze
            if(plLoaded.Count > 0)
            {
                //Make uninstalled a copy of loaded as nothing can be installed yet
                plUnInstalled = new List<Package>(plLoaded);
                plInstalled = new List<Package>();
            }

            //Stopwatch to see how long each sort takes
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //Figure out the algorithm to use
            SortType sort = (SortType)UI_toolStripComboBox_Algorithm.SelectedIndex;
            //Start our timer at 0
            stopwatch.Restart();
            switch (sort)
            {
                case SortType.eRawList:
                    RawInstall();       //Raw looping install
                    break;
                case SortType.eLibraryList:
                    LibraryInstall();   //Library function install
                    break;
                case SortType.eSortedList:
                    SortedInstall();    //Binary searching install
                    break;
            }
            //Stop the watch, function has completed
            stopwatch.Stop();
            //Display the time on the form title
            Text = stopwatch.Elapsed.TotalSeconds.ToString("F4");

            //Show the installed selection
            UI_toolStripComboBox_View.SelectedIndex = 1;
            //Display the analysed data (installed list)
            ShowSelectedLoad();
        }

        //Called when the view combo box has been changed
        //Calls a function to view the selected list
        private void UI_toolStripComboBox_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedLoad();
        }

        //Called when one of the list view column headers has been clicked
        //Several options are available:
        //Column (Name):
        //  Loaded: sorts the loaded list by name, then dependancy count
        //  Installed: sorts the installed list by name, then dependancy count
        //  Uninstalled: sorts the uninstalled list by name, then dependancy count
        //Column (Dependancy):
        //  Loaded: sorts the loaded list by dependancy count, then name
        //  Installed: sorts the installed list by dependancy count, then name
        //  Uninstalled: sorts the uninstalled list by dependancy count, then name
        private void UI_listView_Packages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Cleaning up the if statements would require a delegate. (reference the sort function)
            //Opted not to make more efficient in effort to save time coding
            if (e.Column == 0)
            {
                //Sort the selected list by name, then dependancy count
                if (UI_toolStripComboBox_View.SelectedIndex == 0)
                {
                    //Sorts the loaded list and shows it
                    plLoaded.Sort(Package.CompareNameDepCount);
                }
                else if (UI_toolStripComboBox_View.SelectedIndex == 1)
                {
                    //sorts the installed list and shows it
                    plInstalled.Sort(Package.CompareNameDepCount);
                }
                else
                {
                    //sorts the uninstalled list and shows it
                    plUnInstalled.Sort(Package.CompareNameDepCount);
                }
                ShowSelectedLoad();
            }
            else if (e.Column == 1)
            {
                //Sort the selected list by dependancy count, then name
                if (UI_toolStripComboBox_View.SelectedIndex == 0)
                {
                    //Sorts the loaded list and shows it
                    plLoaded.Sort(Package.CompareDepCountName);
                }
                else if (UI_toolStripComboBox_View.SelectedIndex == 1)
                {
                    //sorts the installed list and shows it
                    plInstalled.Sort(Package.CompareDepCountName);
                }
                else
                {
                    //sorts the uninstalled list and shows it
                    plUnInstalled.Sort(Package.CompareDepCountName);
                }
                ShowSelectedLoad();
            }
        }

        /// <summary>
        /// ShowSelectedLoad - This function is what enables the listview to display our selected list.
        /// </summary>
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
                    reference = plLoaded; //Reference the loaded list
                    break;
                case 1:
                    reference = plInstalled; //Reference the installed list
                    break;
                case 2:
                    reference = plUnInstalled; //Reference the uninstalled list
                    break;
                default:
                    reference = null; //Reference nothing (Shouldn't be used, leave for safety)
                    break;
            }
            
            //Go through every package in the referenced list
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

        /// <summary>
        /// RawInstall - (Technically not to spec, completed before spec change)
        /// This function will use raw loops to check if a package is installable and install it if true.
        /// </summary>
        private void RawInstall()
        {
            //bool to see if something was installed (looping condition)
            bool install = false;

            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;
                //Go through all the uninstalled packages
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
                        //Go back to the start of our foreach
                        break;
                    }


                    //vvvTechnically, the to spec part of the function

                    //Used to determine if we can install a package
                    bool allDepend = false;
                    //for every uninstalled package, look through all the dependant packages
                    foreach(string depend in uninstalled.Dependacies)
                    {
                        //assume we can't install the package
                        allDepend = false;
                        //for all the installed packages, check the names of the uninstalled package
                        foreach (Package ins in plInstalled)
                        {
                            if(depend != ins.Name)
                            {
                                //Haven't found it.
                                allDepend = false;
                            }
                            else
                            {
                                //Did find it installed! Don't need to search for this dependancy anymore
                                allDepend = true;
                                break;
                            }
                        }

                        //If we got a false, can't install this package. Don't keep checking stuff.
                        if (!allDepend)
                        {
                            break;
                        }
                    }

                    //^^^Technically, the to spec part of the function


                    //We can install it!
                    if (allDepend)
                    {
                        //Say it can be installed
                        plInstalled.Add(uninstalled);
                        //Keep looping since we installed something
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        //Go back to the start of our foreach
                        break;
                    }
                }
            } while (install);
        }

        /// <summary>
        /// LibraryInstall - (Technically not to spec, completed before spec change)
        /// This function will use lambdas and library functions to check if a package is installable and install if true.
        /// </summary>
        private void LibraryInstall()
        {
            //bool to see if something was installed
            bool install = false;
            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;
                //Go through all the uninstalled packages
                foreach (Package uninstalled in plUnInstalled)
                {
                    //No dependancies? Install
                    if (uninstalled.Dependacies.Count == 0)
                    {
                        //No dependancies? Install
                        plInstalled.Add(uninstalled);
                        //Flag an install
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }
                    //All of the dependancies have been installed? Install
                    else if (uninstalled.Dependacies.TrueForAll(depend => plInstalled.Contains(new Package(new[] { depend })))) //The if condition is the to spec portion of this function
                    {
                        //Go through every dependancy, check if it is contained in the installed list.
                        plInstalled.Add(uninstalled);
                        //Flag an install
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }
                }
            } while (install);
        }

        /// <summary>
        /// SortedInstall - (Technically not to spec, completed before spec change)
        /// This function will use lambdas and a binary search function to check if a package is installable and install if true.
        /// </summary>
        private void SortedInstall()
        {
            //bool to see if something was installed
            bool install = false;
            //Keep installing until you don't install anything else
            do
            {
                //Don't know if anything has been installed yet
                install = false;

                //Make sure the installed list is sorted before we search it.
                plInstalled.Sort();
                //Go through all the uninstalled packages
                foreach (Package uninstalled in plUnInstalled)
                {
                    //No dependancies? Install
                    if (uninstalled.Dependacies.Count == 0)
                    {
                        //Add it to the install list and flag an install
                        plInstalled.Add(uninstalled);
                        install = true;
                        //Remove from the uninstalled list
                        plUnInstalled.Remove(uninstalled);
                        break;
                    }
                    //All of the dependancies have been installed? Install
                    else if (uninstalled.Dependacies.TrueForAll(depend => plInstalled.BinarySearch(new Package(new[] { depend })) >= 0)) //The if condition is the to spec portion of this function
                    {
                        //Add it to the install list and flag an install
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
