namespace _10_Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialPokePower = int.Parse(Console.ReadLine());
            int targetDistance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
                        
            int pokePower = initialPokePower;

            int targetCounter = 0;

            while (pokePower >= targetDistance)
            {                
                targetCounter++;
                pokePower -= targetDistance;

                if ((decimal)pokePower == initialPokePower * 0.5m && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(targetCounter);            
        }
    }
}