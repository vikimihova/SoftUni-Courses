using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, CarManufacturer.Engine engine, CarManufacturer.Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        private CarManufacturer.Engine engine;

        public CarManufacturer.Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private CarManufacturer.Tire[] tires;

        public CarManufacturer.Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void Drive(double distance)
        {
            if (FuelConsumption * distance / 100 <= FuelQuantity)
            {
                FuelQuantity -= distance * FuelConsumption / 100;
            }
        }

        public string WhoAmI()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine($"Make: {Make}");
            info.AppendLine($"Model: {Model}");
            info.AppendLine($"Year: {Year}");
            info.AppendLine($"HorsePowers: {Engine.HorsePower}");
            info.AppendLine($"FuelQuantity: {FuelQuantity}");

            return info.ToString().Trim();
        }
    }
}
