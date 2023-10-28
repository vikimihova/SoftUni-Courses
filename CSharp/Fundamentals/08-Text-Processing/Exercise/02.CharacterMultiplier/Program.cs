
namespace _02_CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input  = Console.ReadLine();                      

            string firstPart = input.Remove(input.IndexOf(" "));

            string secondPart = input.Substring(input.IndexOf(" ") + 1);

            int minLength = Math.Min(firstPart.Length, secondPart.Length);

            int sum = 0;
                        
            for (int i = 0; i < minLength; i++)
            {
                sum += firstPart[i] * secondPart[i];
            }

            if (firstPart.Length > minLength)
            {
                for (int i = minLength; i < firstPart.Length; i++)
                {
                    sum += firstPart[i];
                }
            }
            else if (secondPart.Length > minLength)
            {
                for (int i = minLength; i < secondPart.Length; i++)
                {
                    sum += secondPart[i];
                }
            }            

            Console.WriteLine(sum);
        }
    }
}