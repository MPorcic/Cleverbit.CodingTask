using Cleverbit.CodingTask.Data.Models;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string username, string hashedPassword);
        Task<User> GetLoggedInUser(string username);
    }
}
