using System.Data;

namespace _08_Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] bombCoordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] bomb = bombCoordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = bomb[0];
                int col = bomb[1];

                int damage = matrix[row, col];

                if (damage <= 0)
                {
                    continue;
                }
                else
                {
                    matrix[row, col] = 0;

                    if (row > 0 && matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= damage;
                    }

                    if (row < matrixSize - 1 && matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= damage;
                    }

                    if (col > 0 && matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= damage;
                    }

                    if (col < matrixSize - 1 && matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= damage;
                    }

                    if (row > 0 && col > 0 && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= damage;
                    }

                    if (row < matrixSize - 1 && col < matrixSize - 1 && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= damage;
                    }

                    if (row > 0 && col < matrixSize - 1 && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= damage;
                    }

                    if (row < matrixSize - 1 && col > 0 && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= damage;
                    }
                }                
            }

            int aliveCells = 0;
            int aliveCellsSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}