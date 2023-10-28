namespace _06_ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputSequence = Console.ReadLine();

            for (int i = 1; i < inputSequence.Length; i++)
            {
                if (inputSequence[i] == inputSequence[i - 1])
                {
                    inputSequence = inputSequence.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(inputSequence);
        }
    }
}