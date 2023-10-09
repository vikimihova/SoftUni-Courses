namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tireParameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4];

                for (int i = 0; i < tireParameters.Length && i % 2 == 0; i += 2)
                {
                    tires[i / 2] = new Tire(int.Parse(tireParameters[i]), double.Parse(tireParameters[i + 1])); 
                }

                tiresList.Add(tires);

                input = Console.ReadLine();
            }


            List<Engine> engineList = new();

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] engineParameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineParameters[0]);
                double cubicCapacity = double.Parse(engineParameters[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engineList.Add(engine);

                input = Console.ReadLine();
            }

            List<Car> cars = new();

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] carParameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carParameters[0];
                string model = carParameters[1];
                int year = int.Parse(carParameters[2]);
                double fuelQuantity = double.Parse(carParameters[3]);
                double fuelConsumption = double.Parse(carParameters[4]);
                int engineIndex = int.Parse(carParameters[5]);
                int tiresIndex = int.Parse(carParameters[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineList[engineIndex], tiresList[tiresIndex]);

                cars.Add(car);

                input = Console.ReadLine();
            }

            foreach (Car car in cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330))
            {
                double pressureSum = 0;

                for (int i = 0; i < car.Tires.Length; i++)
                {
                    pressureSum += car.Tires[i].Pressure;
                }

                if (pressureSum > 9 && pressureSum < 10)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}