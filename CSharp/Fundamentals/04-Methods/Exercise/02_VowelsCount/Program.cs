namespace _02_VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintCountOfVowels(Console.ReadLine());
        }

        static void PrintCountOfVowels(string input)
        {
            string lowercase = input.ToLower();
            int vowelsCount = 0;            

            for (int i = 0; i < input.Length; i++)
            {
                if (lowercase[i] == 'a' || lowercase[i] == 'e' || lowercase[i] == 'i' || lowercase[i] == 'o' || lowercase[i] == 'u')
                {
                    vowelsCount++;
                }
            }

            Console.WriteLine(vowelsCount);
        }
    }
}