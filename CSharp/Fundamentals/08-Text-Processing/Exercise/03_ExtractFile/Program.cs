namespace _03_ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] separators = { '.', '\\' };

            string[] path = Console.ReadLine().Split(separators);

            Console.WriteLine($"File name: {path[path.Length - 2]}");
            Console.WriteLine($"File extension: {path[path.Length - 1]}");
        }
    }
}