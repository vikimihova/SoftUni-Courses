namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersPerForceSide = new();

            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] tokens = command.Split(" | ");
                    string side = tokens[0];
                    string user = tokens[1];

                    if (usersPerForceSide.Any(x => x.Value.Contains(user)))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    if (!usersPerForceSide.ContainsKey(side))
                    {
                        usersPerForceSide.Add(side, new List<string>());
                    }

                    if (!usersPerForceSide[side].Contains(user))
                    {
                        usersPerForceSide[side].Add(user);
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] tokens = command.Split(" -> ");
                    string user = tokens[0];
                    string side = tokens[1];

                    if (usersPerForceSide.Any(x => x.Value.Contains(user)))
                    {
                        foreach (var kvp in usersPerForceSide.Where(x => x.Value.Contains(user)))
                        {
                            kvp.Value.Remove(user);
                        }
                    }

                    if (!usersPerForceSide.ContainsKey(side))
                    {
                        usersPerForceSide.Add(side, new List<string>());
                    }

                    usersPerForceSide[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }

                command = Console.ReadLine();
            }

            foreach (var (side, users) in usersPerForceSide.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
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