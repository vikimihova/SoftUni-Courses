namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parser = x => double.Parse(x);

            List<double> originalPrices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser).ToList();

            Func<double, double> addVAT = x => x * 1.2;

            List<double> newPrices = CalculateVATPrices(originalPrices, addVAT);

            Action<double> print = x => Console.WriteLine($"{x:f2}");

            newPrices.ForEach(print);

        }

        static List<double> CalculateVATPrices(List<double> prices, Func<double, double> addVAT)
        {
            for (int i = 0; i < prices.Count; i++)
            {
                prices[i] = addVAT(prices[i]);
            }

            return prices;
        }
    }
}