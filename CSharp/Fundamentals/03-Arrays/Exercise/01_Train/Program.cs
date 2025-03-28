namespace _01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] numberOfPassengersPerWagon = new int[numberOfWagons];
            int totalNumberOfPassengers = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                numberOfPassengersPerWagon[i] = int.Parse(Console.ReadLine());
                totalNumberOfPassengers += numberOfPassengersPerWagon[i];
            }      

            Console.WriteLine(string.Join(" ", numberOfPassengersPerWagon));
            Console.WriteLine(totalNumberOfPassengers);
            
        }
    }
}