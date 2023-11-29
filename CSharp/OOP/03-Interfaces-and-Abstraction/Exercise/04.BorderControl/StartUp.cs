using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> inhabitants = new();

            string entry;

            IIdentifiable inhabitant;

            while ((entry = Console.ReadLine()) != "End")
            {
                string[] entryData = entry.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (entryData.Length == 2)
                {
                    string model = entryData[0];
                    string id = entryData[1];

                    inhabitant = new Robot(model, id);
                }
                else
                {
                    string name = entryData[0];
                    int age = int.Parse(entryData[1]);
                    string id = entryData[2];

                    inhabitant = new Citizen(name, age, id);
                }

                inhabitants.Add(inhabitant);
            }

            string lastDigitsOfFakeIds = Console.ReadLine();

            foreach (var idHolder in inhabitants)
            {
                if (idHolder.CheckId(lastDigitsOfFakeIds))
                {
                    Console.WriteLine(idHolder.Id);
                }
            }
        }
    }
}