using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, uint age) : base(name, age)
        {

        }

        public override uint Age 
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value <= 15)
                {
                    base.Age = value;
                }
            }
        }
    }
}
