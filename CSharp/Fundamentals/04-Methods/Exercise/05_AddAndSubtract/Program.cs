namespace _05_AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int resultAddition = AddNum1AndNum2(num1, num2);
            int finalResult = SubtractNum3FromResult(resultAddition, num3);
            Console.WriteLine(finalResult);
        }

        static int AddNum1AndNum2(int number1, int number2)
        {
            return number1 + number2;
        }

        static int SubtractNum3FromResult(int result, int thirdNum)
        {
            return result - thirdNum;
        }
    }
}