namespace _06.FoodShortage.Models.Interfaces
{
    public interface IBirthable
    {
        string Birthdate { get; init; }

        bool ConfirmBirthYear(string year);
    }
}
