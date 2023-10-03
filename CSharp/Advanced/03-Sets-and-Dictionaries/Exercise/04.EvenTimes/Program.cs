namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(inputNumber))
                {
                    numbers[inputNumber]++;
                }
                else
                {
                    numbers.Add(inputNumber, 1);
                }
            }

            Console.WriteLine(numbers.Where(x => x.Value % 2 == 0).First().Key);
        }
    }
}