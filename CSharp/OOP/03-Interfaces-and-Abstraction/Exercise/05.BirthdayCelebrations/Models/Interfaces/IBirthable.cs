namespace _05.BirthdayCelebrations.Models.Interfaces
{
    public interface IBirthable
    {
        string Name { get; }
        string Birthdate { get; }

        bool ConfirmBirthYear(string year);
    }
}
