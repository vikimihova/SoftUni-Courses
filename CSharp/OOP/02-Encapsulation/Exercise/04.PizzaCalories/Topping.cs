
namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private string type;
        private double weightInGrams;

        public Topping(string type, double grams)
        {
            Type = type;
            WeightInGrams = grams;
        }

        private string Type 
        {
            get
            {
                return type;
            }
            set
            {
                if (value.ToLower() != "meat" && 
                    value.ToLower() != "veggies" && 
                    value.ToLower() != "cheese" && 
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        private double WeightInGrams
        {
            get
            {
                return weightInGrams;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weightInGrams = value;
            }
        }
        public double Calories
        {
            get
            {
                return GetCalories(Type);
            }
        }

        private double GetCalories(string type)
        {
            double modifierByType = 1;

            switch (type.ToLower())
            {
                case "meat":
                    modifierByType = 1.2;
                    break;
                case "veggies":
                    modifierByType = 0.8;
                    break;
                case "cheese":
                    modifierByType = 1.1;
                    break;
                case "sauce":
                    modifierByType = 0.9;
                    break;
                default:
                    break;
            }

            return WeightInGrams * BaseCaloriesPerGram * modifierByType;
        }

    }
}
