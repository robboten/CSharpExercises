using System;
using System.Xml.Linq;

//inlämning fredag innan lunch

//questions 
//ska person instance finnas i main alls?
//hur isolera publica functioner i Person från main men ha kvar åtkomst i PersonHandler?
//ska man ha en tom constructor i person/personhandler trots att det inte ska gå att göra en instance utan namn?
//om vi ska ha Person som en abstract borde inte fälten då vara protected? Dessutom kan du ju inte ha kvar implementationerna som ligger kvar i person


//Svar frågor - för övriga se löpande kommentarer
//3.4 - 10. S: Animals är vad alla ärver av så den.
//3.4 - 13.F: Förklara vad det är som händer. S: Förstår inte frågan...
//3.4 - 16,17:  Nej för att hund är ett animal men animal är inte en hund

//OBS språkkaos deluxe i detta projekt... 

namespace Ovning3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3.1 - just nu ger den exception på alla samtidigt som gör att om en är fel så skrivs inget av de andra ut.
            try
            {
                Console.WriteLine("Övning: 3.1");
                PersonHandler personHandler = new PersonHandler("Adam", "Evasson");

                //with Person instance in main
                Console.WriteLine("Create Person and directly assign to main Person property");
                //below assignment overwrites the personHandler person name since there is no empty constructor
                Person person = personHandler.CreatePerson("Eva", "Adamsdotter");
                //now personhandler doesn't set stuff but person directly - not how we should do it
                Console.Write(person.Fname+" ");
                Console.Write(person.Lname+" ");
                person.Age = 1;
                Console.Write(person.Age+" år\n");
                Console.WriteLine();

                //mixed - returns person from PersonHandler but assigns it to Person in main (guessing this is how it's meant to be in the excerise)
                Console.WriteLine("PersonHandler instanced Person assigned to main Person property");
                Person person2 = personHandler.GetPersonHandler();
                Console.WriteLine(personHandler.GetFname(person2));
                Console.WriteLine(personHandler.GetLname(person2));
                personHandler.SetAge(person2, 7);
                Console.WriteLine(personHandler.GetAge(person2)+" år");
                Console.WriteLine();

                PersonHandler personHandler2 = new PersonHandler("Evam", "Edamsson");
                //without Person instance in main - isolates more than the mixed version, but let PersonHandler keep track of person which may be weird
                Console.WriteLine("PersonHandler instanced Person");
                Console.WriteLine(personHandler2.GetFname());
                Console.WriteLine(personHandler2.GetLname());
                personHandler2.SetAge(8);
                Console.WriteLine(personHandler2.GetAge() + " år");
                Console.WriteLine();
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Övning: 3.2");
            //3.2
            TextInputError textInputError = new();
            NumericInputError numericInputError = new();
            EmptyInputError emptyInputError = new();
            FloatInputError floatInputError = new();
            IntInputError intInputError = new();
            RangeInputError rangeInputError = new();
            var UserErrorList = new List<UserError> { textInputError, numericInputError, emptyInputError, floatInputError, intInputError, rangeInputError };
            foreach (UserError error in UserErrorList)
            {
                Console.WriteLine(error.UEMessage());
            }

            //3.3-3.4
            Console.WriteLine();
            Console.WriteLine("Övning: 3.4");
            Horse horse1 = new("Brunte", 12, 980.0, "Brun");
            Dog dog1 = new("Fido", 2, 35.0, true);
            Hedgehog hedgehog1 = new("Ulrika", 1, 0.12, true);
            Worm worm1 = new("Andres", 1, 0.001, true); //tveksamt om en mask blir över 1 år men ok.
            Bird bird1 = new("Jessica", 2, 0.2, "Böjd");
            Wolf wolf1 = new("Ove", 4, 35.0, "Hyggen och ungskog");
            Wolfman wolfman1 = new("Wolverine", 190, 136.0, "US");
            Dog dog2 = new("Karo", 2, 12.0, false);
            Dog dog3 = new("Helmi", 4, 10.0, true);
            Dog dog4 = new("Bengt", 5, 8.0, false);

            List<Animal> animals = new() { horse1, dog1, hedgehog1, worm1, bird1, wolf1, wolfman1, dog2, dog3, dog4 };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Stats());
                if (animal is IPerson)
                {
                    Wolfman temp = (Wolfman)animal;
                    temp.Talk($"Says \"Hello there.. and {animal.DoSound()}\"\n\n");
                }
                else if(animal is Dog)
                { 
                    Dog temp = (Dog)animal;
                    Console.WriteLine(temp.trams());
                }
                else
                {
                    Console.WriteLine($"Says: \"{animal.DoSound()}\"\n");
                }

            }

            //List<Dog> dogs2 = new List<Dog> { dog1, dog2, dog3, dog4,horse1 }; //inte rätt ärvd klass

        }
    }
}