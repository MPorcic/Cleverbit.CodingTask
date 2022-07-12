

using Cleverbit.CodingTask.Data.Models;
using Cleverbit.CodingTask.Host.Interfaces;
using Cleverbit.CodingTask.Utilities;
using System;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services
{

    public class AuthAppService : IAuthAppService
    {

        private readonly IHashService _hashService;
        private readonly IUserRepository _userRepository;

        public AuthAppService(IHashService hashService, IUserRepository userRepository)
        {
            _hashService = hashService;
            _userRepository = userRepository;
        }

        public async Task<User> GetLoggedInUser(string username)
        {
            return await _userRepository.GetLoggedInUser(username);
        }

        public async Task<User> LoginUser(string username, string password)
        {
            try
            {
                User user;
                var hashPassword = _hashService.HashText(password);
                return await _userRepository.GetUser(username, password);
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occured when logging in user");
            }
        }
    }
}
