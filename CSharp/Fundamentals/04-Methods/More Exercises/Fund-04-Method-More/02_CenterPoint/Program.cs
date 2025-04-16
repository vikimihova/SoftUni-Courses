namespace _02_CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read the coordinates of the first point
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());

            // read the coordinates of the second point
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            PrintClosestPointToCenter(point1, point2);
        }

        }

        static void PrintClosestPointToCenter(int[] point1, int[] point2)
        {
            (int x1, int y1) = (point1[0], point1[1]);
            (int x2, int y2) = (point2[0], point2[1]);

            int absoluteDistance1 = Math.Abs(x1 + y1);
            int absoluteDistance2 = Math.Abs(x2 + y2);

            if (absoluteDistance1 <= absoluteDistance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
