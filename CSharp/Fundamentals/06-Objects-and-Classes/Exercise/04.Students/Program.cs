using System.Collections.Generic;
using System.Diagnostics;

namespace _04_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentInfo = Console.ReadLine().Split().ToArray();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                float grade = float.Parse(studentInfo[2]);

                students.Add(new Student(firstName, lastName, grade));
            }

            foreach (Student student in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }

        public class Student
        {
            public Student(string firstName, string lastName, float grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public float Grade { get; set; }
        }
    }
}