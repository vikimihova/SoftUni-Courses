using System.Globalization;

namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> personAge = new();

            int numberOfEntries = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (!personAge.ContainsKey(name))
                {
                    personAge.Add(name, age);
                }
            }

            string inputCondition = Console.ReadLine();
            int threshold = int.Parse(Console.ReadLine());
            string inputFormat = Console.ReadLine();

            Func<int, bool> condition = DefineCondition(inputCondition, threshold);

            foreach (var (name, age) in personAge.Where(x => condition(x.Value)))
            {
                Console.WriteLine(DefineFormat(inputFormat, name, age));
            }
        }

        static Func<int, bool> DefineCondition(string inputCondition, int threshold)
        {
            Func<int, bool> condition = null;

            if (inputCondition == "younger")
            {
                condition = x => x < threshold;
            }
            else if (inputCondition == "older")
            {
                condition = x => x >= threshold;
            }

            return condition;
        }

        static string DefineFormat(string inputFormat, string name, int age)
        {
            string format = string.Empty;

            if (inputFormat == "name age")
            {
                format = name + " - " + age;
            }
            else if (inputFormat == "name")
            {
                format = name;
            }
            else if (inputFormat == "age")
            {
                format = age.ToString();
            }

            return format;
        }
    }
}