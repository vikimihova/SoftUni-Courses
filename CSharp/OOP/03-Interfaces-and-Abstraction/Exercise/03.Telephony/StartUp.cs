using _03.Telephony.Models.Interfaces;
using _03.Telephony.Models;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> urlAddresses = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            ICaller phone;

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else
                {
                    phone = new SmartPhone();
                }

                try
                {
                    Console.WriteLine(phone.Call(phoneNumber));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                    
            IBrowser smartPhone = new SmartPhone();

            foreach (string url in urlAddresses)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}