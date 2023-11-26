using _05.FootballTeamGenerator.Models;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(";");

                string teamName = tokens[1];

                try
                {
                    if (tokens[0] == "Team")
                    {
                        Team team = new(teamName);

                        teams.Add(team);
                    }
                    else if (tokens[0] == "Add")
                    {
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Player player = new(playerName, endurance, sprint, dribble, passing, shooting);

                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        team.AddPlayer(player);
                    }
                    else if (tokens[0] == "Remove")
                    {
                        string playerName = tokens[2];

                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        team.RemovePlayer(playerName);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine($"{teamName} - {team.Rating:f0}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
        }
    }
}