using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base (id, firstName, lastName, salary)
        {            
            privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates => privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");

            foreach ( IPrivate priv in Privates )
            {
                sb.AppendLine("  " + priv.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
