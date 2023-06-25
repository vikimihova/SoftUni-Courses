using static _07_VehicleCatalogue.Program;

namespace _07_VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            Catalogue collection = new Catalogue(cars, trucks);

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] vehicleInfo = input.Split("/").ToArray();

                string type = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];
                string weightOrHorsePower = vehicleInfo[3];

                if (type == "Car")
                {                    
                    collection.Cars.Add(new Car(brand, model, weightOrHorsePower));
                }
                else if (type == "Truck")
                {
                    collection.Trucks.Add(new Truck(brand, model, weightOrHorsePower));
                }

                input = Console.ReadLine();
            }
                        
            if (collection.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in collection.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }            

            if (collection.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in collection.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

        public class Truck
        {
            public Truck(string brand, string model, string weight)
            {
                Brand = brand;
                Model = model;
                Weight = weight;
            }

            public string Brand { get; set; }
            public string Model { get; set; }
            public string Weight { get; set; }
        }

        public class Car
        {
            public Car(string brand, string model, string horsePower)
            {
                Brand = brand;
                Model = model;
                HorsePower = horsePower;
            }

            public string Brand { get; set; }
            public string Model { get; set; }
            public string HorsePower { get; set; }
        }

        public class Catalogue
        {
            public Catalogue(List<Car> cars, List<Truck> trucks)
            {
                Cars = cars;
                Trucks = trucks;
            }

            public List<Car> Cars { get; set;}
            public List<Truck> Trucks { get; set;}

        }
    }
}