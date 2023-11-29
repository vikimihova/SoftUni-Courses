using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Interfaces;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> inhabitants = new();

            string entry;

            while ((entry = Console.ReadLine()) != "End")
            {
                string[] entryData = entry.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string inhabitantType = entryData[0];

                if (inhabitantType == "Citizen")
                {
                    string name = entryData[1];
                    int age = int.Parse(entryData[2]);
                    string id = entryData[3];
                    string birthday = entryData[4];

                    IBirthable inhabitant = new Citizen(name, age, id, birthday);
                    inhabitants.Add(inhabitant);
                }
                else if (inhabitantType == "Pet")
                {
                    string name = entryData[1];
                    string birthday = entryData[2];

                    IBirthable inhabitant = new Pet(name, birthday);
                    inhabitants.Add(inhabitant);
                }
            }

            string year = Console.ReadLine();

            //if (!inhabitants.Any(x => x.ConfirmBirthYear(year) == true))
            //{

            //}

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.ConfirmBirthYear(year))
                {
                    Console.WriteLine(inhabitant.Birthdate);
                }
            }
        }
    }
}