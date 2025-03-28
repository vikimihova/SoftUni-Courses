namespace _06_EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumLeft = 0;
            int sumRight = 0;

            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sumLeft += array[j];
                }

                for (int j = i + 1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }

                if (sumLeft == sumRight)
                {
                    isFound = true;
                    Console.WriteLine(i);
                }

                sumLeft = 0;
                sumRight = 0;
            }

            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}