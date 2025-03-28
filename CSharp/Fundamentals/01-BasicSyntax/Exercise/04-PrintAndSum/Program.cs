using System;

namespace _04_PrintAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingValue = int.Parse(Console.ReadLine());
            int finalValue = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = startingValue; i <= finalValue; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
