namespace _01_SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmallestOfThreeNumbers();
        }

        static void SmallestOfThreeNumbers(int smallestNumber = int.MaxValue)
        {
            for (int i = 0; i < 3; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input < smallestNumber)
                {
                    smallestNumber = input;
                }
            }

            Console.WriteLine(smallestNumber);
        }
    }
}