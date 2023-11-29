
using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Rebel : IPerson, IBuyer
    {
        private const int InitialAmountFood = 0;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = InitialAmountFood;
        }

        public string Name { get; init; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
