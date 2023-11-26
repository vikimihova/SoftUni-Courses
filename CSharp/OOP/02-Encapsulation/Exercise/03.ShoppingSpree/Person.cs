using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
		private string name;
        private decimal money;

		public Person(string name, decimal money) 
		{
			Name = name;
			Money = money;
			BagOfProducts = new List<string>();
		}

        public string Name
		{
			get { return name; }
			set 
			{
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value; 
			}
		}
		public decimal Money
		{
			get { return money; }
			set 
			{
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value; 
			}
		}
		public List<string> BagOfProducts { get; set; }
	}
}
