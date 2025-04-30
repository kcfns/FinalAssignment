using FinalAssignment.BAL.Interface;
using FinalAssignment.BAL.Service;
using FinalAssignment.Shared.DTO;
using FinalAssignment.Validation;
using Microsoft.IdentityModel.Tokens;
using ConsoleTables;

namespace FinalAssignment.Page
{
    public class CustomerPage
    {
        private readonly ICustomerService customerService = new CustomerService();
        private readonly IStaffService staffService = new StaffService();
        public void RequestAService(int id)
        {
            Console.WriteLine("Enter the bike details :");
            BikesDTO bikeDTO = new()
            {
                UserId = id,
            };

            Console.WriteLine("Enter the bike number :");
            while(true)
            {
                string BNo = Console.ReadLine()?.Trim() ?? String.Empty;

                if(BNo.Equals("0"))
                {
                    Console.WriteLine("Exited entering the bike details");
                    return;
                }
                if (Validations.ValidateBikeNumber(BNo))
                {
                    //bike number unique
                    if (staffService.IfBikeNumAlreadyExists(BNo))
                    {
                        Console.WriteLine("Bike with this number already exits.");
                        continue;
                    }
                    bikeDTO.BikeNumber = BNo;
                    break;
                }
            }

            Console.WriteLine("Enter the model :");
            while (true)
            {
                string model = Console.ReadLine()?.Trim() ?? String.Empty;

                if (model.Equals("0"))
                {
                    Console.WriteLine("Exited extering the bike details");
                    return;
                }
                if(model.IsNullOrEmpty())
                {
                    Console.WriteLine("Model can be null or empty. Enter again");
                }
                else
                {
                    bikeDTO.Model = model;
                    break;
                }
            }

            customerService.AddBikeDetail(bikeDTO);

            BikesDTO savedBikeDTO = customerService.GetBikeByUserId(id);

            //creating the service request
            ServiceRequestsDTO serviceRequestDTO = new ServiceRequestsDTO()
            {
                BikeId = savedBikeDTO.Id
            };

            

            Console.WriteLine("Enter details for the service type request");
            Console.WriteLine("Enter 1 for Repair");
            Console.WriteLine("Enter 2 for Service");

            while (true)
            {
                int choice = int.TryParse(Console.ReadLine(), out int val) ? val : -1;

                if (choice == 0)
                {
                    Console.WriteLine("Successfull Go Back!");
                    return;
                }

                if(choice == 1)
                {
                    serviceRequestDTO.ServiceType = Shared.Enum.ServiceTypeEnum.Repair;
                    break;
                }
                if(choice == 2)
                {
                    serviceRequestDTO.ServiceType = Shared.Enum.ServiceTypeEnum.Service;
                    break;
                }
                Console.WriteLine("Enter a valid option");
            }

            Console.WriteLine("Enter any queries you have :");
            serviceRequestDTO.Remarks = Console.ReadLine() ?? String.Empty;

            customerService.AddServiceType(serviceRequestDTO);
            Console.WriteLine("Service Request successfully made.");
        }

        public void CheckServiceStatus(int id)
        {
            Console.Clear();
            Console.WriteLine("Ongoing Services :");


            IList<BikesDTO> bikesDTO = customerService.GetAllBikes(id);


            ConsoleTable table = new("BikeId","Bike Number", "Model", "Status");


            foreach (BikesDTO bikes in bikesDTO)
            {
                table.AddRow(bikes.Id, bikes.BikeNumber, bikes.Model, bikes.Status);
            }

            table.Write();


        }

    }
}
