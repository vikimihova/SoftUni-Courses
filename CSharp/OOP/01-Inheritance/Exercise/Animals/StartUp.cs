using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ").ToArray();

                if(animalInfo.Length != 3)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string name = animalInfo[0];

                int age;

                if (int.TryParse(animalInfo[1], out age))
                {
                    age = int.Parse(animalInfo[1]);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string gender = animalInfo[2];

                try
                {
                    if (animalType == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog.ToString());
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog.ToString());
                    }
                    else if (animalType == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat.ToString());
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age, gender);
                        Console.WriteLine(kitten.ToString());
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age, gender);
                        Console.WriteLine(tomcat.ToString());
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
