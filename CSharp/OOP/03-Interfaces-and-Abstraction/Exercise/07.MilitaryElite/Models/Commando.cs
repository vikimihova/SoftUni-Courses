using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base (id, firstName, lastName, salary, corps)
        {
            missions = new List<Mission>();
        }

        public List<Mission> Missions => missions;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (Mission mission in Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
