namespace _01_ExperienceGaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double experienceGoal = double.Parse(Console.ReadLine());

            int battlesLimit = int.Parse(Console.ReadLine());
                        
            double experienceGained = 0;

            int battlesCount = 0;

            bool isGained = false;

            for (int i = 1; i <= battlesLimit; i++)
            {
                double experiencePerBattle = double.Parse(Console.ReadLine()); 
                battlesCount++;

                if (i % 3 == 0)
                {
                    experienceGained += experiencePerBattle * 1.15;
                }
                else if (i % 5 == 0)
                {
                    experienceGained += experiencePerBattle * 0.90;
                }
                else if (i % 5 == 0 && i % 3 == 0)
                {
                    experienceGained += experiencePerBattle * 1.05;
                }
                else
                {
                    experienceGained += experiencePerBattle;
                }

                if (experienceGained >= experienceGoal)
                {
                    isGained = true;
                    break;
                }                           
            }

            if (isGained)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
            }
            else
            {
                double neededExperience = Math.Abs(experienceGained - experienceGoal);
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience:f2} more needed.");
            }
        }
    }
}