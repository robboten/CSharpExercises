using System;
using System.Drawing;

namespace Ovning3
{
    internal interface IPerson
    {
        void Talk(string words);
    }

    //if all animals needs a new common property add it to Animal class
    internal abstract class Animal
    {
        public string Name { get; }
        public int Age { get; }
        public double Weight { get; }

        public Animal(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }
        public abstract string DoSound();
        public virtual string Stats() //instruktionen säger inte att det ska vara en abstrakt, men annars kan man väl inte override?
        {
            return $"Djur: {this.GetType().Name}, Namn: {Name}, Ålder: {Age} år, Vikt:{Weight} kg, ";
        }
    }

    internal class Horse : Animal
    {
        public Horse(string name, int age, double weight, string color) : base(name,  age, weight)
        {
            Color = color;
        }
        string Color;
        public override string DoSound()
        {
            return "Gnägg";
        }
        public override string Stats()
        {
            return base.Stats()+$"Färg:{Color}";
        }
    }

    internal class Dog : Animal
    {
        public Dog(string name, int age, double weight, bool hasBone) : base(name, age, weight)
        {
            this.hasBone = hasBone;
        }
        bool hasBone;
        public override string DoSound()
        {
            return "Voff";
        }
        public string trams()
        {
            return "nonsens";
        }
        public override string Stats()
        {
            return base.Stats() + $"Har ett ben att tugga på:{hasBone}";
        }
    }
    internal class Hedgehog : Animal
    {
        public Hedgehog(string name, int age, double weight, bool likesMilk) : base(name, age, weight)
        {
            this.likesMilk = likesMilk;
        }
        bool likesMilk;
        public override string DoSound()
        {
            return "Grymt";
        }
        public override string Stats()
        {
            return base.Stats() + $"Gillar mjölk:{likesMilk}";
        }
    }
    internal class Worm : Animal
    {
        public Worm(string name, int age, double weight, bool likesWet) : base(name, age, weight)
        {
            LikesWet = likesWet;
        }
        bool LikesWet;

        public override string DoSound()
        {
            return "...";
        }
        public override string Stats()
        {
            return base.Stats() + $"Gillar regn:{LikesWet}";
        }
    }

    //if all birds needs a new common property add it to Bird class
    internal class Bird : Animal
    {
        public Bird(string name, int age, double weight, string beakType) : base(name, age, weight)
        {
            this.beakType = beakType;
        }
        string beakType;

        public override string DoSound()
        {
            return "Kvitt kvitt";
        }
        public override string Stats()
        {
            return base.Stats() + $"Näbbtyp:{beakType}";
        }
    }

    internal class Pelican : Bird
    {
        public Pelican(string name, int age, double weight, string beakType, int fishesCaught) : base(name, age, weight, beakType)
        {
            FishesCaught = fishesCaught;
        }
        public int FishesCaught { get; set; }
        public override string Stats()
        {
            return base.Stats();
        }
    }
    internal class Flamingo : Bird
    {
        public Flamingo(string name, int age, double weight, string beakType, bool standingOnOneLeg) : base(name, age, weight, beakType)
        {
            StandingOnOneLeg = standingOnOneLeg;
        }
        public bool StandingOnOneLeg { get; set; }
        public override string Stats()
        {
            return base.Stats();
        }
    }
    internal class Swan : Bird
    {
        public Swan(string name, int age, double weight, string beakType, int nrChildren) : base(name, age, weight, beakType)
        {
            NrChildren = nrChildren;
        }
        public int NrChildren { get; set; }
        public override string Stats()
        {
            return base.Stats();
        }
    }
    internal class Wolf : Animal
    {
        public Wolf(string name, int age, double weight, string habitat) : base(name,age, weight)
        {
            Habitat = habitat;
        }
        public string Habitat { get; set; }
        public override string DoSound()
        {
            return "Yl";
        }
        public override string Stats()
        {
            return base.Stats() + $"Habitat:{Habitat}";
        }
    }

    internal class Wolfman: Wolf, IPerson
    {
        public Wolfman(string name, int age, double weight, string habitat) : base(name, age, weight, habitat)
        {
        }
        public void Talk(string words)
        {
            Console.Write(words);
        }
        public override string Stats()
        {
            return base.Stats();
        }
    }




}


