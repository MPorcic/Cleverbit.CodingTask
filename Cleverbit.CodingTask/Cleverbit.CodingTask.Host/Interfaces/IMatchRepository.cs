using Cleverbit.CodingTask.Host.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IMatchRepository
    {
        public Task<IEnumerable<MatchDto>> GetAllMatchesAsync();
        public Task<MatchDto> GetCurrentMatchAsync();
        public Task<int> GetExpiredCountAsync();
        public Task<IEnumerable<MatchDto>> GetExpiredMatchesAsync();
        public Task<MatchDto> GetMatchAsync(int matchId);
        public Task<IEnumerable<MatchDto>> GetMatchesToScore(DateTime from, DateTime to);

    }
}
