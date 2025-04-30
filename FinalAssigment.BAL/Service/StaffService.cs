
using FinalAssignment.BAL.Interface;
using FinalAssignment.BAL.Mapper;
using FinalAssignment.DAL.Entity;
using FinalAssignment.DAL.Interface;
using FinalAssignment.DAL.Repository;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Service
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository staffRepository = new StaffRepository();

        public bool AssignRequestToMechanic(int choice)
        {
            ServiceRequests? request = staffRepository.GetServiceRequestsById(choice);
            if (request == null)
            {
                return false;
            }
            request.Status = Shared.Enum.Status.InProgress;
            staffRepository.AssignServiceToMechanic(request);
            return true;
        }

        public bool ChangeServiceFee(SystemSettingsDTO system)
        {
            SystemSettings systemSettings = system.ToEntity() ;
            staffRepository.ChangeServiceFee(systemSettings);
            return true;
        }

        public IList<ServicePartsDTO> GetAllServiceParts()
        {
            IList<ServiceParts> serviceParts = staffRepository.GetAllServiceParts();
            IList<ServicePartsDTO> servicePartsDTOs = serviceParts.Select(sp => sp.ToDTO()).ToList();
            return servicePartsDTOs;
        }

        public IList<ServiceRequestsDTO> GetAllServiceRequests()
        {
            IList<ServiceRequests> serviceRequest = staffRepository.GetAllServiceRequests();

            IList<ServiceRequestsDTO> serviceRequestsDTOs = serviceRequest.Select(req => req.ToDTO()).ToList(); 
            return serviceRequestsDTOs; 
        }

        public IList<ServiceRequestsDTO> GetPendingServiceRequests()
        {
            IList<ServiceRequests> serviceRequests = staffRepository.GetPendingServiceRequests();
            IList<ServiceRequestsDTO> serviceRequestsDTO = serviceRequests.Select(request => request.ToDTO()).ToList();
            return serviceRequestsDTO;
        }

        public bool IfBikeNumAlreadyExists(string bikeNum)
        {
            Bikes bike = staffRepository.GetBikeByBikeNum(bikeNum);
            if(bike is not null)
            {
                return true;
            }
            return false;
        }

        public bool IfPartNumAlreadyExists(string partNum)
        {
            ServiceParts serviceParts =  staffRepository.GetServicePartsByPartNum(partNum);
            if (serviceParts is not null)
            {
                return true;
            }
            return false;
        }

        public bool MakeServiceStatusCompleted(int id)
        {
            ServiceRequests serviceRequests = staffRepository.GetServiceRequestsById(id);
            Bikes bike = staffRepository.GetBikeById(serviceRequests.BikeId);

            if (serviceRequests.Status == Shared.Enum.Status.Pending)
            {
                Console.WriteLine("This service request can't be updated to 'Completed' directly.");
                return false;
            }
            if(serviceRequests.Status == Shared.Enum.Status.Completed)
            {
                Console.WriteLine("This service request is already 'Completed'");
                return false;
            }
            
            serviceRequests.Status = Shared.Enum.Status.Completed;
            serviceRequests.ServiceDate = DateTime.Now;
            bike.Status = Shared.Enum.Status.ReadyForPickup;
            staffRepository.UpdateServiceStatus(serviceRequests);
            staffRepository.UpdateBikeStatus(bike);
            Console.WriteLine("Service Requests successfully updated to 'Completed'.");
            //
            //Mail code here
            //

            var customer = staffRepository.GetUserById(bike.UserId);

            decimal serviceFee = staffRepository.GetServiceFee();

            EmailService.SendInvoiceEmail(
                toEmail: customer.Email,
                bikeNumber: bike.BikeNumber,
                amount: serviceFee
            );



            return true;
        }

        public bool MakeServiceStatusInProgress(int id)
        {
            ServiceRequests serviceRequests = staffRepository.GetServiceRequestsById(id);
            Bikes bike = staffRepository.GetBikeById(serviceRequests.BikeId);

            if(serviceRequests.Status == Shared.Enum.Status.Completed)
            {
                Console.WriteLine("This service request is already completed and can't be updated to 'In Progress'.");
                return false;
            }
            if(serviceRequests.Status == Shared.Enum.Status.InProgress)
            {
                Console.WriteLine("This service request is already 'In Progress'.");
                return false;
            }
            serviceRequests.Status= Shared.Enum.Status.InProgress;
            bike.Status= Shared.Enum.Status.InService;
            staffRepository.UpdateServiceStatus(serviceRequests);
            staffRepository.UpdateBikeStatus(bike);
            Console.WriteLine("Service Requests successfully updated to 'In Progress'.");
            return true;
        }

        public bool SaveServiceParts(ServicePartsDTO servicePartsDTO)
        {
            ServiceParts serviceParts = servicePartsDTO.ToEntity();
            staffRepository.SaveServiceParts(serviceParts);
            return true;
        }
    }
}
