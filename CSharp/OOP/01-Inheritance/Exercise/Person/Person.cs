using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
		private string name;
        private uint age;

        public Person(string name, uint age)
        {
            Name = name;
            Age = age;
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public virtual uint Age
		{
			get { return age; }
			set { age = value; }
		}

		public override string ToString()
		{
			return $"Name: {Name}, Age: {Age}";
		}
	}
}
