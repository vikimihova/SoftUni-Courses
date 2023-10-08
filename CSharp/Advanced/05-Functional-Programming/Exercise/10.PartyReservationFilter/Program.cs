namespace _10.PartyReservationFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            string input = Console.ReadLine();

            Dictionary<string, Predicate<string>> filters = new();

            while (input != "Print")
            {
                string[] commandTokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = commandTokens[0];
                string filter = commandTokens[1];
                string value = commandTokens[2];

                Predicate<string> predicate = DefinePredicate(filter, value);

                if (action.Contains("Add"))
                {
                    filters.Add(filter + value, predicate);
                }
                else if (action.Contains("Remove"))
                {
                    filters.Remove(filter + value);
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in filters)
            {
                guests.RemoveAll(kvp.Value);
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        static Predicate<string> DefinePredicate(string filter, string value)
        {
            if (filter == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            else if (filter == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            else if (filter == "Length")
            {
                return x => x.Length == int.Parse(value);
            }
            else if (filter == "Contains")
            {
                return x => x.Contains(value);
            }
            else
            {
                return null;
            }
        }
    }
}