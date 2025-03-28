using System.Xml.Linq;

namespace _04_ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                List<string> commandContent = command.Split(' ').ToList();

                if (commandContent.Contains("Add"))
                {
                    int element = int.Parse(commandContent[1]);
                    numbers.Add(element);
                }

                if (commandContent.Contains("Insert"))
                {
                    int element = int.Parse(commandContent[1]);
                    int index = int.Parse(commandContent[2]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, element);
                    }                    
                }

                if (commandContent.Contains("Remove"))
                {
                    int index = int.Parse(commandContent[1]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }                    
                }

                if (commandContent.Contains("left"))
                {
                    int count = int.Parse(commandContent[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int firstNumber = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(firstNumber);
                    }                    
                }

                if (commandContent.Contains("right"))
                {
                    int count = int.Parse(commandContent[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int lastNumber = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, lastNumber);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}