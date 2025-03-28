namespace _07_MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            
            int longestSequenceCount = 0;            
            string longestSequenceOfEqualElements = String.Empty;            

            for (int i = 0; i < array.Length - 1; i++)
            {         
                if (array[i] == array[i + 1])
                {
                    string sequenceOfEqualElements = array[i] + " " + array[i + 1];
                    int sequenceCount = 2;

                    for (int j = i + 2; j < array.Length; j++)
                    {     
                        if (array[i] == array[j])
                        {
                            sequenceCount++;
                            sequenceOfEqualElements += " " + array[j];
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (sequenceCount > longestSequenceCount)
                    {
                        longestSequenceCount = sequenceCount;
                        longestSequenceOfEqualElements = sequenceOfEqualElements;
                    }
                }
                else
                {
                    continue;
                }                
            }

            Console.WriteLine(longestSequenceOfEqualElements);
        }
    }
}