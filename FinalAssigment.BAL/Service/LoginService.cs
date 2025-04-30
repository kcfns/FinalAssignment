
using FinalAssignment.BAL.Interface;
using FinalAssignment.DAL.Entity;
using FinalAssignment.DAL.Interface;
using FinalAssignment.DAL.Repository;

namespace FinalAssignment.BAL.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository = new LoginRepository();

        public async Task<int> CheckCredential(string email, string password)
        {
            Users? result = await loginRepository.CheckCredential(email, password);
            return result == null ? -1 : result.Id;
        }

        public async Task<bool> GetUserRole(int id)
        {
            Users? result = await loginRepository.GetUserDetail(id);
            if (result == null)
            {
                Console.WriteLine("Null value");
            }
            return result.IsStaff;
        }

        public async Task<int> DoesEmailExist(string email)
        {
            Users? result = await loginRepository.DoesEmailExist(email);
            return result == null ? -1 : result.Id;
        }
    }
}
