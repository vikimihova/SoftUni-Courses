using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const string ArgumentExceptionName = "Pizza name should be between 1 and 15 symbols.";
        private const string ArgumentExceptionToppingsCount = "Number of toppings should be in range [0..10].";

        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value) ||
                    value.Length > 15)
                {
                    throw new ArgumentException(ArgumentExceptionName);
                }

                name = value;
            }
        }
        public Dough Dough { get; set; }
        public double TotalCalories
        {
            get
            {
                return Dough.Calories + toppings.Sum(x => x.Calories);
            }
        }


        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException(ArgumentExceptionToppingsCount);
            }

            toppings.Add(topping);
        }
        public override string ToString() 
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
