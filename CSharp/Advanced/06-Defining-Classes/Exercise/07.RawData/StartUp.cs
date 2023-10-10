using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int speed = int.Parse(carInfo[1]);
                int power = int.Parse(carInfo[2]);
                int weight = int.Parse(carInfo[3]);
                string type = carInfo[4];
                float tire1Pressure = float.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                float tire2Pressure = float.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                float tire3Pressure = float.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                float tire4Pressure = float.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(type, weight);

                Tire[] tires = new Tire[] 
                { new Tire(tire1Age, tire1Pressure), 
                  new Tire(tire2Age, tire2Pressure),
                  new Tire(tire3Age, tire3Pressure),
                  new Tire(tire4Age, tire4Pressure)
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(x => x.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach  (Car car in cars.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}