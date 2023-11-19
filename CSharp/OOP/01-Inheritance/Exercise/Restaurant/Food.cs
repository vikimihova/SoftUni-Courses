using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Food : Product
    {
        private double grams;

        public Food(string name) : base(name)
        {
            
        }
        public Food(string name, decimal price) : base(name, price)
        {
            
        }
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }

        public virtual double Grams 
        {
            get
            {
                return grams;
            }
            set
            {
                grams = value;
            } 
        }
    }
}
