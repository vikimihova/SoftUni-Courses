namespace _07_AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> strings = input.Split('|').ToList();

            string sumOfStrings = string.Empty;

            for (int i = strings.Count - 1; i >= 0; i--)
            {
                sumOfStrings += strings[i] + " ";
            }
            string[] stringArray = sumOfStrings.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine(string.Join(" ", stringArray));
        }
    }
}