// See https://aka.ms/new-console-template for more information
using System.Numerics;

int numberOfSnowballs = int.Parse(Console.ReadLine());

BigInteger highestSnowballValue = 0;
int bestSnowballSnow = 0;
int bestSnowballTime = 0;
int bestSnowballQuality = 0;

for (int i = 0; i < numberOfSnowballs; i++)
{
    int snowballSnow = int.Parse(Console.ReadLine());
    int snowballTime = int.Parse(Console.ReadLine());
    int snowballQuality = int.Parse(Console.ReadLine());

    BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

    if (snowballValue > highestSnowballValue)
    {
        highestSnowballValue = snowballValue;
        bestSnowballSnow = snowballSnow;
        bestSnowballTime = snowballTime;
        bestSnowballQuality = snowballQuality;
    }
}

Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {highestSnowballValue} ({bestSnowballQuality})");
