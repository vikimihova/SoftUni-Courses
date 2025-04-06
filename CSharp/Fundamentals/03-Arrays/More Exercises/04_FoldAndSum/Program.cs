int[] array = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rowLength = array.Length / 2;
int numbersToFold = array.Length / 4;

int[] topRow = new int[rowLength];
int[] bottomRow = new int[rowLength];
int[] resultRow = new int[rowLength];

for (int i = 0; i < rowLength; i++)
{
    int stayIndex = numbersToFold + i;
    int foldIndex = numbersToFold - i - 1;

    if (foldIndex < 0)
    {
        foldIndex += array.Length;
    }

    topRow[i] = array[foldIndex];
    bottomRow[i] = array[stayIndex];

    resultRow[i] = topRow[i] + bottomRow[i];
}

Console.WriteLine(string.Join(" ", resultRow));