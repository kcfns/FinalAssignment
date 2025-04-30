

namespace FinalAssignment.BAL.Interface
{
    public interface ILoginService
    {
        public Task<int> DoesEmailExist(string email);
        public Task<int> CheckCredential(string email, string password);
        public Task<bool> GetUserRole(int id);
    }
}
