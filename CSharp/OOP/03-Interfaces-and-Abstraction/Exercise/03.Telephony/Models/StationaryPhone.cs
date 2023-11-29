using _03.Telephony.Models.Interfaces;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICaller
    {
        public string Call(string phoneNumber)
        {
            if (phoneNumber.Any(character => !char.IsDigit(character)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
