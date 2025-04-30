
using FinalAssignment.DAL.Entity;
namespace FinalAssignment.DAL.Interface
{
    public interface ICustomerRepository
    {
        public bool AddBikeDetail(Bikes bike);
        public bool AddServiceType(ServiceRequests serviceRequest);
        public Bikes BikeAlreadyExists(int id);
        public Bikes GetBikeByUserId(int id);
        //
        public IList<Bikes> GetAllBikes(int id);
        public IEnumerable<ServiceRequests> GetAllServiceRequests(int bikeId);
    }
}
