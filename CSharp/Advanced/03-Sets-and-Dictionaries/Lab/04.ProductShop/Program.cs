namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shopProductPrices = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] inputContents = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string shop = inputContents[0];
                string product = inputContents[1];
                double price = double.Parse(inputContents[2]);

                if (shopProductPrices.ContainsKey(shop))
                {
                    shopProductPrices[shop].Add(product, price);
                }
                else
                {
                    shopProductPrices.Add(shop, new Dictionary<string, double>());
                    shopProductPrices[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var shop in shopProductPrices)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var (product, price) in shop.Value)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}