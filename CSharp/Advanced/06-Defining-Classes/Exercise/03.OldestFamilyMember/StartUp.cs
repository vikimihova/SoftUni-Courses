using System.Net.Http.Headers;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            family.Members = new List<Person>();

            int numberOfMembers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfMembers; i++)
            {
                string[] memberInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                Person member = new Person(name, age);

                family.AddMember(member);
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}