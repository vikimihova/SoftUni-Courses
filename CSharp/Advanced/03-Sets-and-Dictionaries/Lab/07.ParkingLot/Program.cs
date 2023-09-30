namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumberPlates = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string command = commands[0];
                string carNumberPlate = commands[1];

                if (command == "IN")
                {
                    carNumberPlates.Add(carNumberPlate);
                }
                else if (command == "OUT")
                {
                    carNumberPlates.Remove(carNumberPlate);
                }

                input = Console.ReadLine();
            }

            if (carNumberPlates.Count > 0)
            {
                foreach (var carNumberPlate in carNumberPlates)
                {
                    Console.WriteLine(carNumberPlate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}