using FinalAssignment.BAL.Interface;
using FinalAssignment.BAL.Service;
using FinalAssignment.Menu;
using FinalAssignment.Shared.DTO;
using FinalAssignment.Validation;

namespace FinalAssignment.Page
{
    public class LoginPage
    {
        private static readonly Validations validation = new();
        public static readonly ILoginService loginService = new LoginService();
        public static async Task LoginWithEmail()
        {
            UsersDTO usersDTO = new UsersDTO();

            Console.WriteLine("Enter your email");
            while (true)
            {
                string email = Console.ReadLine() ?? String.Empty;
                email = email.Trim();

                if (email.Equals("0"))
                {
                    Console.WriteLine("Main Menu");
                    return;
                }
                if (Validations.IsEmailValid(email) && await validation.DoesEmailExist(email))
                {
                    usersDTO.Email = email;
                    break;
                }
            }

            Console.WriteLine("Enter your password");
            while (true)
            {
                string password = Console.ReadLine() ?? String.Empty;
                password = password.Trim();

                if (password.Equals("0"))
                {
                    Console.WriteLine("Main Menu:");
                    return;
                }
                if (Validations.IsPasswordValid(password))
                {
                    usersDTO.Password = password;
                    break;
                }
            }

            int id = await loginService.CheckCredential(usersDTO.Email, usersDTO.Password);

            if (id != -1)
            {
                bool? role = await loginService.GetUserRole(id);

                if (role == null)
                {
                    Console.WriteLine("User has no role.");
                    await LoginWithEmail();
                }

                if (role == true)
                {
                    Console.Clear();
                    Console.WriteLine("Role : Staff");
                    
                    Console.WriteLine("Welcome to Hero Service Station.");
                    await StaffMenuClass.StaffMenu(id);
                }

                if (role == false)
                {
                    Console.Clear();
                    Console.WriteLine("Role : Customer");
                    Console.WriteLine("Welcome to Hero Service Station");
                    await CustomerMenuClass.CustomerMenu(id);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Credentials. Try Logging In again");
                await LoginWithEmail();
            }

        }
    }
}
