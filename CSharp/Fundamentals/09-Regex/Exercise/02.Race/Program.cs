using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ").ToList();

            Dictionary<string, int> scoreTable = new Dictionary<string, int>();

            string onlyLetters = @"[A-Z,a-z]";
            Regex regexLetters = new Regex(onlyLetters);

            string onlyDigits = @"\d";
            Regex regexDigits = new Regex(onlyDigits);

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection letters = regexLetters.Matches(input);
                string name = string.Join("", letters);

                MatchCollection digits = regexDigits.Matches(input);
                string scoreParts = string.Join("", digits);

                int score = 0;

                if (participants.Contains(name))
                {
                    for (int i = 0; i < scoreParts.Length; i++)
                    {
                        string digit = scoreParts[i].ToString();
                        score += int.Parse(digit);
                    }

                    if (scoreTable.Keys.Contains(name))
                    {
                        scoreTable[name] += score;
                    }
                    else
                    {
                        scoreTable[name] = score;
                    }
                }

                input = Console.ReadLine();
            }

            string[] winners = scoreTable.OrderByDescending(x => x.Value).Take(3).Select(x => x.Key).ToArray();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
        }
    }
}