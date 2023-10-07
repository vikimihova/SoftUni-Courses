namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputText = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToList();

            Action<string> printLine = x => Console.WriteLine(x);

            inputText.ForEach(printLine);
        } 
    }
}