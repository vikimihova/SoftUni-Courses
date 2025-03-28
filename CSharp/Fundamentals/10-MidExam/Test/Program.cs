namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxValueOfTwo = Math.Max(5, 8);
            Console.WriteLine(maxValueOfTwo);

            double maxValueOfThree = Math.MaxMagnitude(3.5, 5);
            Console.WriteLine(maxValueOfThree);

        }
    }
}