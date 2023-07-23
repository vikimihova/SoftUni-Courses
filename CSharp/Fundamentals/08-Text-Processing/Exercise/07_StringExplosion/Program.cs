using System.Globalization;
using System.Text;

namespace _07_StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            int accumulatedPower = 0;

            for (int i = 0; i < sequence.Length - 1; i++)
            {                
                if (sequence[i] == '>')
                {                    
                    int power = int.Parse(sequence.Substring(i + 1, 1)) + accumulatedPower;

                    string remainingSequence = sequence.Substring(i + 1);
                    int nextExplosionIndex = remainingSequence.IndexOf('>');

                    if (nextExplosionIndex <= power - 1 && nextExplosionIndex >= 0)
                    {
                        accumulatedPower = power - nextExplosionIndex;
                        power = nextExplosionIndex;                        
                    }
                    else if (remainingSequence.Length < power)
                    {
                        power = remainingSequence.Length;
                    }
                    
                    sequence = sequence.Remove(i + 1, power);
                }
            }

            Console.WriteLine(sequence);
        }
    }
}