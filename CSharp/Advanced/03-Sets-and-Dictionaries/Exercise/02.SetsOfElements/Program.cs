namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setSizes = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();

            int firstSetSize = setSizes[0];
            int secondSetSize = setSizes[1];

            List<int> firstSet = new List<int>();
            List<int> secondSet = new List<int>();

            for (int i = 0; i < firstSetSize; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondSetSize; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet = firstSet.Intersect(secondSet).ToList();
            
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}