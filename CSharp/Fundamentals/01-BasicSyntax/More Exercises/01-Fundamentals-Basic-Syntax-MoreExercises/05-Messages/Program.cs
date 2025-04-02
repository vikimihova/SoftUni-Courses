using System.Text;

StringBuilder message = new StringBuilder();
string input;

while ((input = Console.ReadLine()) != String.Empty)
{
    int digit = int.Parse(input) % 10;

    if (digit == 0)
    {
        message.Append(' ');
        continue;
    }

    if (digit == 1)
    {
        continue;
    }

    int digitCount = input.Length;
    int indexOffset = 0;

    if (digit >= 2 && digit <= 7)
    {
        indexOffset = (digit - 2) * 3;
    }
    else if (digit >= 8)
    {
        indexOffset = (digit - 2) * 3 + 1;
    }

    int index = indexOffset + digitCount - 1;

    message.Append((char)(97 + index));
}

Console.WriteLine(message.ToString());