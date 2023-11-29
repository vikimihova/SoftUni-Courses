using _05.BirthdayCelebrations.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id) 
        {
            Model = model;
            Id = id;
        }

        public string Model { get; init; }
        public string Id { get; init; }

        public bool CheckId(string lastIdDigits)
        {
            return Id.EndsWith(lastIdDigits);
        }
    }
}
