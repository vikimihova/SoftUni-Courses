namespace _05_MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            string productSign = DetermineProductSign(numbers);

            Console.WriteLine(productSign);
        }

        static string DetermineProductSign(int[] numbers)
        {
            int negativeSignCount = 0;
            bool isZero = false;

            foreach (int number in numbers)
            {
                if (number < 0)
                {
                    negativeSignCount++;
                }

                if (number == 0)
                {
                    isZero = true;
                    break;
                }
            }

            if (isZero) 
            {
                return "zero";
            }
            else if (negativeSignCount % 2 == 0)
            {
                return "positive";
            }
            else
            {
                return "negative";
            }
        }
    }
}
