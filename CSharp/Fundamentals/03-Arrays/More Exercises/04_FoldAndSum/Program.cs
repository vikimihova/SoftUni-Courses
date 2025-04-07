int[] unfoldedArray = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rowLength = unfoldedArray.Length / 2;
int numbersToFold = rowLength / 2;

int[] topRow = new int[rowLength];
int[] bottomRow = new int[rowLength];
int[] productRow = new int[rowLength];

for (int i = 0; i < rowLength; i++)
{
    int leaveIndex = numbersToFold + i;
    int foldIndex = numbersToFold - i - 1;

    if (foldIndex < 0)
    {
        foldIndex += unfoldedArray.Length;
    }

    topRow[i] = unfoldedArray[foldIndex];
    bottomRow[i] = unfoldedArray[leaveIndex];

    productRow[i] = topRow[i] + bottomRow[i];
}

Console.WriteLine(string.Join(" ", productRow));