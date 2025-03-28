 namespace _04_SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());

            int sumOfChars = 0;

            for (int i = 0; i < numberOfChars; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                int currentCharValue = currentChar;
                sumOfChars += currentCharValue;
            }

            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}