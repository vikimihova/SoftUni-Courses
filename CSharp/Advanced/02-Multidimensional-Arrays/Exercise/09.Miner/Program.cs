namespace _09_Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldLength = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldLength, fieldLength];

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int coalReserve = 0;
            int coalCollected = 0;

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < fieldLength; row++)
            {
                char[] currentFieldRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < fieldLength; col++)
                {
                    field[row, col] = currentFieldRow[col];

                    if (field[row, col] == 'c')
                    {
                        coalReserve++;
                    }

                    if (field[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                if (currentCommand == "up" && currentRow > 0)
                {
                    currentRow--;
                }
                else if (currentCommand == "down" && currentRow < fieldLength - 1)
                {
                    currentRow++;
                }
                else if (currentCommand == "left" && currentCol > 0)
                {
                    currentCol--;
                }
                else if (currentCommand == "right" && currentCol < fieldLength - 1)
                {
                    currentCol++;
                }

                if (field[currentRow, currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }

                if (field[currentRow, currentCol] == 'c')
                {
                    coalReserve--;
                    coalCollected++;

                    field[currentRow, currentCol] = '*';

                    if (coalReserve == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{coalReserve} coals left. ({currentRow}, {currentCol})");
        }
    }
}