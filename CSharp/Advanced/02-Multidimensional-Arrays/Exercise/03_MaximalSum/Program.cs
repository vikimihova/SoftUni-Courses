namespace _03_MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int startingRow = 0;
            int startingCol = 0;
            int maxSum = int.MinValue;

            for (int row = 0;  row < rows - 2;  row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = 0;

                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            currentSum += matrix[i, j];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = startingRow; i < startingRow + 3; i++)
            {
                for (int j = startingCol; j < startingCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}