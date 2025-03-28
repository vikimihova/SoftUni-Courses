namespace _06_TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i < (97 + n); i++)
            {  
                char char1 = (char)i;

                for (int j = 97; j < (97 + n); j++)
                {
                    char char2 = (char)j;

                    for (int k = 97; k < (97 + n); k++)
                    {
                        char char3 = (char)k;

                        Console.WriteLine($"{char1}{char2}{char3}");
                    }
                }
            }

        }
    }
}