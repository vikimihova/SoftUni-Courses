namespace _01_DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string value = Console.ReadLine();

            if (type == "int")
            {
                int number = int.Parse(value);
                Console.WriteLine(GetResult(number));
            }

            if (type == "real")
            {
                double realNumber = double.Parse(value);
                Console.WriteLine(GetResult(realNumber));

            }

            if (type == "string")
            {
                Console.WriteLine(GetResult(value));
            }      
        }

        static string GetResult(int number)
        {
            int result = number * 2;
            return result.ToString();
        }

        static string GetResult(double realNumber)
        {
            double result = realNumber * 1.5;
            return result.ToString("F2");
        }

        static string GetResult(string text)
        {
            return "$" + text + "$";
        }
    }
}
