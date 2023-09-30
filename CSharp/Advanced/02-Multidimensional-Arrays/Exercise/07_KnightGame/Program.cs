using static System.Net.Mime.MediaTypeNames;

namespace _07_KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[,] board = new char[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = currentRow[col];
                }
            }

            int knightCounter = 0;

            if (boardSize < 3)
            {
                knightCounter = 0;
                Console.WriteLine(knightCounter);
                return;
            }

            while (true)
            {
                int maxAttacks = 0;
                int maxAttackRow = 0;
                int maxAttackCol = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attacksCounter = 0;

                            if (row > 1 && col > 0 && board[row - 2, col - 1] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row > 1 && col < boardSize - 1 && board[row - 2, col + 1] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row > 0 && col > 1 && board[row - 1, col - 2] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row < boardSize - 1 && col > 1 && board[row + 1, col - 2] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row < boardSize - 2 && col > 0 && board[row + 2, col - 1] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row < boardSize - 2 && col < boardSize - 1 && board[row + 2, col + 1] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row < boardSize - 1 && col < boardSize - 2 && board[row + 1, col + 2] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (row > 0 && col < boardSize - 2 && board[row - 1, col + 2] == 'K')
                            {
                                attacksCounter++;
                            }

                            if (attacksCounter > maxAttacks)
                            {
                                maxAttacks = attacksCounter;
                                maxAttackRow = row;
                                maxAttackCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    board[maxAttackRow, maxAttackCol] = '0';
                    knightCounter++;
                }
                else
                {
                    break;
                }                
            }

            Console.WriteLine(knightCounter);
        }
    }
}