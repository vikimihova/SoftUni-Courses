namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => int.Parse(x))
                            .ToArray();

            Func<int[], int> numbersSum = x => x.Sum();

            Console.WriteLine(GetNumbersCount(numbers));
            Console.WriteLine(numbersSum(numbers));
        }

        static int GetNumbersCount(int[] array)
        {
            int count = 0;

            foreach (int number in array)
            {
                count++;
            }

            return count;
        }

        
    }
}