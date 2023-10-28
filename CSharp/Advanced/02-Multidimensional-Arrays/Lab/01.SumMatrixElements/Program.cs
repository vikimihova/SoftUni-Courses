namespace _01_SumMatrixElements
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

            int sumOfAllElements = 0;

            foreach (var element in matrix)
            {
                sumOfAllElements += element;
            }

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sumOfAllElements);
        }
    }
}