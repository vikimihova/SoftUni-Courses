namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputText = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToList();

            Action<string> printLine = x => Console.WriteLine("Sir " + x);

            inputText.ForEach(printLine);
        }
    }
}