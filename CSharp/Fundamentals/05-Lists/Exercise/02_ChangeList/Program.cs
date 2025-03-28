namespace _02_ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> command = input.Split(' ').ToList();

                if (command.Count == 2)
                {
                    int element = int.Parse(command[1]);

                    while (numbers.Contains(element))
                    {
                        numbers.Remove(element);
                    }
                }
                else
                {
                    int element = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    numbers.Insert(index, element);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}