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
                decimal salary = decimal.Parse(personInfo[3]);

                Person newPerson = new Person(firstName, lastName, age, salary);

                people.Add(newPerson);
            }

            decimal bonusPercentage = decimal.Parse(Console.ReadLine());
            

            foreach (Person person in people)
            {
                person.IncreaseSalary(bonusPercentage);

                Console.WriteLine(person);
            }
        }
    }
}