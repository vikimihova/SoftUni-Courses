using System.Linq;

namespace _05_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] information = inputLine.Split(" : ");
                string course = information[0];
                string student = information[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                    courses[course].Add(student);
                }
                else
                {
                    courses[course].Add(student);
                }

                inputLine = Console.ReadLine();
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}