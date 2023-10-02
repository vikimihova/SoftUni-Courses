namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sideUserPair = new();

            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] commandParts = command.Split(" | ");
                    string side = commandParts[0];
                    string user = commandParts[1];

                    if (sideUserPair.Any(x => x.Value.Contains(user)))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    if (!sideUserPair.ContainsKey(side))
                    {
                        sideUserPair.Add(side, new List<string>());
                    }

                    if (!sideUserPair[side].Contains(user))
                    {
                        sideUserPair[side].Add(user);
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] commandParts = command.Split(" -> ");
                    string user = commandParts[0];
                    string side = commandParts[1];

                    if (sideUserPair.Any(x => x.Value.Contains(user)))
                    {
                        foreach (var kvp in sideUserPair.Where(x => x.Value.Contains(user)))
                        {
                            kvp.Value.Remove(user);
                        }
                    }

                    if (!sideUserPair.ContainsKey(side))
                    {
                        sideUserPair.Add(side, new List<string>());
                    }

                    sideUserPair[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }

                command = Console.ReadLine();
            }

            foreach (var (side, users) in sideUserPair.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (users.Count > 0)
                {
                    Console.WriteLine($"Side: {side}, Members: {users.Count}");

                    foreach (var user in users.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}