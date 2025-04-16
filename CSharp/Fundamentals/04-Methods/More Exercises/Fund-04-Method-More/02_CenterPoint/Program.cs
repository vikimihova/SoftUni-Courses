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

            Console.WriteLine(GetClosestCoordinatesToCenter(x1, y1, x2, y2));
        }

        static string GetClosestCoordinatesToCenter(int x1, int y1, int x2, int y2)
        {
            int absoluteDistance1 = Math.Abs(x1 + y1);
            int absoluteDistance2 = Math.Abs(x2 + y2);

            if (absoluteDistance1 <= absoluteDistance2)
            {
                return $"({x1}, {y1})";
            }
            else
            {
                return $"({x2}, {y2})";
            }
        }
    }
}
