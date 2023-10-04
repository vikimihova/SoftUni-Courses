namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissionsPerLanguage = new();

            Dictionary<string, int> pointsPerStudent = new();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string student = tokens[0];

                if (tokens[1] == "banned" && pointsPerStudent.ContainsKey(student))
                {
                    pointsPerStudent.Remove(student);
                }
                else
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!pointsPerStudent.ContainsKey(student))
                    {
                        pointsPerStudent.Add(student, points);
                    }
                    else if (points > pointsPerStudent[student])
                    {
                        pointsPerStudent[student] = points;
                    }

                    if (submissionsPerLanguage.ContainsKey(language))
                    {
                        submissionsPerLanguage[language]++;
                    }
                    else
                    {
                        submissionsPerLanguage.Add(language, 1);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var (student, points) in pointsPerStudent.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student} | {points}");
            }

            Console.WriteLine("Submissions:");

            foreach (var (language, submissions) in submissionsPerLanguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language} - {submissions}");
            }
        }
    }
}