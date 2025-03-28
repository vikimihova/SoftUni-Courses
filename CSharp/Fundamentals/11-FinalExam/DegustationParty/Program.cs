namespace DegustationParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, List<string>> meals = new Dictionary<string, List<string>>();

            int dislikedMeals = 0;

            while (command != "Stop")
            {
                string[] commands = command.Split("-").ToArray();
                string guest = commands[1];
                string meal = commands[2];

                if (commands[0] == "Like")
                {               
                    if (!meals.ContainsKey(guest))
                    {
                        List<string> list = new List<string>();
                        list.Add(meal);

                        meals[guest] = list;
                    }
                    else
                    {
                        List<string> guestMeals = meals[guest];

                        if (!guestMeals.Contains(meal))
                        {
                            meals[guest].Add(meal);
                        }                        
                    }                    
                }
                else if (commands[0] == "Dislike")
                {
                    if (!meals.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        List<string> guestMeals = meals[guest];

                        if (!guestMeals.Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            meals[guest].Remove(meal);

                            dislikedMeals++;

                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var kvp in meals)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }

            Console.WriteLine($"Unliked meals: {dislikedMeals}");            
        }
    }
}