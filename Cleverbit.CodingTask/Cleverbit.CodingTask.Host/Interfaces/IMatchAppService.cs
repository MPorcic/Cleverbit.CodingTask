using Cleverbit.CodingTask.Host.Dto;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Interfaces
{
    public interface IMatchAppService    {
        public Task<IEnumerable<MatchDto>> GetAllMatchesAsync();
        public Task<MatchDto> GetCurrentMatchAsync();
    }
}
