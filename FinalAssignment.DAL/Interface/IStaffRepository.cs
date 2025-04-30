
using FinalAssignment.DAL.Entity;

namespace FinalAssignment.DAL.Interface
{
    public interface IStaffRepository
    {
        //Manage service requests
        public IList<ServiceRequests> GetPendingServiceRequests();
        public bool AssignServiceToMechanic(ServiceRequests serviceRequest);
        public ServiceRequests? GetServiceRequestsById(int id);


        //Update service status
        public IList<ServiceRequests> GetAllServiceRequests();
        public bool UpdateServiceStatus(ServiceRequests serviceRequest);
        public Bikes GetBikeById(int id);
        public bool UpdateBikeStatus(Bikes bike);

        //AddServiceParts
        public IList<ServiceParts> GetAllServiceParts();
        public bool SaveServiceParts(ServiceParts serviceParts);

        //ChangeServiceFee
        public bool ChangeServiceFee(SystemSettings system);

        //If PartNum already exists
        public ServiceParts GetServicePartsByPartNum(string PartNum);

        //If BikeNum Already exists
        public Bikes GetBikeByBikeNum(string bikeNum);

        //For email
        public decimal GetServiceFee();
        public Users GetUserById(int userId);
    }
}
