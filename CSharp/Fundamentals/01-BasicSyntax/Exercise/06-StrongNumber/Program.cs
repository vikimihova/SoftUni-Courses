using System;

namespace _06_StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            int number = int.Parse(inputNumber);
            int sum = 0;

            for (int j = 0; j < inputNumber.Length; j++)
            {
                char currentSymbol = inputNumber[j];
                string currentSymbolString = currentSymbol.ToString();
                int currentNumber = int.Parse(currentSymbolString);

                int currentProduct = 1;
                for (int i = 1; i <= currentNumber; i++)
                {                    
                    currentProduct *= i;                    
                }
                sum += currentProduct;
            }

            if (number == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
