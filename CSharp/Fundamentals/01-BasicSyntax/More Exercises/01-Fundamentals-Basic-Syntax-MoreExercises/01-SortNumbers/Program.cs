int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

int maxNumber = Math.Max(Math.Max(a, b), c);
int minNumber = Math.Min(Math.Min(a, b), c);
int midNumber = a + b + c - maxNumber - minNumber;

Console.WriteLine(maxNumber);
Console.WriteLine(midNumber);
Console.WriteLine(minNumber);


 
