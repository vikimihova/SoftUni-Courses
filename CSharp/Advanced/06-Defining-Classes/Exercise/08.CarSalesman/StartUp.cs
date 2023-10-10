using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                int displacement = 0;
                string efficiency = null;

                if (engineInfo.Length > 2)
                {
                    bool isNumber = int.TryParse(engineInfo[2], out displacement);

                    if (isNumber)
                    {
                        displacement = int.Parse(engineInfo[2]);
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                    }
                }

                if (engineInfo.Length > 3)
                {
                    efficiency = engineInfo[3];
                }

                Engine engine = new Engine(engineModel, power, displacement, efficiency);

                engines.Add(engine);
            }

            List<Car> cars = new();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];
                int weight = 0;
                string color = null;

                if (carInfo.Length > 2)
                {
                    bool isNumber = int.TryParse(carInfo[2], out weight);

                    if (isNumber)
                    {
                        weight = int.Parse(carInfo[2]);
                    }
                    else
                    {
                        color = carInfo[2];
                    }
                }

                if (carInfo.Length > 3)
                {
                    color = carInfo[3];
                }

                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                Car car = new Car(model, engine, weight, color);

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}