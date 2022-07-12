using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Host.Interfaces;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Repositories
{
    public class TestRepository : ITestRepository
    {
        public readonly CodingTaskContext _dbContext;
        public TestRepository(CodingTaskContext context)
        {
            _dbContext = context;
        }
        public async Task<string> GetTestPingAsync()
        {
            var test = _dbContext;
            return "Succesfull call through injected repos and services";
        }
    }
}
