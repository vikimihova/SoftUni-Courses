using _05.BirthdayCelebrations.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthday) 
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthday;
        }

        public string Name { get; init; }
        public string Birthdate { get; init; }
        public int Age { get; private set; }
        public string Id { get; init; }


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
