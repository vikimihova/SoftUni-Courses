int numberOfRows = int.Parse(Console.ReadLine());

long[] lastRow = new long[numberOfRows];
lastRow[0] = 1;

for (int i = 1; i <= numberOfRows; i++)
{
    long[] currentRow = new long[i];
    currentRow[0] = 1;
    currentRow[i - 1] = 1;

    for (int j = 1; j < i - 1; j++)
    {
        currentRow[j] = lastRow[j] + lastRow[j - 1];
    }

    Console.WriteLine(string.Join(" ", currentRow));

    for (int k = 0; k < i; k++)
    {
        lastRow[k] = currentRow[k];
    }
}