using Cleverbit.CodingTask.Host.Dto;
using Cleverbit.CodingTask.Host.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services
{
    public class MatchEntryAppService: IMatchEntryAppService
    {
        private readonly IMatchEntryRepository _matchRepository;

        public MatchEntryAppService(IMatchEntryRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchEntryDto>> GetEntriesForUserAsync(int userId)
        {
            return await _matchRepository.GetEntriesForUserAsync(userId);
        }

        public async Task<MatchEntryDto> PutMatchEntryForUser(int matchId, int userId)
        {
            Random rnd = new Random();
            var score = rnd.Next(0, 100);
            try
            {
                return await _matchRepository.CreateMatchEntryForUser(matchId, userId, score);

            } catch (Exception ex)
            {
                var e = ex;
            }
            return null;
        }
    }
}
