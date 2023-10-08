namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, List<int>> generateRange = (start, end) =>
            {
                List<int> range = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }

                return range;
            };

            int[] rangeLimits = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            int start = rangeLimits[0];
            int end = rangeLimits[1];

            string command = Console.ReadLine();

            Predicate<int> condition = DefinePredicate(command);
            
            Console.WriteLine(string.Join(" ", generateRange(start, end).Where(x => condition(x))));
        }

        static Predicate<int> DefinePredicate(string command)
        {
            Predicate<int> condition = null;

            if (command == "even")
            {
                condition = x => x % 2 == 0;
            }
            else if (command == "odd")
            {
                condition = x => x % 2 != 0;
            }

            return condition;
        }       
    }
}