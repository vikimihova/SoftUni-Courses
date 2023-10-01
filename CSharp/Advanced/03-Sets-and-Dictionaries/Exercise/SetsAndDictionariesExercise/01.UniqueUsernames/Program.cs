namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}