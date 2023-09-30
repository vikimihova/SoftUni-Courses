namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> valueCount = new Dictionary<double, int>();

            foreach (double value in values)
            {
                if (valueCount.ContainsKey(value))
                {
                    valueCount[value]++;
                }
                else
                {
                    valueCount.Add(value, 1);
                }
            }

            foreach (var kvp in valueCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}