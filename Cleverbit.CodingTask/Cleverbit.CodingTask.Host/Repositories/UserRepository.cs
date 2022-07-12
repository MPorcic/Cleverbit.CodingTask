using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Data.Models;
using Cleverbit.CodingTask.Host.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CodingTaskContext _context;

        public UserRepository(CodingTaskContext context)
        {
            _context = context;
        }

        public async Task<User> GetLoggedInUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> GetUser(string userName, string hashPassword)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == hashPassword);
        }
    }
}
