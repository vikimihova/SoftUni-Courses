
namespace Animals
{
    public class Kitten : Cat
    {
        private const string KittenGender = "Female";

        public Kitten(string name, int age, string gender) : base(name, age, KittenGender)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
