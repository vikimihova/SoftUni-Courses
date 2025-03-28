namespace _10_LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] initialSlots = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < initialSlots.Length; i++)
            {
                if (initialSlots[i] >= 0 && initialSlots[i] < fieldSize)
                {
                    field[initialSlots[i]] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] movement = command.Split();

                int slot = int.Parse(movement[0]);
                string direction = movement[1];
                int distance = int.Parse(movement[2]);

                if (slot >= 0 && slot < field.Length && field[slot] != 0)
                {
                    field[slot] = 0;

                    if (direction == "right") /*&& distance >= 0) || (direction == "left" && distance < 0))*/
                    {
                        for (int i = slot; i < field.Length; i++)
                        {
                            int newSlot = i + distance;
                            if (newSlot >= field.Length || newSlot < 0)
                            {
                                break;
                            }
                            else if (field[newSlot] != 1)
                            {                                
                                field[newSlot] = 1;                                
                                break;
                            }
                        }
                    }
                    else if (direction == "left")  /*&& distance >= 0) || (direction == "right" && distance < 0))*/
                    {
                        for (int i = slot; i >= 0; i--)
                        {
                            int newSlot = i - distance;
                            if (newSlot < 0 || newSlot >= field.Length)
                            {
                                break;
                            }
                            else if (field[newSlot] != 1)
                            {                                
                                field[newSlot] = 1;                                
                                break;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}