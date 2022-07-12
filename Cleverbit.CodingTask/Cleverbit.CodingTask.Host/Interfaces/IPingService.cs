using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IPingService
    {
        Task<string> GetPingTest();
    }
}
