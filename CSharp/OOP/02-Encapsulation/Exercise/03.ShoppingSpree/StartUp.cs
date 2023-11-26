
namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new();
            Dictionary<string, Product> products = new();

            string[] arrayOfPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrayOfPeople.Length; i++)
            {
                string[] personInfo = arrayOfPeople[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string personName = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                try
                {
                    Person newPerson = new(personName, money);
                    people.Add(personName, newPerson);
                }
                catch (ArgumentException ex) 
                {
                    Console.WriteLine(ex.Message);
                    return;
                }                
            }

            string[] arrayOfProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrayOfProducts.Length; i++)
            {
                string[] productInfo = arrayOfProducts[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string productName = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                try
                {
                    Product newProduct = new(productName, cost);
                    products.Add(productName, newProduct);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }                
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string personName = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                string productName = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

                if (!people.ContainsKey(personName) || !products.ContainsKey(productName))
                {
                    continue;
                }

                if (people[personName].Money >= products[productName].Cost)
                {
                    people[personName].Money -= products[productName].Cost;
                    people[personName].BagOfProducts.Add(productName);

                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }           
            }

            foreach (var person in people)
            {
                if (person.Value.BagOfProducts.Count > 0)
                {
                    Console.Write($"{person.Key} - ");
                    Console.WriteLine(string.Join(", ", person.Value.BagOfProducts));
                }
                else
                {
                    Console.WriteLine($"{person.Key} - Nothing bought");
                }
            }
        }
    }
}