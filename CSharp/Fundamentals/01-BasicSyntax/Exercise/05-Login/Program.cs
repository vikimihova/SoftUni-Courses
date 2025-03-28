using System;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;

namespace _05_Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();



            string correctPassword = "";            
            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPassword += username[i];
            }
                      

            
            int counter = 1;
            while (password != correctPassword && counter < 4)
            {
                Console.WriteLine("Incorrect password. Try again.");
                counter++;
                password = Console.ReadLine();
            }            


            if (password != correctPassword && counter == 4)
            {
                Console.WriteLine($"User {username} blocked!");
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
            }

        }
    }
}
