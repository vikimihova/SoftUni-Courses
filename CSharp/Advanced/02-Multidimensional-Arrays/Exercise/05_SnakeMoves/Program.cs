namespace _05_SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixSize = Console.ReadLine().Split();

            int rows = int.Parse(matrixSize[0]);
            int cols = int.Parse(matrixSize[1]);

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            Queue<char> snakeBody = new Queue<char>(snake);

            int charCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakeBody.Dequeue();
                        snakeBody.Enqueue(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeBody.Dequeue();
                        snakeBody.Enqueue(matrix[row, col]);
                    }
                }                
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}