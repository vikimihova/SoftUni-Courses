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
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;            
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string WhoAmI()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine($"{Model}:");
            info.AppendLine($" {Engine.Model}:");
            info.AppendLine($"   Power: {Engine.Power}");

            if (Engine.Displacement == 0)
            {
                info.AppendLine($"   Displacement: n/a");
            }
            else
            {
                info.AppendLine($"   Displacement: {Engine.Displacement}");
            }

            if (Engine.Efficiency == null)
            {
                info.AppendLine($"   Efficiency: n/a");
            }
            else
            {
                info.AppendLine($"   Efficiency: {Engine.Efficiency}");
            }

            if (Weight == 0)
            {
                info.AppendLine($" Weight: n/a");
            }
            else
            {
                info.AppendLine($" Weight: {Weight}");
            }

            if (Color == null)
            {
                info.AppendLine($" Color: n/a");
            }
            else
            {
                info.AppendLine($" Color: {Color}");
            }

            return info.ToString().Trim();
        }
    }
}
