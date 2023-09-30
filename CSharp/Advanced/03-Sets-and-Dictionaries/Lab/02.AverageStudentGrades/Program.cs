namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] entry = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string student = entry[0];
                decimal grade = decimal.Parse(entry[1]);

                if (studentGrades.ContainsKey(student))
                {
                    studentGrades[student].Add(grade);
                }
                else
                {
                    studentGrades.Add(student, new List<decimal>());
                    studentGrades[student].Add(grade);
                }
            }

            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value.Select(grade => $"{grade:F2}"))} (avg: {kvp.Value.Average():F2})");
            }
        }
    }
}