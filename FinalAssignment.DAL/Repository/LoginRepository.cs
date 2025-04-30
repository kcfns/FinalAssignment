

using FinalAssignment.DAL.Context;
using FinalAssignment.DAL.Entity;
using FinalAssignment.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment.DAL.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DatabaseContext _context;
        public LoginRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task<Users?> CheckCredential(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<Users?> GetUserDetail(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users?> DoesEmailExist(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }


    }
}
