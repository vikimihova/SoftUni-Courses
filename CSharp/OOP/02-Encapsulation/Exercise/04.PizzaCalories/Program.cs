namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string order = Console.ReadLine();

                string[] doughTokens = Console.ReadLine().Split(" ");
                string doughType = doughTokens[1];
                string bakingTechnique = doughTokens[2];
                double grams = double.Parse(doughTokens[3]);

                Dough dough = new(doughType, bakingTechnique, grams);


                string[] orderTokens = order.Split(" ");
                string pizzaName = orderTokens[1];

                Pizza pizza = new(pizzaName, dough);

                string toppingsOrder;

                while ((toppingsOrder = Console.ReadLine()) != "END")
                {
                    string[] toppingProperties = toppingsOrder.Split(" ");

                    string toppingType = toppingProperties[1];
                    double toppingGrams = double.Parse(toppingProperties[2]);

                    Topping topping = new(toppingType, toppingGrams);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}