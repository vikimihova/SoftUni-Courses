namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            List<int> sortedNumbers = numbers
                                      .OrderByDescending(x => x)
                                      .ToList();

            Console.WriteLine(string.Join(" ", sortedNumbers.Take(3)));
        }
    }
}