
using FinalAssignment.BAL.Interface;
using FinalAssignment.BAL.Mapper;
using FinalAssignment.DAL.Entity;
using FinalAssignment.DAL.Interface;
using FinalAssignment.DAL.Repository;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository = new CustomerRepository();
        public bool AddBikeDetail(BikesDTO bikeDTO)
        {
            bikeDTO.Status = Shared.Enum.Status.Available;
            bikeDTO.ServiceHistory = "Bike is up for service on " + DateTime.Now;
            Bikes bike = bikeDTO.ToEntity();
            customerRepository.AddBikeDetail(bike);
            return true;
        }

        public bool AddServiceType(ServiceRequestsDTO serviceRequestDTO)
        {
            serviceRequestDTO.RequestDate = DateTime.Now;
            serviceRequestDTO.Status = Shared.Enum.Status.Pending;
            ServiceRequests serviceRequests = serviceRequestDTO.ToEntity();
            customerRepository.AddServiceType(serviceRequests);
            return true;
        }

        public bool BikeAlreadyExits(int id)
        {
            Bikes bike = customerRepository.BikeAlreadyExists(id);
            if(bike == null)
            {
                return false;
            }
            return true;
        }

        public BikesDTO GetBikeByUserId(int id)
        {
            Bikes bike = customerRepository.GetBikeByUserId(id);
            BikesDTO bikeDTO = bike.ToDTO();
            return bikeDTO;
        }

        public IList<BikesDTO> GetAllBikes(int id)
        {
            IList<Bikes> bikes = customerRepository.GetAllBikes(id);
            IEnumerable<BikesDTO> bikesDTO = bikes.Select(bike => bike.ToDTO()).ToList();
            return [..bikesDTO];
        }

        
    }
}
