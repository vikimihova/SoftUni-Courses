namespace _05_Students2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] studentInfo = input.Split().ToArray();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string age = studentInfo[2];
                string hometown = studentInfo[3];

                bool isFound = false;

                foreach (Student student in students)
                {
                    if (student.FirstName == firstName && student.LastName == lastName)
                    {
                        isFound = true;
                        student.Age = age;
                        student.Hometown = hometown;
                    }
                }

                if (!isFound)
                {
                    students.Add(new Student(firstName, lastName, age, hometown));
                }                

                input = Console.ReadLine();
            }

            string printCommand = Console.ReadLine();

            List<Student> filteredStudents = students.Where(x => x.Hometown == printCommand).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }

        }

        public class Student
        {
            public Student(string firstName, string lastName, string age, string hometown)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Hometown = hometown;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set; }
            public string Hometown { get; set; }
        }
    }
}