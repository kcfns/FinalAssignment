

using FinalAssignment.DAL.Entity;

namespace FinalAssignment.DAL.Interface
{
    public interface ILoginRepository
    {
        public Task<Users?> DoesEmailExist(string email);
        public Task<Users?> CheckCredential(string email, string password);
        public Task<Users?> GetUserDetail(int id);
    }
}
