namespace _05_TeamworkProjectsV2
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
                bool isCreator = false;

                foreach (Team team in teams)
                {
                    if (toTeam == team.TeamName)
                    {
                        isFound = true;                        
                    }

                    if (user == team.Creator)
                    {
                        isCreator = true;                        
                    }

                    foreach (string member in team.Members)
                    {
                        if (user == member)
                        {
                            isMember = true;
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine($"Team {toTeam} does not exist!");
                }
                else if (isMember || isCreator)
                {
                    Console.WriteLine($"Member {user} cannot join team {toTeam}!");
                }
                else
                {
                    Team teamFound = teams.FirstOrDefault(t => t.TeamName == toTeam);
                    teamFound.Members.Add(user);
                }

                command = Console.ReadLine();
            }

            foreach (Team team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
            {
                if (team.Members.Count > 0)
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

            List<Team> disbandTeams = teams.Where(x => x.Members.Count == 0).ToList();

            foreach (Team team in disbandTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }

        public class Team
        {
            public Team(string creator, string teamName, List<string> members)
            {
                TeamName = teamName;
                Creator = creator;
                Members = members;
            }

            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }

            public void SortMembers(List<string> members)
            {
                Members.Sort();
            }
        }
    }
}