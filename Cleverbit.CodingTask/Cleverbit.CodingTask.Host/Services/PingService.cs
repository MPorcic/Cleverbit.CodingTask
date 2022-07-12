using Cleverbit.CodingTask.Host.Interfaces;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services
{
    public class PingService : IPingService
    {
        private readonly ITestRepository _testRepository;
        public PingService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<string> GetPingTest()
        {
            return await _testRepository.GetTestPingAsync();
        }
    }
}
