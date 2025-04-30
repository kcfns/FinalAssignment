
using FinalAssignment.Page;

namespace FinalAssignment.Menu
{
    public class StaffMenuClass
    {
        public static async Task StaffMenu(int id)
        {
            Console.WriteLine("Enter 1 to Manage Service Requests");
            Console.WriteLine("Enter 2 to Update Service Status");
            Console.WriteLine("Enter 3 to Add Service Parts");
            Console.WriteLine("Enter 4 to View Service Parts Inventory");
            Console.WriteLine("Enter 5 to Change service fee");
            Console.WriteLine("Enter 6 to Logout");

            int choice = int.TryParse(Console.ReadLine()?.Trim(), out int value) ? value : 0;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new StaffPage().ManageServiceRequests(id);
                    await StaffMenu(id);
                    break;

                case 2:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new StaffPage().UpdateServiceStatus(id);
                    await StaffMenu(id);
                    break;

                case 3:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new StaffPage().AddServiceParts(id);
                    await StaffMenu(id);
                    break;

                case 4:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new StaffPage().ViewServicePartsInventory(id);
                    await StaffMenu(id);
                    break;

                case 5:
                    Console.WriteLine("Enter 0 to Go Back!");
                    new StaffPage().ChangeServiceFee(id);
                    await StaffMenu(id);
                    break;

                case 6:
                    Console.WriteLine("Successfully Logout");
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter correct Option");
                    await StaffMenu(id);
                    break;
            }
        }
    }
}
