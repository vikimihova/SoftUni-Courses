namespace _09_PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();            

            while (input != "END")
            {
                Console.WriteLine(CheckPalindrome(input).ToString().ToLower());

                input = Console.ReadLine();
            }
        }

        static bool CheckPalindrome(string number, bool isPalindrome = true)
        {
            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }                
            }

            return isPalindrome;
        }
    }
}