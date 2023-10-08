using System;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rangeLimit = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToHashSet();


            List<Predicate<int>> predicates = new();

            foreach (int divider in dividers)
            {
                Predicate<int> predicate = x => x % divider == 0;

                predicates.Add(predicate);
            }

            Func<int, List<Predicate<int>>, List<int>> generateResult = (rangeLimit, predicates) =>
            {
                List<int> result = new();

                for (int i = 1; i <= rangeLimit; i++)
                {
                    result.Add(i);

                    foreach (var predicate in predicates)
                    {
                        if (!predicate(i))
                        {
                            result.Remove(i);
                            break;
                        }
                    }
                }

                return result;
            };

            List<int> result = generateResult(rangeLimit, predicates);

            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            print(result);
        }
    }
}