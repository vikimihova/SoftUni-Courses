namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            var placesByContinent = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] entry = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

                string continent = entry[0];
                string country = entry[1];
                string city = entry[2];

                if (placesByContinent.ContainsKey(continent))
                {
                    var placesByCountry = placesByContinent[continent];

                    if (placesByCountry.ContainsKey(country))
                    {
                        placesByCountry[country].Add(city);
                    }
                    else
                    {
                        placesByCountry.Add(country, new List<string>());
                        placesByCountry[country].Add(city);
                    }
                }
                else
                {
                    placesByContinent.Add(continent, new Dictionary<string, List<string>>());
                    placesByContinent[continent].Add(country, new List<string>());
                    placesByContinent[continent][country].Add(city);
                }
            }

            foreach (var (continent, places) in placesByContinent)
            {
                Console.WriteLine(continent + ":");

                foreach (var (country, cityList) in places)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", cityList)}");
                }
            }
        }
    }
}