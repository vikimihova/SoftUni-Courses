using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            uint age = uint.Parse(Console.ReadLine());

            Person first = new Person(name, age);
            Child second = new Child(name, age);

            Console.WriteLine(first.ToString());
        }
    }
}