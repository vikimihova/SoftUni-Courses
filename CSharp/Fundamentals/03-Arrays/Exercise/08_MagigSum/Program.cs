namespace _08_MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int predefinedSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == predefinedSum)
                    {
                        Console.WriteLine(string.Join(" ", array[i], array[j]));
                    }
                }
            }
        }
    }
}