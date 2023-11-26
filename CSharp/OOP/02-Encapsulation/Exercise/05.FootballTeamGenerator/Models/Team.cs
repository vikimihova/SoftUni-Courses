

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private const string ArgumentExceptionMessageName = "A name should not be empty.";
        private const string ArgumentExceptionMessageMissingPlayer = "Player {0} is not in {1} team.";

        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name 
        { 
            get 
            { 
                return name; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ArgumentExceptionMessageName);
                }

                name = value;
            }
        }
        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(x => x.Stats);
                }
                
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException(string.Format(ArgumentExceptionMessageMissingPlayer, playerName, Name));
            }

            players.Remove(player);
        }
    }
}
