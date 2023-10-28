namespace _03_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var finalBill = new Dictionary<string, decimal>();
            List<Product> products = new List<Product>();

            string inputLine = Console.ReadLine();

            while (inputLine != "buy")
            {
                string[] productInformation = inputLine.Split();
                string productName = productInformation[0];
                decimal productPrice = decimal.Parse(productInformation[1]);
                int productQuantity = int.Parse(productInformation[2]);

                bool isFound = false;

                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name == productName)
                    {
                        products[i].Price = productPrice;
                        products[i].Quantity += productQuantity;

                        finalBill[productName] = products[i].Price * products[i].Quantity;

                        isFound = true;
                    }
                }
                
                if (!isFound)
                {
                    Product product = new Product(productName, productPrice, productQuantity);
                    products.Add(product);

                    finalBill.Add(productName, productPrice * productQuantity);
                }
                
                inputLine = Console.ReadLine();
            }

            foreach (var item in finalBill)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }

        public class Product
        {
            public Product(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public string Name { get; set; }  
            public decimal Price { get; set; }  
            public int Quantity { get; set; }  
        }
    }
}