using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> inhabitants = new();

            int numberOfEntries = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] entryData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = entryData[0];

                if (entryData.Length == 4 && !inhabitants.Any(x => x.Name == name))
                {
                    int age = int.Parse(entryData[1]);
                    string id = entryData[2];
                    string birthday = entryData[3];

                    IBuyer inhabitant = new Citizen(name, age, id, birthday);
                    inhabitants.Add(inhabitant);
                }
                else if (entryData.Length == 3 && !inhabitants.Any(x => x.Name == name))
                {
                    int age = int.Parse(entryData[1]);
                    string group  = entryData[2];

                    IBuyer inhabitant = new Rebel(name, age, group);
                    inhabitants.Add(inhabitant);
                }
            }

            string buyerName;

            while ((buyerName = Console.ReadLine()) != "End")
            {
                IBuyer buyer = inhabitants.FirstOrDefault(x => x.Name == buyerName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(inhabitants.Sum(x => x.Food));
        }
    }
}