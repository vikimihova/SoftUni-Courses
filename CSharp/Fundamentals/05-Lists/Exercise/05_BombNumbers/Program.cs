namespace _05_BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> bombParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int bombNumber = bombParameters[0];
            int bombPower = bombParameters[1];

            while (numbers.Contains(bombNumber))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == bombNumber)
                    {
                        if (bombPower == 0)
                        {
                            numbers.Remove(bombNumber);
                        }
                        else
                        {
                            for (int j = 1; j <= bombPower; j++)
                            {
                                if (i + 1 < numbers.Count)
                                {
                                    numbers.RemoveAt(i + 1);
                                }

                                if (i - 1 >= 0)
                                {
                                    numbers.RemoveAt(i - 1);
                                    i--;
                                }
                            }

                            numbers.Remove(bombNumber);
                        }
                    }
                }
            }

            int sumOfRemainingNumbers = 0;

            foreach (int number in numbers)
            {
                sumOfRemainingNumbers += number;
            }

            Console.WriteLine(sumOfRemainingNumbers);
        }
    }
}