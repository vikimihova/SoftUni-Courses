using System;

namespace _07_VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            double sumCoins = 0;
            
            while (firstInput != "Start")
            {
                double coin = double.Parse(firstInput);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    sumCoins += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

                firstInput = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();
            double price = 0;
            string product = "";

            while (secondInput != "End")
            {
                if (secondInput == "Nuts")
                {
                    price = 2;
                    product = "nuts";
                }
                else if (secondInput == "Water")
                {
                    price = 0.7;
                    product = "water";
                }
                else if (secondInput == "Crisps")
                {
                    price = 1.5;
                    product = "crisps";
                }
                else if (secondInput == "Soda")
                {
                    price = 0.8;
                    product = "soda";
                }
                else if (secondInput == "Coke")
                {
                    price = 1;
                    product = "coke";
                }
                else
                {
                    price = 0;
                    Console.WriteLine("Invalid product");
                }


                if (price != 0 && price <= sumCoins)
                {
                    Console.WriteLine($"Purchased {product}");
                    sumCoins -= price;
                }
                else if (price != 0 && price > sumCoins)
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                secondInput = Console.ReadLine();                
            }

            Console.WriteLine($"Change: {sumCoins:f2}");
        }
    }
}
