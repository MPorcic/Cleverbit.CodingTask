using Cleverbit.CodingTask.Host.Dto;
using Cleverbit.CodingTask.Host.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services
{
    public class MatchAppService : IMatchAppService
    {
        private readonly IMatchRepository _matchRepository;


        public MatchAppService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<MatchDto>> GetAllMatchesAsync()
        {
            return await _matchRepository.GetAllMatchesAsync();
        }

        public async Task<MatchDto> GetCurrentMatchAsync()
        {
            
            return await _matchRepository.GetCurrentMatchAsync();
            
        }
    }
}
