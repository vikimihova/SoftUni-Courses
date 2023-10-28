namespace _06_JaggedArraysManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArray = command.Split();

                int row = int.Parse(commandArray[1]);
                int col = int.Parse(commandArray[2]);
                int value = int.Parse(commandArray[3]);

                if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                {
                    if (commandArray.Contains("Add"))
                    {
                        matrix[row][col] += value;
                    }
                    else if (commandArray.Contains("Subtract"))
                    {
                        matrix[row][col] -= value;
                    }
                }             

                command = Console.ReadLine();
            }

            foreach (int[] row in matrix)
            {
                for (int col = 0; col < row.Length; col++)
                {
                    Console.Write(row[col] + " ");
                }

                Console.WriteLine();
            }
        }
    }    
}