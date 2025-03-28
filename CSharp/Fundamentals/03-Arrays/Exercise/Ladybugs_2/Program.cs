using System;
using System.Linq;


class Program
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[] field = new int[fieldSize];
        int[] initialPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < initialPositions.Length; i++)
        {
            if (initialPositions[i] >= 0 && initialPositions[i] < fieldSize)
                field[initialPositions[i]] = 1;
        }            

        string movement = Console.ReadLine();

        while (movement != "end")
        {
            string[] movementArray = movement.Split();
            int position = int.Parse(movementArray[0]);
            bool directionRight = movementArray[1] == "right";
            int distance = int.Parse(movementArray[2]);

            // Checking if the ladybug selection is valid
            if (position < 0 || position >= fieldSize || field[position] == 0 || distance == 0)
            {
                movement = Console.ReadLine();
                continue;
            }

            // Determining the new index for the ladybug
            int newLadybugLocation = position;
            if (directionRight) newLadybugLocation += distance;
            else newLadybugLocation -= distance;

            while (true)
            {
                if (newLadybugLocation < 0 || newLadybugLocation >= fieldSize) // Ladybug flies off the field
                {
                    field[position] = 0;
                    break;
                }

                else if (field[newLadybugLocation] == 0) // Swap old ladybug index with the new one
                {
                    field[newLadybugLocation] = 1;
                    field[position] = 0;
                    break;
                }

                // Determining new ladybug target index if this index is already occupied
                if (directionRight) newLadybugLocation += distance;
                else newLadybugLocation -= distance;
            }

            movement = Console.ReadLine();
        }

        // Output
        for (int i = 0; i < fieldSize; i++)
        {
            Console.Write(field[i] + " ");
        }
        Console.WriteLine();
    }
}