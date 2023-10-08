namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            Func<int, int> operation = null;
            Action<List<int>> printer = x => Console.WriteLine(string.Join(" ", x));

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "print")
                {
                    printer(numbers);
                }
                else
                {
                    operation = DefineOperation(input);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = operation(numbers[i]);
                    }
                }

                input = Console.ReadLine();
            }
        }

        static Func<int, int> DefineOperation(string input)
        {
            Func<int, int> operation = null;

            if (input == "add")
            {
                operation = x => x + 1;
            }
            else if (input == "multiply")
            {
                operation = x => x * 2;
            }
            else if (input == "subtract")
            {
                operation = x => x - 1;
            }

            return operation;
        }
    }
}