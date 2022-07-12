using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface ITestRepository
    {
        Task<string> GetTestPingAsync();
    }
}
