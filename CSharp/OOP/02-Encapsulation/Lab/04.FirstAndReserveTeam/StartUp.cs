namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new("SoftUni");

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
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}