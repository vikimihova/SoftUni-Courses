namespace _01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> peoplePerWagon = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> command = input.Split(' ').ToList();

                if (command.Count == 2)
                {
                    peoplePerWagon.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < peoplePerWagon.Count; i++)
                    {
                        if (wagonCapacity - peoplePerWagon[i] >= int.Parse(command[0]))
                        {
                            peoplePerWagon[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", peoplePerWagon));
        }
    }
}