using Cleverbit.CodingTask.Host.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IMatchEntryAppService
    {
      Task<IEnumerable<MatchEntryDto>> GetEntriesForUserAsync(int userId);
      Task<MatchEntryDto> PutMatchEntryForUser(int matchId, int userId);
    }
}
