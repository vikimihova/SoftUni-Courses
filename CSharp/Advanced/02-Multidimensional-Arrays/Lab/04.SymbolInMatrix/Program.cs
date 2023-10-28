namespace _04_SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string rowInput = Console.ReadLine();
                char[] currentRow = rowInput.ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char wantedCharacter = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == wantedCharacter)
                    {
                        isFound = true;
                        Console.WriteLine($"({row}, {col})");
                        break;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{wantedCharacter} does not occur in the matrix");
            }
        }
    }
}