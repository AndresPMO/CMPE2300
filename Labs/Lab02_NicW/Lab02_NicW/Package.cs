/*
Author: Nicholas Wasylyshyn 
Project: Lab 02
Class: A02
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_NicW
{
    class Package : IComparable
    {
        //Instance Variables

        //The name of the package
        public string Name { get; set; }
        //The dependancies of the package
        //and a get for the elements of them. Copy only, not master list
        private List<string> dependancy;
        public List<string> Dependacies { get { return new List<string>(dependancy); } }

        //Instance Constructor
        public Package(string[] packages)
        {
            //First element of string[] input is the Package Name
            Name = packages[0];
            dependancy = new List<string>();
            //All others are the dependancies of that Package
            for(int i = 1; i < packages.Length; i++)
            {
                //No duplicates
                if(!dependancy.Contains(packages[i]))
                    dependancy.Add(packages[i]);
            }
        }

        //Overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Package)) return false; //input is not Package, or null
            Package temp = (Package)obj;
            return this.Name.Equals(temp.Name);
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public override string ToString()
        {
            //Output all the elements of the dependancy list seperated by a comma
            string output = "";
            this.dependancy.ForEach(element => output += (element + ", "));
            return output;
        }

        //Comparisons
        public int CompareTo(object obj)
        {
            if (!(obj is Package)) throw new ArgumentException("Input is not Package, or null"); //Bad input

            Package temp = (Package)obj;
            return this.Name.CompareTo(temp.Name);
        }

        static public int CompareNameDepCount(Package arg1, Package arg2)
        {
            //If Name is the same, compare by dependancy count
            if (arg1.Name.Equals(arg2.Name))
            {
                return arg1.Dependacies.Count.CompareTo(arg2.Dependacies.Count);
            }
            else
            {
                return arg1.Name.CompareTo(arg2.Name);
            }
        }

        static public int CompareDepCountName(Package arg1, Package arg2)
        {
            //If Name is the same, compare by dependancy count
            if (arg1.Dependacies.Count == arg2.Dependacies.Count)
            {
                return arg1.Name.CompareTo(arg2.Name);
            }
            else
            {
                return arg1.Dependacies.Count.CompareTo(arg2.Dependacies.Count);
            }
        }

        //Methods
        public void MergePackage(Package input)
        {
            //Packages need the same name
            if (!this.Name.Equals(input.Name)) throw new ArgumentException("Cannot merge package, not same package name.");

            //Add all of the input dependancies to the invoking object.
            //Only add dependancies that are not already part of the invoking object's dependancies.
            this.dependancy = this.dependancy.Union(input.dependancy).ToList();

            //Lambda style of above
            //this.dependancy.AddRange(input.dependancy.FindAll(inp => !this.dependancy.Contains(inp)));
        }
    }
}
