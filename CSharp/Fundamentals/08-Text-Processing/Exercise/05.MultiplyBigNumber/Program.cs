using System.Linq;
using System.Text;

namespace _05_MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            char[] bigNumberArray = bigNumber.ToCharArray();

            int smallNumber = int.Parse(Console.ReadLine());

            int[] result = new int[bigNumber.Length + 1];

            if (smallNumber == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = bigNumber.Length - 1; i >= 0; i--)
                {
                    int currentResult = int.Parse(bigNumberArray[i].ToString()) * smallNumber;

                    result[i + 1] += currentResult % 10;
                    result[i] += currentResult / 10;

                    if (result[i + 1] >= 10)
                    {
                        result[i] += result[i + 1] / 10;
                        result[i + 1] %= 10;
                    }
                }
                                
                if (result[0] == 0)
                {
                    for (int i = 1; i < result.Length; i++)
                    {
                        Console.Write(result[i]);
                    }
                }
                else
                {
                    foreach (int number in result)
                    {
                        Console.Write(number);
                    }
                }
            }            
        }
    }
}