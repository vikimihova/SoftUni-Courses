namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Person> people = new();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = personInfo[0];
                string lastName = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Person newPerson = new Person(firstName, lastName, age);

                people.Add(newPerson);
            }

            foreach (Person person in people.OrderBy(x => x.FirstName)
                                            .ThenBy(x => x.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}