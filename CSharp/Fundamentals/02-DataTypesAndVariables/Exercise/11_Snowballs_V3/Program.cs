﻿using System;
using System.Numerics;

namespace _11_Snowballs_V3
{
    internal class Program
    {
        static void Main(string[] args)
        {
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


        }
    }
}
