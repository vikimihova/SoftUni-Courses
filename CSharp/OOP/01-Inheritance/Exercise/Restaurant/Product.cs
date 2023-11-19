using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Product
    {
        public Product(string name)
        {
            Name = name;
        }
        public Product(string name, decimal price) : this(name)
        {
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }


    }
}
