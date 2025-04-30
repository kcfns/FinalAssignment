using FinalAssignment.DAL.Context;
using FinalAssignment.DAL.Entity;
using FinalAssignment.DAL.Interface;

namespace FinalAssignment.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _context;
        public CustomerRepository()
        {
            _context = new DatabaseContext();
        }

        public bool AddBikeDetail(Bikes bike)
        {
            _context.Bikes.Add(bike);
            _context.SaveChanges();
            return true;
        }

        public bool AddServiceType(ServiceRequests serviceRequest)
        {
            _context.ServiceRequests.Add(serviceRequest);
            _context.SaveChanges();
            return true;
        }

        public Bikes BikeAlreadyExists(int id)
        {
            return _context.Bikes.Find(id);
        }

        public Bikes GetBikeByUserId(int id)
        {
            return _context.Bikes.Where(bike => bike.UserId == id).OrderByDescending(bike => bike.Id) .FirstOrDefault();
        }

        //For CheckServiceStatus
        public IList<Bikes> GetAllBikes(int id)
        {
            return _context.Bikes
            .Where(bike => bike.UserId == id)
            .ToList();
        }

        public IEnumerable<ServiceRequests> GetAllServiceRequests(int bikeId)
        {
            return _context.ServiceRequests.Where(service => service.BikeId == bikeId && (service.Status == Shared.Enum.Status.Pending || service.Status == Shared.Enum.Status.InProgress));
        }
    }
}
