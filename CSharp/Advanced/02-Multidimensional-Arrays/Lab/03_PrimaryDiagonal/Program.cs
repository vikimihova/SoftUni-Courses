namespace _03_PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int diagonalSum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                diagonalSum += matrix[i, i];
            }

            Console.WriteLine(diagonalSum);
        }
    }
}