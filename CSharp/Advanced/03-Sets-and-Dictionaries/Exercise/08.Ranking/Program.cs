using System.Globalization;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string contest = input.Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
                string password = input.Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

                if (!contestPasswords.ContainsKey(contest) )
                {
                    contestPasswords.Add(contest, password);
                }

                input = Console.ReadLine();
            }
            
            SortedDictionary<string, Dictionary<string, int>> results = new();
            
            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] content = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = content[0];
                string password = content[1];
                string username = content[2];
                int points = int.Parse(content[3]);

                if (!contestPasswords.ContainsKey(contest) || contestPasswords[contest] != password)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (results.ContainsKey(username))
                {
                    if (results[username].ContainsKey(contest) && points > results[username][contest])
                    {
                        results[username][contest] = points;
                    }
                    else if (!results[username].ContainsKey(contest))
                    {
                        results[username].Add(contest, points);
                    }
                }
                else
                {
                    results.Add(username, new Dictionary<string, int>());
                    results[username].Add(contest, points);
                }
                

                input = Console.ReadLine();
            }

            string bestCandidate = string.Empty;
            int bestResult = int.MinValue;

            foreach (var (username, contestResults) in results)
            {
                int sum = 0;

                foreach (var (contest, points) in contestResults)
                {
                    sum += points;
                }

                if (sum > bestResult)
                {
                    bestResult = sum;
                    bestCandidate = username;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestResult} points.");
            Console.WriteLine("Ranking:");

            foreach (var (username, contestResults) in results)
            {
                Console.WriteLine(username);

                foreach (var (contest, points) in contestResults.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}