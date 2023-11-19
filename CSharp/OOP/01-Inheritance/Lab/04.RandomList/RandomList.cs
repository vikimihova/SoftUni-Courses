using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        //public RandomList(IEnumerable<string> collection) : base(collection)
        //{
        //}

        public string RandomString()
        {
            Random random = new Random();

            string randomElement = this[random.Next(0, this.Count)];

            this.Remove(randomElement);

            return randomElement;
        }
    }
}
