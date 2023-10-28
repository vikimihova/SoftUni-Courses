namespace _04_MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArray.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (commandArray[0] != "swap"
                    || int.Parse(commandArray[1]) < 0
                    || int.Parse(commandArray[1]) > rows - 1
                    || int.Parse(commandArray[3]) < 0
                    || int.Parse(commandArray[3]) > rows - 1
                    || int.Parse(commandArray[2]) < 0
                    || int.Parse(commandArray[2]) > cols - 1
                    || int.Parse(commandArray[4]) < 0
                    || int.Parse(commandArray[4]) > cols - 1)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(commandArray[1]);
                    int col1 = int.Parse(commandArray[2]);

                    int row2 = int.Parse(commandArray[3]);
                    int col2 = int.Parse(commandArray[4]);

                    string value1 = matrix[row1, col1];
                    string value2 = matrix[row2, col2];

                    matrix[row1, col1] = value2;
                    matrix[row2, col2] = value1;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }

                        Console.WriteLine();
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}