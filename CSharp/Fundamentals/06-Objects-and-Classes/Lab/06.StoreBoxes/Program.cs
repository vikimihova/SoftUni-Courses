namespace _06_StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] boxProperties = input.Split().ToArray();

                string serialNumber = boxProperties[0];
                string itemName = boxProperties[1];
                int itemQuantity = int.Parse(boxProperties[2]);
                decimal itemPrice = decimal.Parse(boxProperties[3]);

                Item item = new Item(itemName, itemPrice);

                boxes.Add(new Box(serialNumber, item, itemQuantity));

                input = Console.ReadLine();
            }

            foreach (Box box in boxes.OrderByDescending(x => x.BoxPrice))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");                
            }
        }

        public class Item
        {
            public Item(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public class Box
        {
            public Box(string serialNumber, Item item, int itemQuantity)
            {
                SerialNumber = serialNumber;
                Item = item;
                ItemQuantity = itemQuantity;                
            }
          
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public decimal BoxPrice => ItemQuantity * Item.Price;                   
        }
    }
}