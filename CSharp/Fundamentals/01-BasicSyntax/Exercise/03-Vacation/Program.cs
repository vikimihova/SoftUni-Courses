using System;

namespace _03_Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double pricePerPerson = 0;

            if (typeOfGroup == "Students")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerPerson = 8.45;
                        break;
                    case "Saturday":
                        pricePerPerson = 9.80;
                        break;
                    case "Sunday":
                        pricePerPerson = 10.46;
                        break;
                }
            }
            else if (typeOfGroup == "Business")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerPerson = 10.90;
                        break;
                    case "Saturday":
                        pricePerPerson = 15.60;
                        break;
                    case "Sunday":
                        pricePerPerson = 16;
                        break;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerPerson = 15;
                        break;
                    case "Saturday":
                        pricePerPerson = 20;
                        break;
                    case "Sunday":
                        pricePerPerson = 22.50;
                        break;
                }
            }

            double endPricePerGroup = numberOfPeople * pricePerPerson;

            if (typeOfGroup == "Students" && numberOfPeople >= 30)
            {
                endPricePerGroup = endPricePerGroup * 0.85;
            }
            else if (typeOfGroup == "Business" && numberOfPeople >= 100)
            {
                endPricePerGroup = endPricePerGroup - 10 * pricePerPerson;
            }
            else if (typeOfGroup == "Regular" && 10 <= numberOfPeople && numberOfPeople <= 20)
            {
                endPricePerGroup = endPricePerGroup * 0.95;
            }

            Console.WriteLine($"Total price: {endPricePerGroup:F2}");
        }
    }
}
