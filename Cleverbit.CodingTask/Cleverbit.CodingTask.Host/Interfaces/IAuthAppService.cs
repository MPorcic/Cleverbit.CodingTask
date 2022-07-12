using Cleverbit.CodingTask.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{

    public interface IAuthAppService
    {
        Task<User> LoginUser(string username, string password);
        Task<User> GetLoggedInUser(string username);
    }
}
