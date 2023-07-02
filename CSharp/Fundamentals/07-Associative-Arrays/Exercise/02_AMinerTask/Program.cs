namespace _02_AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            var resourceQuantities = new Dictionary<string, int>();
            int counter = 1;

            string currentResource = string.Empty;

            while (inputLine != "stop")
            {
                if (counter % 2 != 0)
                {
                    if (!resourceQuantities.ContainsKey(inputLine))
                    {
                        resourceQuantities.Add(inputLine, 0);
                    }
                    
                    currentResource = inputLine;
                }
                else
                {
                    resourceQuantities[currentResource] += int.Parse(inputLine);
                }                

                inputLine = Console.ReadLine();
                counter++;
            }

            foreach (var item in resourceQuantities)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}