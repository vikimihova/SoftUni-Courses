using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models
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
