int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

// for each position find the current count and the last valid index in an increasing sequence of numbers
int[] sequenceCount = new int[numbers.Length];
int[] precedingIndices = new int[numbers.Length];

for (int current = 0; current < numbers.Length; current++)
{
    // initiate the sequence   
    if (current == 0)
    {
        sequenceCount[current] = 1;
        precedingIndices[current] = -1;
        continue;
    }

    // compare the current number to the preceding one
    int preceding = current - 1;

    if (numbers[current] > numbers[preceding])
    {
        sequenceCount[current] = sequenceCount[preceding] + 1;
        precedingIndices[current] = preceding;
    }
    else
    {
        // proceed to compare the current number to the ones that come before
        bool isInsertedInSequence = false;

        for (;  preceding > 0; preceding--)
        {
            // reach a position to fit in the current number and continue with the next one
            if (numbers[current] <= numbers[preceding] && numbers[current] > numbers[preceding - 1])
            {
                sequenceCount[current] = sequenceCount[preceding];
                precedingIndices[current] = preceding - 1;

                isInsertedInSequence = true;
                break;
            }            
        }

        // else, restart sequence count and last index
        if (isInsertedInSequence == false)
        {
            sequenceCount[current] = 1;
            precedingIndices[current] = -1;
        }
    }    
}

int longestCount = sequenceCount.Max();
int rightmostIndex = Array.IndexOf(sequenceCount, longestCount);

int[] longestSequence = new int[longestCount];

// find all numbers, starting with the highest (rightmost) one
for (int i = longestCount - 1; i >= 0; i--)
{
    int number = numbers[rightmostIndex];
    longestSequence[i] = number;

    rightmostIndex = precedingIndices[rightmostIndex];
}

//Console.WriteLine(string.Join(" ", sequenceCount));
//Console.WriteLine(string.Join(" ", precedingIndices));
Console.WriteLine(string.Join(" ", longestSequence));