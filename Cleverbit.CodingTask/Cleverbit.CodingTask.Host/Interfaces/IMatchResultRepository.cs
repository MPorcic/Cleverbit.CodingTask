using Cleverbit.CodingTask.Host.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IMatchResultRepository
    {
        Task<IEnumerable<MatchResultDto>> GetAllMatchResultsAsync();
        Task<IEnumerable<MatchResultDto>> GetAllMatchResultsForUserAsync(int userId);
        Task<int> GetCountAsync();
        Task<MatchResultDto> GetLatestResultAsync();
        Task InsertMatchResult(MatchResultDto matchEntry);
        
    }
}
