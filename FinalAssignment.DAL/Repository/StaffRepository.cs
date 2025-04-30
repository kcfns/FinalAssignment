
using FinalAssignment.DAL.Context;
using FinalAssignment.DAL.Entity;
using FinalAssignment.DAL.Interface;

namespace FinalAssignment.DAL.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DatabaseContext _context;
        public StaffRepository()
        {
            _context = new DatabaseContext();
        }

        public bool AssignServiceToMechanic(ServiceRequests serviceRequest)
        {
            _context.Update(serviceRequest);
            _context.SaveChanges();
            return true;
        }

        public bool ChangeServiceFee(SystemSettings system)
        {
            _context.SystemSettings.Update(system); ;
            _context.SaveChanges();
            return true;
        }

        public IList<ServiceParts> GetAllServiceParts()
        {
            return _context.ServiceParts.ToList();
        }

        public IList<ServiceRequests> GetAllServiceRequests()
        {
            return _context.ServiceRequests.ToList();
        }

        public Bikes GetBikeByBikeNum(string bikeNum)
        {
            return _context.Bikes.FirstOrDefault(b => b.BikeNumber.Equals(bikeNum));
        }

        public Bikes GetBikeById(int id)
        {
            return _context.Bikes.Find(id);
        }

        public IList<ServiceRequests> GetPendingServiceRequests()
        {
            return _context.ServiceRequests.Where(request => request.Status == Shared.Enum.Status.Pending).ToList();
        }

        public decimal GetServiceFee()
        {
            return _context.SystemSettings.OrderByDescending(ss => ss.Id).FirstOrDefault().ServiceFee;
        }

        public ServiceParts GetServicePartsByPartNum(string PartNum)
        {
            return _context.ServiceParts.FirstOrDefault(sp => sp.PartNumber.Equals(PartNum));
        }

        public ServiceRequests? GetServiceRequestsById(int id)
        {
            ServiceRequests? request =  _context.ServiceRequests.Find(id);
            return request;
        }

        public Users GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public bool SaveServiceParts(ServiceParts serviceParts)
        {
            _context.ServiceParts.Add(serviceParts);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateBikeStatus(Bikes bike)
        {
            if(bike == null)
            {
                return false;
            }
            _context.Bikes.Update(bike);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateServiceStatus(ServiceRequests serviceRequest)
        {
            if(serviceRequest ==  null)
            {
                return false;
            }
            _context.ServiceRequests.Update(serviceRequest);
            _context.SaveChanges();
            return true;
        }
    }
}
