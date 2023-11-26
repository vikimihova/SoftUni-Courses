namespace _01.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box newBox = new(length, width, height);

                Console.WriteLine($"Surface Area - {newBox.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {newBox.Volume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine (ex.Message);
            }            
        }
    }
}