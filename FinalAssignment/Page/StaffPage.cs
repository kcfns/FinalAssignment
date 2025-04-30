using ConsoleTables;
using FinalAssignment.BAL.Interface;
using FinalAssignment.BAL.Service;
using FinalAssignment.Shared.DTO;
using Microsoft.IdentityModel.Tokens;

namespace FinalAssignment.Page
{
    public class StaffPage
    {
        private readonly IStaffService staffService = new StaffService();
        public void ManageServiceRequests(int id)
        {
            

            IList<ServiceRequestsDTO> serviceRequestsDTOs = staffService.GetPendingServiceRequests();

            if (!serviceRequestsDTOs.Any())
            {
                Console.WriteLine("No pending services available");
                return;
            }
            Console.WriteLine("All Pending requests :");

            ConsoleTable table = new("Id", "BikeId", "Request Date", "Service Type", "Status", "Remarks");

            foreach (ServiceRequestsDTO serviceRequestsDTO in serviceRequestsDTOs)
            {
                table.AddRow(serviceRequestsDTO.Id ,serviceRequestsDTO.BikeId, serviceRequestsDTO.RequestDate, serviceRequestsDTO.ServiceType, serviceRequestsDTO.Status, serviceRequestsDTO.Remarks);
            }
            table.Write();

            Console.WriteLine("Enter 0 to Go Back!");
            Console.WriteLine("Enter 1 to assign a pending task to mechanics");

            while (true)
            {
                int choice = int.TryParse(Console.ReadLine(), out int val) ? val : -1;

                if(choice == 0)
                {
                    Console.WriteLine("Successfully Go Back");
                    return;
                }
                if(choice == 1)
                {
                    break;
                }
            }

            bool IdExist(int id)
            {
                foreach (ServiceRequestsDTO sr in serviceRequestsDTOs)
                {
                    if (sr.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            Console.WriteLine("Enter the Id of the service request you want to assign to mechanics");

            while (true)
            {
                int choice = int .TryParse(Console.ReadLine(),out int val) ? val : -1;
                if(choice == 0)
                {
                    Console.WriteLine("Successfully Go back");
                    return;
                }
                if(choice == -1)
                {
                    Console.WriteLine("Invalid choice, Please enter again.");
                    continue;
                }
                if(!IdExist(choice))
                {
                    Console.WriteLine("Enter the Id which is present on the table and is pending.");
                    continue;
                }
                
                //staffService.AssignRequestToMechanic(choice);
                staffService.MakeServiceStatusInProgress(choice);
                Console.WriteLine("Request is assigned to the mechanic successfully");
                break;
            }
            
        }

        public void UpdateServiceStatus(int id)
        {
            Console.Clear();
            Console.WriteLine("Enter 0 to Go Back!");
            Console.WriteLine("Pending and InProgress service requests :");

            ConsoleTable table = new("Id", "BikeId", "Service Type", "Status", "Remarks");
            IList<ServiceRequestsDTO> srDTO = staffService.GetAllServiceRequests();

            foreach (ServiceRequestsDTO sr in srDTO)
            {
                table.AddRow(sr.Id, sr.BikeId, sr.ServiceType, sr.Status, sr.Remarks);
            }

            table.Write();

            Console.WriteLine("Enter the service request Id whose status you want to change :");

            bool IdExist(int id)
            {
                foreach (ServiceRequestsDTO sr in srDTO)
                {
                    if (sr.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            int result;

            while (true)
            {
                int choice = int.TryParse(Console.ReadLine(), out int val) ? val : -1;

                if(choice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Successfully exited the update service status page");
                    return;
                }
                if(choice == -1)
                {
                    Console.WriteLine("Enter a valid Id");
                    continue;
                }
                if(!IdExist(choice))
                {
                    Console.WriteLine("Enter the Id which is present on the table.");
                    continue;
                }
                result = choice;
                break;
            }
            //
            //here on i am making the changes
            //
            Console.WriteLine("Enter 0 to exit.");
            Console.WriteLine("Enter 1 to mark the service request 'In Progress'.");
            Console.WriteLine("Enter 2 to mark the service request 'Completed'.");

            while(true)
            {
                int choice = int.TryParse(Console.ReadLine(), out int val) ? val: -1;

                if(choice == 0)
                {
                    Console.Clear(); Console.WriteLine("Successfully exited updating the service request application.");
                    return;
                }
                if(choice == -1)
                {
                    Console.WriteLine("Enter a valid choice.");
                    continue;
                }
                if(choice == 1)
                {
                    staffService.MakeServiceStatusInProgress(result);
                    break;
                }
                if(choice == 2)
                {
                    staffService.MakeServiceStatusCompleted(result);
                    break;
                }
            }
            
        }

        public void AddServiceParts(int id)
        {
            Console.WriteLine("Available Service Parts :");

            IList<ServicePartsDTO> spDTO = staffService.GetAllServiceParts();

            ConsoleTable table = new("Id", "Part Name", "Part Number", "Quantity");
            foreach (ServicePartsDTO sp in spDTO)
            {
                table.AddRow(sp.Id, sp.PartName, sp.PartNumber, sp.Quantity);
            }
            table.Write();

            Console.WriteLine("Enter 1 to add new service parts");
            Console.WriteLine("Enter 0 to go back");


            ServicePartsDTO servicePartsDTO = new ServicePartsDTO();

            while (true)
            {
                int choice = int.TryParse(Console.ReadLine(), out int val) ? val : -1;

                if (choice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Successfully exited the update service status page");
                    return;
                }
                if (choice == -1)
                {
                    Console.WriteLine("Enter a valid Id");
                    continue;
                }
                if (choice == 1)
                {
                    break;
                }
            }

            Console.WriteLine("Enter the Part Name :");
            while (true)
            {
                string partName = Console.ReadLine() ?? string.Empty;

                if(partName.Equals("0"))
                {
                    Console.Clear();
                    Console.WriteLine("Go Back");
                    return;
                }
                if(partName.IsNullOrEmpty())
                {
                    Console.WriteLine("Part name can't be null or empty. Enter again:");
                    continue;
                }
                servicePartsDTO.PartName = partName;
                break;
            }

            Console.WriteLine("Enter the Part Number :");
            while (true)
            {
                string partNumber = Console.ReadLine() ?? string.Empty;

                if (partNumber.Equals("0"))
                {
                    Console.Clear();
                    Console.WriteLine("Go Back");
                    return;
                }
                if (partNumber.IsNullOrEmpty())
                {
                    Console.WriteLine("Part name can't be null or empty. Enter again:");
                    continue;
                }
                if (staffService.IfPartNumAlreadyExists(partNumber))
                {
                    Console.WriteLine("This Part number already exists. Enter a new one:");
                    continue;
                }
                servicePartsDTO.PartNumber = partNumber;
                break;
            }

            Console.WriteLine("Enter the Quantity :");
            while (true)
            {
                int choice = int.TryParse(Console.ReadLine(), out int val) ? val : -1;

                if (choice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Successfully exited the update service status page");
                    return;
                }
                if (choice == -1)
                {
                    Console.WriteLine("Enter a valid quantity");
                    continue;
                }
                servicePartsDTO.Quantity = choice;
                break;
            }

            staffService.SaveServiceParts(servicePartsDTO);
            Console.WriteLine("Service Parts have been saved");

        }

        public void ViewServicePartsInventory(int id)
        {
            Console.WriteLine("Service Parts Inventory :");

            IList<ServicePartsDTO> spDTO = staffService.GetAllServiceParts();

            ConsoleTable table = new("Id", "Part Name", "Part Number", "Quantity");
            foreach (ServicePartsDTO sp in spDTO)
            {
                table.AddRow(sp.Id, sp.PartName, sp.PartNumber, sp.Quantity);
            }
            table.Write();

        }

        public void ChangeServiceFee(int id)
        {
            SystemSettingsDTO systemSettingsDTO = new SystemSettingsDTO();

            Console.WriteLine("Enter the Service Fee to the amount you want to change it to :");
            while(true)
            {
                decimal serviceFee = decimal.TryParse(Console.ReadLine(), out decimal val) ? val : -1;

                if(serviceFee == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Successfully exited update the service fee page");
                    return;
                }
                if(serviceFee == -1)
                {
                    Console.WriteLine("Enter a valid service fees.");
                    continue;
                }
                systemSettingsDTO.ServiceFee = serviceFee;
                break;
            }

            staffService.ChangeServiceFee(systemSettingsDTO);
        }
    }
}
