using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorOchProperties
{
    internal class Skogen
    {
        //Skapa en klass som heter animal
        public class Animal
        {
            //Skapa properties
            public string Name { get; set; }
            public bool Nocturnal { get; set; } = true;
            public string Movement { get; set; }


            //Skapa en construktor
            public Animal(string name, bool nocturnal, string movement)
            {
                Name = name;
                Nocturnal = nocturnal;
                Movement = movement;
            }
        }






        //Skapa en metod som skapar insatser av djuren men också visar egenskaperna
        public static void ShowAnimals()
        {
            //Skapa en lista och lägg djuren i
            List<Animal> forrest = new List<Animal>
            {
                new Animal("Vargen", true, "springer fram"),
                new Animal("Fladdermusen", true, "flyger fram"),
                new Animal("Delfinen", false, "simmar fram"),
                new Animal("Örnen", false, "flyger fram"),
                new Animal("Hästen", false, "galloperar fram")
            };





            //Fråga användaren om natt och dag knapp
            Console.WriteLine("Tryck på N för att aktivera nattknappen.");
            Console.WriteLine("Tryck på D för att aktivera dagknappen.");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();


            //Spara användarens tangentknapp
            ConsoleKeyInfo input = Console.ReadKey(true); //Lägg in true så att knappen användaren trycker in inte syns

            //Använd if sats för att hantera de olika tangenttryckningarna
            if(input.Key == ConsoleKey.N)
            {
                Console.WriteLine("DET ÄR NATT");
                //Gå igenom varje djur i listan
                foreach(Animal animal in forrest) //Du går igenom varje ny insats animal i Animal klassen i själva listan forrest
                {
                    if(animal.Nocturnal == true) //om djuret är nattdjur{
                    {
                        Console.WriteLine(animal.Name + " " + animal.Movement);
                    }
                    else
                    {
                        Console.WriteLine(animal.Name + " sover.");
                    }
                }
            }
            else if(input.Key == ConsoleKey.D)
            {
                Console.WriteLine("DET ÄR DAG");
                foreach(Animal animal in forrest)
                {
                    if(animal.Nocturnal != true)
                    {
                        Console.WriteLine(animal.Name + " " + animal.Movement);
                    }
                    else
                    {
                        Console.WriteLine(animal.Name + " sover.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning. Tryck på knappen N eller D.");
            }
        }
    }
}
