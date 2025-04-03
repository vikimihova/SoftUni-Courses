int numberOfStrings = int.Parse(Console.ReadLine());

int[] encryptedValues = new int[numberOfStrings]; 

for (int i = 0; i < numberOfStrings; i++)
{
    string input = Console.ReadLine();

    int length = input.Length;
    int encryption = 0;

    for (int j = 0; j < length; j++)
    {
        char letter = input[j];
        bool isVowel = "AEIOUaeiou".IndexOf(letter) >= 0;

        if (isVowel)
        {
            int vowelCode = letter * length;
            encryption += vowelCode;
        }
        else
        {
            int consonantCode = letter / length;
            encryption += consonantCode;
        }
    }

    encryptedValues[i] = encryption;
}

foreach (int encryptedValue in encryptedValues.Order())
{
    Console.WriteLine(encryptedValue);
}