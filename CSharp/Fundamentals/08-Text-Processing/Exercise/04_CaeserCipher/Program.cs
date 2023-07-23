using System.Net.Http.Headers;
using System.Text;

namespace _04_CaeserCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < inputText.Length; i++)
            {
                int currentChar = (char)inputText[i];

                char newChar = (char)(currentChar + 3);

                encryptedText.Append(newChar);
            }
            
            Console.WriteLine(encryptedText);
        }
    }
}