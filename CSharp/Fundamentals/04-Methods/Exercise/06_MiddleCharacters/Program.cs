namespace _06_MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string middle = string.Empty;


            if (input.Length % 2 == 0)
            {
                middle = FindMiddleOfEvenLength(input);
            }
            else
            {
                middle = FindMiddleOfOddLength(input);
            }

            Console.WriteLine(middle);
        }

        static string FindMiddleOfOddLength(string input)
        {
            char middleCharacter = input[input.Length / 2];
            return middleCharacter.ToString();
        }

        static string FindMiddleOfEvenLength(string input)
        {
            char middleCharacter1 = input[input.Length / 2 - 1];
            char middleCharacter2 = input[input.Length / 2];

            return middleCharacter1.ToString() + middleCharacter2.ToString();
        }
    }
}