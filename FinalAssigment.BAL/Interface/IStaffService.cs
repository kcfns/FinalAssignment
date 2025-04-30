
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Interface
{
    public interface IStaffService
    {
        //Manaage service requests
        public IList<ServiceRequestsDTO> GetPendingServiceRequests();
        public bool AssignRequestToMechanic(int choice);

        //Update Service status
        public IList<ServiceRequestsDTO> GetAllServiceRequests();
        public bool MakeServiceStatusInProgress(int id);
        public bool MakeServiceStatusCompleted(int id);

        //AddServiceParts
        public IList<ServicePartsDTO> GetAllServiceParts();
        public bool SaveServiceParts(ServicePartsDTO servicePartsDTO);

        //Change Service fee
        public bool ChangeServiceFee(SystemSettingsDTO system);

        //Check if PartNum already exits
        public bool IfPartNumAlreadyExists(string partNum);

        public bool IfBikeNumAlreadyExists(string bikeNum);

    }
}
