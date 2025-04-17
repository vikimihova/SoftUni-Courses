namespace _04_TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequenceCount = int.Parse(Console.ReadLine());

            if (sequenceCount <= 0)
            {
                return;
            }

            int[] tribonacciSequence = new int[sequenceCount];
            tribonacciSequence[0] = 1;

            for (int i = 1; i < sequenceCount; i++)
            {
                tribonacciSequence[i] = CalculateTribonacciNumber(i, tribonacciSequence);
            }

            Console.WriteLine(string.Join(' ', tribonacciSequence));
        }

        static int CalculateTribonacciNumber(int index, int[] sequence)
        {
            int number = 0;
            int i = index - 1;

            while (i >= 0 && i >= index - 3)
            {
                number += sequence[i--];
            }

            return number;
        }
    }
}
