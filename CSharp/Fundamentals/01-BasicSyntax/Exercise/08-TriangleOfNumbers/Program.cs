﻿using System;

namespace _08_TriangleOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
               for (int j = 0; j < i; j++)
               {
                    Console.Write($"{i} ");
               }
               Console.WriteLine();
            }
        }
    }
}
