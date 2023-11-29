
namespace _06.FoodShortage.Models.Interfaces
{
    public interface IIdentifiable
    {
        string Id { get; init; }
        bool CheckId(string lastIdDigits);
    }
}
