using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Starter : Food
    {
        public Starter(string name, decimal price, double grams) : base(name, price, grams)
        {
            
        }
    }
}
