using _04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id) 
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; init; }
        public int Age { get; private set; }
        public string Id { get; init; }

        public bool CheckId(string lastIdDigits)
        {
            return Id.EndsWith(lastIdDigits);
        }
    }
}
