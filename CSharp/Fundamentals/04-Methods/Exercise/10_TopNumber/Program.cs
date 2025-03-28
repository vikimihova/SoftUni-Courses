namespace _10_TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                int sumOfDigits = FindSumOfDigits(i);
                
                if (SumOfDigitsIsDividedBy8(sumOfDigits) && ContainsOddDigits(i))
                {
                    Console.WriteLine(i);
                }      
            }
        }

        static int FindSumOfDigits(int number)
        {
            int sumOfDigits = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;
                sumOfDigits += currentDigit;
                number = number / 10;
            }

            return sumOfDigits;
        }

        static bool SumOfDigitsIsDividedBy8(int number, bool isTrue = true)
        {
            if (number % 8 != 0)
            {
                isTrue = false;
            }

            return isTrue;
        }

        static bool ContainsOddDigits(int number, bool isTrue = false)
        {
            while (number > 0)
            {
                int currentDigit = number % 10;
                
                if (currentDigit % 2 != 0)
                {
                    isTrue = true;
                    break;
                }

                number = number / 10;
            }

            return isTrue;
        }
    }
}