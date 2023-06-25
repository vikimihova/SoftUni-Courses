using System.Diagnostics.Metrics;
using static _05_TeamworkProjects.Program;

namespace _05_TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-").ToArray();
                string creator = teamInfo[0];
                string teamName = teamInfo[1];
                List<string> members = new List<string>();

                bool isValid = true;

                foreach (Team team in teams)
                {
                    if (team.TeamName == teamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                        isValid = false;
                    }
                    else if (team.Creator == creator)
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    teams.Add(new Team(creator, teamName, members));
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string[] commandContent = command.Split("->").ToArray();
                string user = commandContent[0];
                string toTeam = commandContent[1];

                bool isFound = false;
                bool isMember = false;

                foreach (Team team in teams)
                {
                    if (toTeam == team.TeamName)
                    {
                        isFound = true; 
                    }

                    foreach (string member in team.Members)
                    {
                        if (user == member)
                        {
                            isMember = true;
                            Console.WriteLine($"Member {user} cannot join team {toTeam}!");
                        }
                        break;
                    }

                    if (user == team.Creator)
                    {
                        isMember = true;
                        Console.WriteLine($"Member {user} cannot join team {toTeam}!");
                    }

                    if (isFound == true && isMember == false)
                    {
                        team.Members.Add(user);   
                        team.MembersCount++;
                        break;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine($"Team {toTeam} does not exist!");
                }

                command = Console.ReadLine();
            }

            foreach (Team team in teams.OrderByDescending(x => x.MembersCount))
            {
                if (team.MembersCount > 0)
                {
                    Console.WriteLine(team.TeamName);
                    Console.WriteLine($"- {team.Creator}");

                    team.SortMembers(team.Members);

                    foreach (string member in team.Members)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }   
            }

            Console.WriteLine("Teams to disband:");

            List<Team> disbandTeams = teams.Where(x => x.MembersCount == 0).ToList();            

            foreach (Team team in disbandTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }

        public class Team
        {
            public Team(string creator, string teamName, List<string> members)
            {
                Creator = creator;
                TeamName = teamName;               
                Members = members;
            }

            public string Creator { get; set; }
            public string TeamName { get; set; }
            public int MembersCount { get; set; }
            public List<string> Members { get; set; }
           
            public void SortMembers(List<string> members)
            {
                Members.Sort();
            }
        }
    }
}