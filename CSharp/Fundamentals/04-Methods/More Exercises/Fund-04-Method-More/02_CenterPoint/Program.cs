namespace _02_CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] point1 = ReadPointCoordinates();
            int[] point2 = ReadPointCoordinates();

            PrintClosestPointToCenter(point1, point2);
        }

        static int[] ReadPointCoordinates()
        {
            int[] coordinates = new int[2];

            for (int i = 0; i < 2; i++)
            {
                coordinates[i] = int.Parse(Console.ReadLine());
            }

            return coordinates;
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
