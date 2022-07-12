using Cleverbit.CodingTask.Host.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IMatchEntryRepository
    {
        Task<IEnumerable<MatchEntryDto>> GetEntriesForUserAsync(int userId);
        Task<MatchEntryDto> CreateMatchEntryForUser(int matchId, int entryId, int score);
        Task<int> GetCountAsync();

        Task<MatchEntryDto> GetWinnerEntryForMatch(int matchId);
    }
}
