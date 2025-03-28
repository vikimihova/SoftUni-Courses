namespace _05_PrintPartOfTheASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstCharIndex = int.Parse(Console.ReadLine());
            int lastCharIndex = int.Parse(Console.ReadLine());

            for (int i = firstCharIndex; i <= lastCharIndex; i++)
            {
                char currentChar = (char)i;

                Console.Write(currentChar + " ");
            }
        }
    }
}