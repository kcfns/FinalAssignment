
using FinalAssignment.Page;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Enter 1 to Login.");
        Console.WriteLine("Enter 2 to close the application.");


        int choice = int.TryParse(Console.ReadLine(), out int value) ? value : 0;
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter 0 to Go Back!");
                await LoginPage.LoginWithEmail();
                Console.Clear();
                await Main();
                break;
            case 2:
                Console.WriteLine("Application Closed!");
                return;
            default:
                Console.Clear();
                Console.WriteLine("Please Enter correct Option");
                await Main();
                break;
        }
        //Console.WriteLine("Application Exit");
    }
}
