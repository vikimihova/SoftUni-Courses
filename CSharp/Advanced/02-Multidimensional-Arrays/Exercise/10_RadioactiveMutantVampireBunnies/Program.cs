namespace _10_RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lairDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = lairDimensions[0];
            int cols = lairDimensions[1];

            char[,] lair = new char[rows, cols];

            int playerCurrentRow = 0;
            int playerCurrentCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        playerCurrentRow = row;
                        playerCurrentCol = col;
                    }
                }
            }

            lair[playerCurrentRow, playerCurrentCol] = '.';

            string commands = Console.ReadLine();

            bool isWinner = false;
            bool gameOver = false;

            for (int i = 0; i < commands.Length && !isWinner && !gameOver; i++)
            {
                char currentCommand = commands[i];

                if (currentCommand == 'L' && playerCurrentCol > 0)
                {
                    playerCurrentCol--;
                }
                else if (currentCommand == 'R' && playerCurrentCol < cols - 1)
                {
                    playerCurrentCol++;
                }
                else if (currentCommand == 'U' && playerCurrentRow > 0)
                {
                    playerCurrentRow--;
                }
                else if (currentCommand == 'D' && playerCurrentRow < rows - 1)
                {
                    playerCurrentRow++;
                }
                else
                {
                    isWinner = true;
                }

                List<int[]> bunnyCoordinates = new List<int[]>();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            int[] currentBunny = new int[2];
                            currentBunny[0] = row;
                            currentBunny[1] = col;

                            bunnyCoordinates.Add(currentBunny);
                        }
                    }
                }

                foreach (var bunny in bunnyCoordinates)
                {
                    if (bunny[0] > 0)
                    {
                        lair[bunny[0] - 1, bunny[1]] = 'B';
                    }

                    if (bunny[0] < rows - 1)
                    {
                        lair[bunny[0] + 1, bunny[1]] = 'B';
                    }

                    if (bunny[1] > 0)
                    {
                        lair[bunny[0], bunny[1] - 1] = 'B';
                    }

                    if (bunny[1] < cols - 1)
                    {
                        lair[bunny[0], bunny[1] + 1] = 'B';
                    }
                }

                if (lair[playerCurrentRow, playerCurrentCol] == 'B' && !isWinner)
                {
                    gameOver = true;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }

            if (gameOver)
            {
                Console.WriteLine($"dead: {playerCurrentRow} {playerCurrentCol}");
            }
            else if (isWinner)
            {
                Console.WriteLine($"won: {playerCurrentRow} {playerCurrentCol}");
            }
        }
    }
}