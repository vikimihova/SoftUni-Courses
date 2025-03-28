namespace _03_Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int numberOfCourses = 0;

            if (numberOfPeople % elevatorCapacity == 0)
            {
                Console.WriteLine(numberOfPeople / elevatorCapacity);
            }
            else
            {
                Console.Write(numberOfPeople / elevatorCapacity + 1);
            }
        }
    }
}