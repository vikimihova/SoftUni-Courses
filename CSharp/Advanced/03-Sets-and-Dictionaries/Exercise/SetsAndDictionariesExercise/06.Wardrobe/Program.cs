using System;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int numberOfClothes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfClothes; i++)
            {
                string[] input = Console.ReadLine()
                                 .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string colour = input[0];

                string[] clothes = input[1]
                                   .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                for (int k = 0; k < clothes.Length; k++)
                {
                    if (wardrobe[colour].ContainsKey(clothes[k]))
                    {
                        wardrobe[colour][clothes[k]]++;
                    }
                    else
                    {
                        wardrobe[colour].Add(clothes[k], 1);
                    }
                }
            }

            string[] wantedOutfit = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string wantedColour = wantedOutfit[0];
            string wantedClothing = wantedOutfit[1];

            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var clothing in colour.Value)
                {                    
                    Console.Write($"* {clothing.Key} - {clothing.Value}");

                    if (colour.Key == wantedColour && clothing.Key == wantedClothing)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}