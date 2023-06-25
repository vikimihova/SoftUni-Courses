namespace _01_RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                                   .Split()
                                   .ToArray();

            Random randomValue = new Random();

            for (int i = 0; i < line.Length; i++)
            {
                string wordAtIndex = line[i];
                int randomIndex = randomValue.Next(line.Length);
                line[i] = line[randomIndex];
                line[randomIndex] = wordAtIndex;
            }

            foreach (string word in line)
            {
                Console.WriteLine(word);
            }
        }
    }
}