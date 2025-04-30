
using FinalAssignment.Page;

namespace FinalAssignment.Menu
{
    public class CustomerMenuClass
    {
        public static async Task CustomerMenu(int id)
        {
            
            Console.WriteLine("Enter 1 to Request a Service");
            Console.WriteLine("Enter 2 to Check Service Status");
            Console.WriteLine("Enter 3 to Logout");

            int choice = int.TryParse(Console.ReadLine()?.Trim(), out int value) ? value : 0;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new CustomerPage().RequestAService(id);
                    await CustomerMenu(id);
                    break;

                case 2:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new CustomerPage().CheckServiceStatus(id);
                    await CustomerMenu(id);
                    break;

                case 3:
                    Console.WriteLine("Successfully Logout");
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter correct Option");
                    await CustomerMenu(id);
                    break;
            }
        }
    }
}
