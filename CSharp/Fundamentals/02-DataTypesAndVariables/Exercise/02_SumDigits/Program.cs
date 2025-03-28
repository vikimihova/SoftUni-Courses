namespace _02_SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int length = number.ToString().Length;

            int sumOfDigits = 0;

            for (int i = 0; i < length; i++)
            {
                int currentDigit = number % 10;

                sumOfDigits += currentDigit;

                number = number / 10;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}