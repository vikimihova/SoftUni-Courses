using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append($"Make: {Make}");
            sb.Append($"Model: {Model}");
            sb.Append($"HorsePower: {HorsePower}");
            sb.Append($"RegistrationNumber: {RegistrationNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
