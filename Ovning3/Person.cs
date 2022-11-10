using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning3
{
    internal class Person
    {
        private string lName;
        private string fName;
        private int age;
        private double height;
        private double weight;

        private readonly int maxFNameChars = 10;
        private readonly int minFNameChars = 2;
        private readonly int maxLNameChars = 15;
        private readonly int minLNameChars = 3;

        //all of these are quite weird when they are accessible right of from main, but how else to reach them from PersonHandler?
        public Person(string fName, string lName, int age, double height, double weight)
        {
            this.lName = lName;
            this.fName = fName;
            Age = age;
            Height = height;
            Weight = weight;
        }
        public Person(string fName, string lName)
        {
            Fname = fName;
            Lname = lName;
        }

        //FName är obligatorisk och får inte vara mindre än 2 tecken eller längre än 10 tecken.
        public string Fname
        {
            get { return fName; }
            set
            {
                if (value != null && value.Length >= minFNameChars && value.Length <= maxFNameChars)
                {
                    fName = value;
                }
                else
                {
                    throw new ArgumentException($"Förnamn behöver vara mellan {minFNameChars} och {maxFNameChars} bokstäver långt");
                }
            }
        }

        //LName är obligatorisk och får inte vara mindre än 3 tecken eller större än 15 tecken
        public string Lname
        {
            get { return lName; }
            set { 
                if (value != null && value.Length>= minLNameChars && value.Length <= maxLNameChars)
                {
                    lName = value;
                }
                else
                {
                    throw new ArgumentException($"Efternamn behöver vara mellan {minLNameChars } och {maxLNameChars} bokstäver långt");
                }
            }
        }

        //Age kan bara tilldelas ett värde större än 0
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    //throw new ArgumentException("Ålder behöver vara mer än 0 år");
                    throw new ArgumentOutOfRangeException("age", "Ålder behöver vara mer än 0 år");
                }
            }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
