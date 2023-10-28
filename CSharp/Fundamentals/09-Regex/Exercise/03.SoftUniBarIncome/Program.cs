using System.Globalization;
using System.Text.RegularExpressions;

namespace _03_SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^\|\$\%\.]*<(?<product>\w+)>[^\|\$\%\.]*\|(?<count>\d+)\|[^\|\$\%\.\d]*(?<price>\d+\.*\d*)\$$";

            double totalIncome = 0;

            while (input != "end of shift")
            {
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    Console.WriteLine($"{customer}: {product} - {(count * price):f2}");

                    totalIncome += count * price;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}