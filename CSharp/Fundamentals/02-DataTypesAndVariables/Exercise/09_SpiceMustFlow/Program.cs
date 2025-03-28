namespace _09_SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYieldOfSpiceSource = int.Parse(Console.ReadLine());
            int currentDailyYield = startingYieldOfSpiceSource;

            int totalSpiceGathered = 0;

            int daysCounter = 0;

            while (currentDailyYield >= 100)
            {
                daysCounter++;
                totalSpiceGathered += currentDailyYield - 26;
                currentDailyYield -= 10;
            }

            if (totalSpiceGathered >= 26)
            {
                totalSpiceGathered -= 26;
            }
            
            Console.WriteLine(daysCounter);
            Console.WriteLine(totalSpiceGathered);
        }
    }
}