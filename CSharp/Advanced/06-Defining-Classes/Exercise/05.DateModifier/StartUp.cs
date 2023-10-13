namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifferenceInDays(startDate, endDate));
        }
    }
}