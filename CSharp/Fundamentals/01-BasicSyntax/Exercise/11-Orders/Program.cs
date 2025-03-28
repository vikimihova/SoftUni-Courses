using System;
using System.Diagnostics;

namespace _11_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double pricePerCapsule = 0;

            int days = 0;

            int capsulesCount = 0;

            double pricePerOrder = 0;

            double totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                pricePerCapsule = double.Parse(Console.ReadLine());
                days = int.Parse(Console.ReadLine());
                capsulesCount = int.Parse(Console.ReadLine());

                pricePerOrder = days * capsulesCount * pricePerCapsule;
                totalPrice += pricePerOrder;

                Console.WriteLine($"The price for the coffee is: ${pricePerOrder:f2}");                                              
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
