namespace _06_StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gradeBook = new Dictionary<string, List<double>>();

            int rowPairs = int.Parse(Console.ReadLine());

            string currentStudent = string.Empty;

            for (int i = 0; i < rowPairs; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradeBook.ContainsKey(student))
                {
                    gradeBook.Add(student, new List<double>());                    
                }

                gradeBook[student].Add(grade);               
            }

            foreach (var student in gradeBook.Where(x => x.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
               
            }
        }
    }
}