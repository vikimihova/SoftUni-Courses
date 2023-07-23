namespace _01_ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> validUsernames = new List<string>();

            foreach (string username in usernames)
            {
                bool isValid = true;

                if (username.Length < 3 || username.Length > 16)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(username[i]) && username[i] != 45 && username[i] != 95)
                        {
                            isValid = false;
                            break;
                        }
                    }                    
                }

                if (isValid)
                {
                    validUsernames.Add(username);
                }
            }

            foreach (string username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}