using System.Runtime.CompilerServices;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string[] array = new string[] { "fsg", "fsgg", "sghh"};

            RandomList newList = new RandomList();

            newList.Add("sfdgx");
            newList.Add("Garlick");
            newList.Add("sfsff");

            Console.WriteLine(string.Join("\n", newList));

            newList.RandomString();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(string.Join("\n", newList));

            newList.RandomString();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(string.Join("\n", newList));

            newList.RandomString();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(string.Join("\n", newList));
        }
    }
}