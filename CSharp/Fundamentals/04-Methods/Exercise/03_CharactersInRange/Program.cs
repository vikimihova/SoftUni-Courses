namespace _03_CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());           

            int startValue = firstCharacter;
            int endValue = secondCharacter;            

            if (firstCharacter > secondCharacter)
            {
                startValue = secondCharacter;
                endValue = firstCharacter;
            }

            PrintCharactersInBetween(startValue, endValue);
            
        }

        static void PrintCharactersInBetween(int start, int end)
        {
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}