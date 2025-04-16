namespace _03_LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] point1 = ReadPointCoordinates();
            int[] point2 = ReadPointCoordinates();
            int[] point3 = ReadPointCoordinates();
            int[] point4 = ReadPointCoordinates();       

            int firstLineLength = GetLength(point1, point2);
            int secondLineLength = GetLength(point3, point4);

            if (firstLineLength >= secondLineLength)
            {
                PrintLineCoordinates(point1, point2);
            }
            else
            {
                PrintLineCoordinates(point3, point4);
            }            
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

        static void PrintLineCoordinates(int[] point1, int[] point2)
        {
            (int x1, int y1) = (point1[0], point1[1]);
            (int x2, int y2) = (point2[0], point2[1]);

            int absoluteDistance1 = Math.Abs(x1 + y1);
            int absoluteDistance2 = Math.Abs(x2 + y2);

            if (absoluteDistance1 <= absoluteDistance2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }

        static int GetLength(int[] point1, int[] point2)
        {
            (int x1, int y1) = (point1[0], point1[1]);
            (int x2, int y2) = (point2[0], point2[1]);

            int relativeDistance1 = x1 + y1;
            int relativeDistance2 = x2 + y2;

            int nearPoint = Math.Min(relativeDistance1, relativeDistance2);
            int farPoint = Math.Max(relativeDistance1, relativeDistance2);

            return farPoint - nearPoint;
        }        
    }
}
