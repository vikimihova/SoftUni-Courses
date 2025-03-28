namespace _09_KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int longestSequenceOf1 = 0;
            int leftmostIndex = 0;
            int greatestSequenceSum = 0;

            int sequenceIndex = 0;
            int bestSequenceIndex = 0;

            int[] bestSequence = new int[sequenceLength];


            while (input != "Clone them!")
            {
                int[] inputSequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                sequenceIndex++;
                int sequenceSum = 0;

                for (int i = 0; i < inputSequence.Length; i++)
                {
                    sequenceSum += inputSequence[i];
                }

                if (sequenceLength == 1)
                {
                    if (greatestSequenceSum < sequenceSum)
                    {
                        greatestSequenceSum = sequenceSum;
                        bestSequenceIndex = sequenceIndex;
                        bestSequence = inputSequence;
                    }
                }
                else
                {
                    for (int i = 0; i < inputSequence.Length - 1; i++)
                    {
                        if (inputSequence[i] == 1)
                        {
                            int sequenceOfOnes = 1;

                            for (int j = i + 1; j < inputSequence.Length; j++)
                            {
                                if (inputSequence[i] == inputSequence[j])
                                {
                                    sequenceOfOnes++;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if ((sequenceOfOnes > longestSequenceOf1) || 
                                (sequenceOfOnes == longestSequenceOf1 && i < leftmostIndex) || 
                                (sequenceOfOnes == longestSequenceOf1 && i == leftmostIndex && sequenceSum > greatestSequenceSum))
                            {
                                leftmostIndex = i;
                                longestSequenceOf1 = sequenceOfOnes;
                                greatestSequenceSum = sequenceSum;
                                bestSequenceIndex = sequenceIndex;
                                bestSequence = inputSequence;
                            }    
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            if (greatestSequenceSum == 0)
            {
                bestSequenceIndex = 1;
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {greatestSequenceSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}