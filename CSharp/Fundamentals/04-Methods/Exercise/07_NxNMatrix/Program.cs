namespace _07_NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                PrintASingleLine(number);
                Console.WriteLine();
            }
        }

        static void PrintASingleLine(int number)
        {
            for (int i = 0;i < number; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}