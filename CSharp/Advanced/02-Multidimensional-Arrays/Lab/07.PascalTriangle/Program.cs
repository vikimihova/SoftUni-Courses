namespace _07_PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                pascalTriangle[i] = new long[i + 1];
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    pascalTriangle[row][col] = 1;
                }
            }

            for (int row = 2; row < numberOfRows; row++)
            {
                for (int col = 1; col < pascalTriangle[row].Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
                }
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    Console.Write(pascalTriangle[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}