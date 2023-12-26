using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base (id, firstName, lastName, salary, corps)
        {
            repairs = new List<Repair>();
        }

        public List<Repair> Repairs => repairs;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (Repair repair in Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
