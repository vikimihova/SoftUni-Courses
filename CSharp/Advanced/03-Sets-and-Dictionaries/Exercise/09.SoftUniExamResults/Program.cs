namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languageSubmissionsPair = new();

            Dictionary<string, int> studentPointsPair = new();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] contents = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string student = contents[0];

                if (contents[1] == "banned" && studentPointsPair.ContainsKey(student))
                {
                    studentPointsPair.Remove(student);
                }
                else
                {
                    string language = contents[1];
                    int points = int.Parse(contents[2]);

                    if (!studentPointsPair.ContainsKey(student))
                    {
                        studentPointsPair.Add(student, points);
                    }
                    else if (points > studentPointsPair[student])
                    {
                        studentPointsPair[student] = points;
                    }

                    if (languageSubmissionsPair.ContainsKey(language))
                    {
                        languageSubmissionsPair[language]++;
                    }
                    else
                    {
                        languageSubmissionsPair.Add(language, 1);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var (student, points) in studentPointsPair.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student} | {points}");
            }

            Console.WriteLine("Submissions:");

            foreach (var (language, submissions) in languageSubmissionsPair.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language} - {submissions}");
            }
        }
    }
}