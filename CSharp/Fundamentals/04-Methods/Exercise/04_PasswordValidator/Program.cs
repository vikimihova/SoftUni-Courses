namespace _04_PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            bool lengthIsValid = CheckLength(password);
            bool charactersAreValid = CheckCharacters(password);
            bool digitsAreValid = CheckDigits(password);

            if (lengthIsValid && charactersAreValid && digitsAreValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckLength(string password, bool isValid = true)
        {
            
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }    
            
            return isValid;
        }

        static bool CheckCharacters(string password, bool isValid = true)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] < 48 || password[i] > 57 && password[i] < 65 || password[i] > 90 && password[i] < 97 || password[i] > 122)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        static bool CheckDigits(string password, bool isValid = true)
        {
            int digitsCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    digitsCount++;     
                }
            }

            if (digitsCount < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            return isValid;
        }
    }
}