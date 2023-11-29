using _03.Telephony.Models.Interfaces;

namespace _03.Telephony.Models
{
    public class SmartPhone : ICaller, IBrowser
    {
        public string Browse(string url)
        {
            if (url.Any(character => char.IsDigit(character)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.Any(character => !char.IsDigit(character)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
