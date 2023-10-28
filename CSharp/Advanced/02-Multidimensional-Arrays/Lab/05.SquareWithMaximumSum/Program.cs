namespace _05_SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSquareRow = 0;
            int maxSquareCol = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSquareRow = row;
                        maxSquareCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxSquareRow, maxSquareCol]} {matrix[maxSquareRow, maxSquareCol + 1]}");
            Console.WriteLine($"{matrix[maxSquareRow + 1, maxSquareCol]} {matrix[maxSquareRow + 1, maxSquareCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}