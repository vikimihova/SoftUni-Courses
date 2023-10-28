namespace _06_JaggedArrayModification
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

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArray = command.Split();

                int row = int.Parse(commandArray[1]);
                int col = int.Parse(commandArray[2]);
                int value = int.Parse(commandArray[3]);

                if (row < 0 || row >= rows - 1 || col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }

                if (commandArray.Contains("Add"))
                {
                    matrix[row][col] += value;
                }
                else if (commandArray.Contains ("Subtract"))
                {
                    matrix[row][col] -= value;
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