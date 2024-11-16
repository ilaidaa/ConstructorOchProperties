using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorOchProperties
{
    internal class KlubbEpidemin
    {
        //Skapa en person objekt
        public class Person
        {
            //Skapa properties
            public bool Infected { get; set; } = false;
            public int InfectedTime { get; set; } = -1; //InfectedTime representerar när en person blev smittad (t.ex., timme 0, 1, 2, osv.).
                                                        //Men om personen inte är smittad ännu, finns inget meningsfullt värde för InfectedTime.
                                                        //Därför sätts det till ett "defaultvärde" som indikerar att personen inte är smittad.
                                                        //-1 är ett vanligt val för att representera ett ogiltigt eller "icke tillämpligt" värde.
            public bool Immune { get; set; }



            //Skapa en constructor
            public Person(bool infected, int infectedTime, bool immune)
            {
                Infected = infected;
                InfectedTime = infectedTime;
                Immune = immune;
            }


            //Skapa en standardkonstruktor oxå, eftersom att du skapade en construktor ovan kommer inte Csharp göra det automatiskt åt dig längre
            //och eftersom att du vill skapa 20 personer och kanske sedan ändra deras egenskaper måste du skapa de utan att skicka in properties 
            //därav behövs standardconstruktorn. Mer om detta bifogat i tillhörande word dokument
            public Person()
            {

            }
        }






        //Skapa en metod som både skapar insatser av din klass Person och visar hur många som är immuna och smittade
        public static void ShowPersons()
        {
            //Skapa en lista. Eftersom att det är flera personer ska du inte skriva in de en och en som du brukar
            //Börja därför med en tom lista
            List<Person> club = new List<Person>();

            //Skapa en for loop som ska bestämma hur många som ska vara i listan
            for (int i = 0; i < 20; i++) //I detta fall ska det vara 20 pers
            {
                club.Add(new Person()); //lägg till i club listan genom Add, de nya personerna du skapat av Person klassen
            }



            //Ange nu att EN person är smittad.
            club[0].Infected = true;
            //Ange att personen blir smittad vid timme 0
            club[0].InfectedTime = 0;





            int time = 0; // Håller koll på tiden i timmar

            while (true) // En loop för att simulera tidens gång
            {
                // Visa status för alla personer
                int infectedCount = 0;
                int immuneCount = 0;

                foreach (Person person in club)
                {
                    if (person.Infected)
                    {
                        infectedCount++;
                    }
                    if (person.Immune)
                    {
                        immuneCount++;
                    }
                }




                // Visa nuvarande status
                Console.WriteLine($"Tid: {time} timmar");
                Console.WriteLine($"Smittade: {infectedCount}, Immuna: {immuneCount}");
                Console.WriteLine("------------------------------------");



                // Avsluta om alla är smittade eller immuna
                if (infectedCount == 0 && immuneCount == club.Count)
                {
                    Console.WriteLine("Alla är nu immuna eller smittade! Epidemin är över. Tryck enter för att avsluta");
                    Console.ReadKey();
                    break;
                }



                // Vänta på tangenttryck för att gå vidare en timme
                Console.WriteLine("Tryck på valfri tangent för att gå vidare en timme...");
                Console.WriteLine();
                Console.ReadKey();





                // Sprid smittan och uppdatera status för varje person
                List<Person> newlyInfected = new List<Person>();
                foreach (Person person in club)
                {
                    if (person.Infected)
                    {
                        // Kontrollera om personen ska bli immun.
                        // Tiden minus tiden som personen blev smittad ska vara mer än 5 eller 5 för att personen ska bli immun
                        if (time - person.InfectedTime >= 5)
                        {
                            person.Infected = false;
                            person.Immune = true;
                        }
                        else
                        {
                            // Varje smittad person smittar exakt en ny person
                            foreach (Person target in club)
                            {
                                if (!target.Infected && !target.Immune)
                                {
                                    newlyInfected.Add(target);
                                    break; // Endast en smitta per sjuk person
                                }
                            }
                        }
                    }
                }

                // Smitta de nya personerna
                foreach (Person person in newlyInfected)
                {
                    person.Infected = true;
                    person.InfectedTime = time; // Registrera när de blev smittade
                }

                // Öka tiden med en timme
                time++;
            }
        }
    }
}
