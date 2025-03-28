using System;
using System.Text.RegularExpressions;

namespace _09_PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double countOfLightsabers = Math.Ceiling(countOfStudents * 1.1);
            double priceOfLightsabers = pricePerLightsaber * countOfLightsabers;

            double priceOfBelts = countOfStudents * pricePerBelt - countOfStudents / 6 * pricePerBelt;

            double priceOfRobes = pricePerRobe * countOfStudents;

            double totalPrice = priceOfLightsabers + priceOfRobes + priceOfBelts;

            double difference = Math.Abs(budget - totalPrice);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {difference:f2}lv more.");
            }

        }
    }
}
