int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

int tempMax = Math.Max(a, b);
int tempMin = Math.Min(a, b);

int maxNumber = Math.Max(tempMax, c);
int minNumber = Math.Min(tempMin, c);
int midNumber;

if (maxNumber == c)
{
    midNumber = tempMax;
}
else
{
    midNumber = Math.Max(tempMin, c);
}

Console.WriteLine(maxNumber);
Console.WriteLine(midNumber);
Console.WriteLine(minNumber);


 
