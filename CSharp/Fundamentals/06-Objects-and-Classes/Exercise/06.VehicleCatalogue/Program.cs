using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using static _06_VehicleCatalogue.Program;

namespace _06_VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();
                        
            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] vehicleInformation = inputLine.Split();
                string type = vehicleInformation[0];
                string model = vehicleInformation[1];
                string color = vehicleInformation[2];
                double horsepower = double.Parse(vehicleInformation[3]);

                if (type == "car")
                {
                    Vehicle car = new Vehicle(type, model, color, horsepower);
                    cars.Add(car);
                }
                else if (type == "truck")
                {
                    Vehicle truck = new Vehicle(type, model, color, horsepower);
                    trucks.Add(truck);
                }

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "Close the Catalogue")
            {
                PrintModelInformation(cars, trucks, inputLine);
                
                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"Cars have average horsepower of: {AverageHorsepower(cars):f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {AverageHorsepower(trucks):f2}.");
        }
               
        public class Vehicle
        {
            public Vehicle(string type, string model, string color, double horsepower)
            {
                Type = type;
                Model = model;
                Color = color;
                Horsepower = horsepower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double Horsepower { get; set; }
        }

        static double AverageHorsepower(List<Vehicle> vehicles)
        {
            if (vehicles.Count > 0)
            {
                double sumOfHorsepowers = 0;

                for (int i = 0; i < vehicles.Count; i++)
                {
                    sumOfHorsepowers += vehicles[i].Horsepower;
                }

                return sumOfHorsepowers / vehicles.Count;
            }
            else
            {
                return 0;
            }            
        }

        static void PrintModelInformation(List<Vehicle> cars, List<Vehicle> trucks, string inputLine)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Model == inputLine)
                {
                    Console.WriteLine($"Type: Car");
                    Console.WriteLine($"Model: {cars[i].Model}");
                    Console.WriteLine($"Color: {cars[i].Color}");
                    Console.WriteLine($"Horsepower: {cars[i].Horsepower}");
                    break;
                }
            }

            for (int i = 0; i < trucks.Count; i++)
            {
                if (trucks[i].Model == inputLine)
                {
                    Console.WriteLine($"Type: Truck");
                    Console.WriteLine($"Model: {trucks[i].Model}");
                    Console.WriteLine($"Color: {trucks[i].Color}");
                    Console.WriteLine($"Horsepower: {trucks[i].Horsepower}");
                    break;
                }
            }
        }
    }
}