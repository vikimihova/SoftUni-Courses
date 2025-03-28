namespace _08_FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factorial1 = FindFactorial(num1);
            double factorial2 = FindFactorial(num2);

            double finalResult = factorial1 / factorial2;

            Console.WriteLine($"{finalResult:f2}");
        }

        static double FindFactorial(int number)
        {
            double product = 1;

            for (int i = 2; i <= number; i++)
            {
                product *= i;
            }
            return product;
        }
    }
}