namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            string input = Console.ReadLine();

            while (input != "Party!") 
            {
                string[] commandTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandTokens[0];
                string filter = commandTokens[1];
                string value = commandTokens[2];

                Predicate<string> predicate = DefinePredicate(filter, value);

                if (action == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else
                {
                    List<string> guestsToDouble = guests.FindAll(predicate);

                    foreach (var guest in guestsToDouble)
                    {
                        int index = guests.FindIndex(x => x == guest);
                        guests.Insert(index, guest);
                    }
                }

                input = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");                
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> DefinePredicate(string filter, string value)
        {
            if (filter == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            else if (filter == "EndsWith")
            {
                return x => x.EndsWith(value);
            }
            else if (filter == "Length") 
            { 
                return x => x.Length == int.Parse(value);    
            }
            else
            {
                return null;
            }
        }
    }
}