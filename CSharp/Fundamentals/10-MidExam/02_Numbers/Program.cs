namespace _02_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();            

            while (command != "Finish")
            {
                string[] commandContent = command.Split().ToArray();

                if (commandContent[0] == "Add")
                {
                    numbers.Add(int.Parse(commandContent[1]));
                }
                else if (commandContent[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandContent[1]));
                }
                else if (commandContent[0] == "Replace")
                {
                    int value = int.Parse(commandContent[1]);
                    int replacement = int.Parse(commandContent[2]);
                    int index = 0;

                    if (numbers.Contains(value))
                    {
                        index = numbers.IndexOf(value);
                    }

                    numbers.Remove(value);
                    numbers.Insert(index, replacement);
                }
                else if (commandContent[0] == "Collapse")
                {
                    int value = int.Parse(commandContent[1]);
                   
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < value)
                        {
                            numbers.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}