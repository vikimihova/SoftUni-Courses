﻿namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person("Peter", 20);
            Person george = new Person("George", 18);

            Person jose = new Person();

            jose.Name = "Jose";
            jose.Age = 43;
        }
    }
}