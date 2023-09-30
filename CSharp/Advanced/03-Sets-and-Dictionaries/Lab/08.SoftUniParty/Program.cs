using System.Security.Cryptography.X509Certificates;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (input[0] >= 0 && input[0] <= 9)
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (input[0] >= 0 && input[0] <= 9)
                {
                    vipGuests.Remove(input);
                }
                else
                {
                    regularGuests.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            if (vipGuests.Count > 0)
            {
                foreach (var guest in vipGuests)
                {
                    Console.WriteLine(guest);
                }
            }

            if (regularGuests.Count > 0)
            {
                foreach (var guest in regularGuests)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}