namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    chemicalElements.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}