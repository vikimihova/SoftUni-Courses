namespace _07_WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waterTankCapacityInLiters = 255;

            int numberOfInputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputLines; i++)
            {
                int currentWaterQuantityInLiters = int.Parse(Console.ReadLine());

                if (waterTankCapacityInLiters - currentWaterQuantityInLiters < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    waterTankCapacityInLiters -= currentWaterQuantityInLiters;
                }
            }

            int waterQuantityInTank = 255 - waterTankCapacityInLiters;
            Console.WriteLine(waterQuantityInTank);            
        }
    }
}