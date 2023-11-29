using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthable, IPerson, IBuyer
    {
        private const int InitialAmountFood = 0;

        public Citizen(string name, int age, string id, string birthday) 
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthday;
            Food = InitialAmountFood;
        }

        public string Name { get; init; }
        public string Birthdate { get; init; }
        public int Age { get; private set; }
        public string Id { get; init; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }

        public bool CheckId(string lastIdDigits)
        {
            return Id.EndsWith(lastIdDigits);
        }

        public bool ConfirmBirthYear(string year)
        {
            return Birthdate.EndsWith(year);
        }
    }
}
