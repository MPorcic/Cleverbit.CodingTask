using Cleverbit.CodingTask.Host.Dto;
using Cleverbit.CodingTask.Host.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services
{
    public class MatchResultAppService : IMatchResultAppService
    {
        private readonly IMatchResultRepository _matchResultRepository;
        private readonly IMatchEntryRepository _matchEntryRepository;
        private readonly IMatchRepository _matchRepository;

        public MatchResultAppService(IMatchResultRepository matchResultRepository, IMatchEntryRepository matchEntryRepository, IMatchRepository matchRepository)
        {
            _matchResultRepository = matchResultRepository;
            _matchEntryRepository = matchEntryRepository;
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchResultDto>> GetAllMatchResultsAsync()
        {
            return await _matchResultRepository.GetAllMatchResultsAsync();
        }

        public async Task<IEnumerable<MatchResultDto>> GetAllMatchResultsForUserAsync(int userId)
        {
            return await _matchResultRepository.GetAllMatchResultsForUserAsync(userId);
        }

        public async Task InsertResultsForMatches(IEnumerable<MatchDto> matches)
        {
            try
            {

                foreach (var match in matches)
                {
                    var winnerEntry = await _matchEntryRepository.GetWinnerEntryForMatch(match.Id);
                    if(winnerEntry != null)
                        await _matchResultRepository.InsertMatchResult(new MatchResultDto { MatchId = match.Id, UserId = winnerEntry.UserId, Winner = winnerEntry.UserName });

                }
            } catch (Exception e)
            {
                throw new Exception("Something happened while inserting results: " + e.Message);
            }
        }



        public async Task<IEnumerable<MatchResultDto>> RefreshResults()
        {
            try
            {

                var resultCount = await _matchResultRepository.GetCountAsync();
                var matchCount = await _matchRepository.GetExpiredCountAsync();
                if(resultCount == 0)
                {
                    var matchesToAdd = await _matchRepository.GetExpiredMatchesAsync();
                    await this.InsertResultsForMatches(matchesToAdd);
                }
                else if (resultCount != matchCount)
                {

                    var match = await _matchRepository.GetCurrentMatchAsync();
                    var latestResult = await _matchResultRepository.GetLatestResultAsync();
                    var latestExpiredMatch = (latestResult!=null)? await _matchRepository.GetMatchAsync(latestResult.MatchId) : null;
                    IEnumerable<MatchDto> matchesToAdd;


                    matchesToAdd = (latestExpiredMatch != null)
                        ? await _matchRepository.GetMatchesToScore(latestExpiredMatch.ExpiryDate, match.ExpiryDate)
                        : await _matchRepository.GetAllMatchesAsync();
                    await this.InsertResultsForMatches(matchesToAdd);
                }
            } catch (Exception e)
            {
                var ex = e;
            }
            return await _matchResultRepository.GetAllMatchResultsAsync();
        }
    }
}
