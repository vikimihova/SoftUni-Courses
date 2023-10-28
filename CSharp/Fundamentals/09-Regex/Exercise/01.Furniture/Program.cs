using System.Text.RegularExpressions;

namespace _01_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"^>>(?<product>[A-Z]{1,3}[a-z]*)<<(?<price>[0-9]+\.{0,1}[0-9]*)!(?<quantity>[0-9]+)\b";

            Regex regex = new Regex(pattern);

            List<string> validProducts = new List<string>();

            double totalCost = 0;            

            while (input != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);

                    validProducts.Add(match.Groups["product"].Value);                   

                    double price = double.Parse(match.Groups["price"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);

                    double cost = price * quantity;
                    totalCost += cost;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");

            foreach (var item in validProducts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalCost:f2}");
        }
    }
}