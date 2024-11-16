using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorOchProperties
{
        //Skapa först en person som ska vara ritning för dina 5 personer
        public class Person
        {
            //Skapa properties
            public int Strength { get; set; }
            public string Name { get; set; }



            //Skapa en Constructor
            public Person(int strength, string name)
            {
                Strength = strength;
                Name = name;
            }


        //SKapa metoden ToString för att objektets namn ocg styrka ska synas när du skriver ut de. Annars kommer bara namespacet för klassen att stå istället
        //Detta är redan en inbyggd metod som finns automatisk i Csharp men du ska ändra den.
        //Finns mer info om ToString metoden i tillhörnde dokument
        public override string ToString()
        {
            return Name + ", med styrka " + Strength;
        }










        public static List<Person> MakePersons()
        {

            //Skapa en lista med 5 personer egentligen skrivs det List<Person> persons = new List<Person>
            //men eftersom att vi ska returner blir det på följande sätt
            return new List<Person>
            {
            new Person(Random.Shared.Next(1, 20), "Tuncay"),
            new Person(Random.Shared.Next(1, 20), "Ilayda"),
            new Person(Random.Shared.Next(1, 20), "Emine"),
            new Person(Random.Shared.Next(1, 20), "Nirar"),
            new Person(Random.Shared.Next(1, 20), "Nida")
            };

        }






        //Skapa Berget personerna går upp från
        public static void ClimbMountain()
        {
            //Ropa på metoden som skapar dina personer och spara listan
            List<Person> persons = MakePersons();

            //Döp första personen till king för att senare låta resten av personerna utmana honom
            Person king = persons[0];
            //Starta historian med att king klättrar på berget och resterande personer försöker ta king rollen
            //Du behöver ej skriva in king + ", med styka " + king.Strength. 
            //Detta eftersom du redan skrivit det i din ToString metod under din Construktor
            Console.WriteLine(king + " går upp för berget.");
            Console.WriteLine();




            //Genom en loop döp alla andra till challenger och låt de försöka ta kungens plats
            //Väldigt viktigt att loopen börjar från 1 för att kungen är ju 0
            for (int i = 1; i < persons.Count; i++)
            {
                Person challanger = persons[i]; //Du kan också sktiva var challanger = persons[i];


                //Fortsätt resterande historia i for loopen
                Console.WriteLine("Därefter kommer " + challanger);
                if (challanger.Strength < king.Strength)
                {
                    Console.WriteLine(challanger.Name + " är svagare och blir därför bortjagad av " + king.Name);
                }
                else
                {
                    Console.WriteLine(challanger.Name + " är starkare och tar över berget, nu väntar hen på nästa motståndare.");
                    king = challanger; //uppdatera kungen
                }
            }




            //Skriv ut vem som vann
            Console.WriteLine();
            Console.WriteLine("Sist kvar är " + king.Name + ", därav herre på täppen.");


        }
    }
      
}

