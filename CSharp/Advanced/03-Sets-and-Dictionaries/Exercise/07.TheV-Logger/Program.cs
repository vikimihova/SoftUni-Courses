using System.Linq;

namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var log = new Dictionary<string, List<string>[]>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputContent = input
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vloggername = inputContent[0];
                string command = inputContent[1];

                if (command == "joined" && !log.ContainsKey(vloggername))
                {
                    log.Add(vloggername, new List<string>[2]);

                    List<string> followers = new List<string>();
                    List<string> following = new List<string>();

                    log[vloggername][0] = followers;
                    log[vloggername][1] = following;
                }
                else if (command == "followed")
                {
                    string vloggername2 = inputContent[2];

                    if (!log.ContainsKey(vloggername) || !log.ContainsKey(vloggername2) || vloggername == vloggername2)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!log[vloggername2][0].Contains(vloggername))
                    {
                        log[vloggername2][0].Add(vloggername);
                        log[vloggername][1].Add(vloggername2);
                    }                    
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {log.Count} vloggers in its logs.");

            var sortedLog = log.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count);

            Console.WriteLine($"1. {sortedLog.First().Key} : {sortedLog.First().Value[0].Count} followers, {sortedLog.First().Value[1].Count} following");

            foreach (var follower in sortedLog.First().Value[0].OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            int nextNumber = 2;

            foreach (var vlogger in sortedLog.Skip(1))
            {
                Console.WriteLine($"{nextNumber}. {vlogger.Key} : {vlogger.Value[0].Count} followers, {vlogger.Value[1].Count} following");

                nextNumber++;
            }
        }
    }
}