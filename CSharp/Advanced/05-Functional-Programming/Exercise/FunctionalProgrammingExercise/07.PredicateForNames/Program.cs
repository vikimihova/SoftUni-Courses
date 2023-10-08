namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNameLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<int> nameLengthMatch = x => x <= maxNameLength;

            for (int i = 0; i < names.Length; i++)
            {
                if (nameLengthMatch(names[i].Length))
                {
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}