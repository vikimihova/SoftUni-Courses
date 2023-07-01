namespace _07_OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] personInformation = inputLine.Split();
                string name = personInformation[0];
                string id = personInformation[1];
                int age = int.Parse(personInformation[2]);

                bool isFound = false;
                                
                foreach (Person person in people)
                {
                    if (person.Id == id)
                    {
                        person.Name = name;
                        person.Age = age;
                        isFound = true;
                        break;
                    }                   
                }
                
                if (!isFound)
                {
                    Person newPerson = new Person(name, id, age);
                    people.Add(newPerson);
                }                

                inputLine = Console.ReadLine();
            }

            foreach (Person person in people.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }

        public class Person
        {
            public Person(string name, string id, int age)
            {
                Name = name;
                Id = id;
                Age = age;
            }

            public string Name { get; set; }
            public string Id { get; set; }
            public int Age { get; set; }
        }
    }
}