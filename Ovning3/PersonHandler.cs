using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning3
{

    internal class PersonHandler
    {
        //if the isolation from the Person class should be complete, shouldn't it be like this instead?
        Person person;

        //making an empty constructor is pointless since you still have to provide names for the person constructor
        //public PersonHandler()
        //{
        //    person = new(fname, lname);
        //}
        public PersonHandler(string fname, string lname)
        {
            person = new(fname, lname);
        }
        public PersonHandler(string fname, string lname, int age, double height, double weight)
        {
            person = new(fname, lname, age, height, weight);
        }

        public string GetLname()
        {
            return person.Lname;
        }
        public string GetFname()
        {
            return person.Fname;
        }

        public void SetAge(int age)
        {
            person.Age = age;
        }
        public int GetAge()
        {
            return person.Age;
        }
        //not making all of these in both versions so the above are examples of the more isolated approach

        //mixed - returns person to main but leaves instance of it capsulated
        public Person GetPersonHandler()
        {
            return person;
        }

        //these still needs a Person instance in main right? If so it can use the public methods from Person anyway, so why do this?
        public Person CreatePerson(string fname, string lname)
        {
            Person person = new(fname, lname);
            return person;
        }
        public Person CreatePerson(string fname, string lname, int age, double height, double weight)
        {
            //not sure if we are meant to use constructor with the lot or not
            //Person person = new Person(fname,lname,age,height,weight);
            Person person = new(fname, lname);
            person.Age = age;
            person.Weight = weight;
            person.Height = height;

            return person;
        }
        public void SetFname(Person pers, string fname)
        {
            pers.Fname = fname;
        }
        public void SetLname(Person pers, string lname)
        {
            pers.Lname = lname;
        }
        public void SetAge(Person pers, int age)
        {
            pers.Age = age;
        }
        public void SetWeight(Person pers, double weight)
        {
            pers.Weight = weight;
        }
        public void SetHeight(Person pers, double height)
        {
            pers.Height = height;
        }
        public void SetAll(Person pers, string fname, string lname, int age, double weight, double height)
        {
            pers.Fname = fname;
            pers.Lname = lname;
            pers.Age = age;
            pers.Weight = weight;
            pers.Height = height;
        }
        public string GetFname(Person pers)
        {
            return pers.Fname;
        }
        public string GetLname(Person pers)
        {
            return pers.Lname;
        }
        public int GetAge(Person pers)
        {
            return pers.Age;
        }
        public double GetWeight(Person pers)
        {
            return pers.Weight;
        }
        public double GetHeight(Person pers)
        {
            return pers.Height;
        }
        public (string, string, int, double, double) GetAll(Person pers)
        {
            return (pers.Fname, pers.Lname, pers.Age, pers.Weight, pers.Height);
        }

    }
}
