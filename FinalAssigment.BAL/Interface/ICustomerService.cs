
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Interface
{
    
    public interface ICustomerService
    {
        public bool AddBikeDetail(BikesDTO bikeDTO);
        public bool AddServiceType(ServiceRequestsDTO serviceRequestDTO);
        public bool BikeAlreadyExits(int id);

        public BikesDTO GetBikeByUserId(int id);

        public IList<BikesDTO> GetAllBikes(int id);

        
    }
}
