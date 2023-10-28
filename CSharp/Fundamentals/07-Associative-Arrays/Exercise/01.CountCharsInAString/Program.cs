namespace _01_CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countOfChars = new Dictionary<char, int>();

            char[] characters = Console.ReadLine().ToArray();

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != ' ' && !countOfChars.ContainsKey(characters[i]))
                {
                    countOfChars.Add(characters[i], 1);
                }
                else if (characters[i] != ' ')
                {
                    countOfChars[characters[i]]++;
                }
            }

            foreach (var kvp in countOfChars)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}