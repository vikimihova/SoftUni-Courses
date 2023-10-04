namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());

            Dictionary<int, int> countByNumbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (countByNumbers.ContainsKey(inputNumber))
                {
                    countByNumbers[inputNumber]++;
                }
                else
                {
                    countByNumbers.Add(inputNumber, 1);
                }
            }

            Console.WriteLine(countByNumbers.Where(x => x.Value % 2 == 0).First().Key);
        }
    }
}