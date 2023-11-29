
using _05.BirthdayCelebrations.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models
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
