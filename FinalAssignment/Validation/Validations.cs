

using FinalAssignment.BAL.Interface;
using FinalAssignment.BAL.Service;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace FinalAssignment.Validation
{
    public class Validations
    {
        private readonly ILoginService loginService = new LoginService();

        public static bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (email.IsNullOrEmpty())
            {
                Console.WriteLine("Email is not null or empty. please enter again");
                return false;
            }
            if (!Regex.IsMatch(email, pattern))
            {
                Console.WriteLine("Not a valid Email. Please Enter Again");
                return false;
            }
            return true;
        }

        public async Task<bool> DoesEmailExist(string email)
        {
            int id = await loginService.DoesEmailExist(email);
            if (id == -1)
            {
                Console.WriteLine("Email does not Exist. Please Enter again");
                return false;
            }
            return true;
        }

        public static bool IsPasswordValid(string? password)
        {

            if (password.IsNullOrEmpty())
            {
                Console.WriteLine("Password can't be null or empty. Please Enter again");
                return false;
            }
            return true;
        }

        //Bike number validation
        private static HashSet<string> registeredBikeNumbers = new HashSet<string>();
        public static bool ValidateBikeNumber(string bikeNumber)
        {
            
            string pattern = @"^[A-Z]{2}\s\d{2}\s\d{4}$";
            Regex regex = new Regex(pattern);

            
            if (!regex.IsMatch(bikeNumber))
            {
                Console.WriteLine("Invalid format. Please use the format: 'StateCode UniqueNumber 4DigitNumber' (e.g., HP 78 7658).");
                return false;
            }

            return true;
        }

    }
}


