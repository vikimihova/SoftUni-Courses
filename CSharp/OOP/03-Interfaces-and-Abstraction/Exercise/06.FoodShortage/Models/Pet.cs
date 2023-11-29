
using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthdate = birthday;
        }

        public string Name { get; init; }
        public string Birthdate { get; init; }

        public bool ConfirmBirthYear(string year)
        {
            return Birthdate.EndsWith(year);
        }
    }
}
