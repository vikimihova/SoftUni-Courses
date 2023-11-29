
namespace _05.BirthdayCelebrations.Models.Interfaces
{
    public interface IIdentifiable
    {
        string Id { get; init; }
        bool CheckId(string lastIdDigits);
    }
}
