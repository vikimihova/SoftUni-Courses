using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int age, float pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private float pressure;

        public float Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}
