using System.Security.Cryptography.X509Certificates;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = x => x[0] == x.ToUpper()[0];

            string[] words = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .Where(word => isUpper(word))
                             .ToArray();

            Console.WriteLine(string.Join('\n', words));
        }
    }
}