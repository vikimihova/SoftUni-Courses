namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> countBySymbols = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (countBySymbols.ContainsKey(text[i]))
                {
                    countBySymbols[text[i]]++;
                }
                else
                {
                    countBySymbols.Add(text[i], 1);
                }
            }

            foreach (var symbol in countBySymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}