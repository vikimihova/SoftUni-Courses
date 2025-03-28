using System.Text.RegularExpressions;

namespace EncryptingPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            string pattern = @"^([\W\w]+)>(?<first>\d{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[\W^<>\w]{3})<\1$";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < numberOfLines; i++)
            {
                string password = Console.ReadLine();

                Match match = regex.Match(password);

                if (match.Success)
                {
                    string[] groups = new string[]{ match.Groups["first"].Value, match.Groups["second"].Value, match.Groups["third"].Value, match.Groups["fourth"].Value };

                    Console.WriteLine($"Password: {string.Join("", groups)}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}