namespace _04_SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var registeredUsers = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string commandType = command[0];
                string userName = command[1];
                
                if (commandType == "register")
                {
                    string licensePlate = command[2];

                    if (registeredUsers.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                    else
                    {
                        registeredUsers.Add(userName, licensePlate);

                        Console.WriteLine($"{userName} registered {licensePlate} successfully");
                    }
                }
                else if (commandType == "unregister")
                {
                    if (!registeredUsers.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        registeredUsers.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }

            foreach (var item in registeredUsers)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}