using System;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            int divisionNumber = int.Parse(Console.ReadLine());

            Func<int, int, bool> DivisibleByNumberMatch = (x, y) => x % y == 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (DivisibleByNumberMatch(numbers[i], divisionNumber))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            Func<List<int>, List<int>> sequenceReverse = sequence =>
            {
                List<int> newSequence = new();

                for (int i = sequence.Count - 1; i >= 0; i--)
                {
                    newSequence.Add(sequence[i]);
                }

                return newSequence;
            };

            Console.WriteLine(string.Join(" ", sequenceReverse(numbers)));
        }
    }
}