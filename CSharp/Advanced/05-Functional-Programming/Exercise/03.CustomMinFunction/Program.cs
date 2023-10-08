namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            Func<List<int>, int> minNumber = x =>
            {
                int minNumber = int.MaxValue;

                foreach (int number in numbers)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            Console.WriteLine(minNumber(numbers));
        }
    }
}