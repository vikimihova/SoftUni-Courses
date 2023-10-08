namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minSum = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            Func<string, int, bool> condition = (name, minSum) => name.Sum(x => x) >= minSum;


            Func<int, List<string>, Func<string, int, bool>, string> generateResult =
                (minSum, names, condition) => names.FirstOrDefault(name => condition(name, minSum));

            Console.WriteLine(generateResult(minSum, names, condition));
        }
    }
}