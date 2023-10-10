namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();

            int numberOfCars = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                cars.Add(car);

                input = Console.ReadLine();
            }

            while (input != "End")
            {
                string[] commandTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commandTokens[1];
                double distance = double.Parse(commandTokens[2]);

                foreach (Car car in cars.Where(x => x.Model == model))
                {
                    car.Drive(distance);
                }

                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}