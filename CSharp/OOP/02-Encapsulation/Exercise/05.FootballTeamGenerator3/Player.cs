

namespace _05.FootballTeamGenerator3
{
    public class Player
    {
        private const string ArgumentExceptionMessageName = "A name should not be empty.";
        private const string ArgumentExceptionMessageStats = "{0} should be between 0 and 100.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance 
        {
            get
            {
                return endurance;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessageStats, nameof(Endurance)));
                }

                endurance = value;
            } 
        }
        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessageStats, nameof(Sprint)));
                }

                sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessageStats, nameof(Dribble)));
                }

                dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessageStats, nameof(Passing)));
                }

                passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ArgumentExceptionMessageStats, nameof(Shooting)));
                }

                shooting = value;
            }
        }
        public double Stats
        {
            get
            {
                return (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
            }
        }
    }
}
