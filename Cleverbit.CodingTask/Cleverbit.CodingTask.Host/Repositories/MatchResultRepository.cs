using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Host.Dto;
using Cleverbit.CodingTask.Host.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Repositories
{

    public class MatchResultRepository : IMatchResultRepository
    {
        private readonly CodingTaskContext _context;

        public MatchResultRepository(CodingTaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchResultDto>> GetAllMatchResultsAsync()
        {
            var result = await _context.MatchResults.ToListAsync();
            return result.Select(x => new MatchResultDto
            {
                Id = x.Id,
                Winner = x.Winner
            });
        }

        public async Task<IEnumerable<MatchResultDto>> GetAllMatchResultsForUserAsync(int userId)
        {
            var result = await _context.MatchResults.ToListAsync();

            return result.Select(x => new MatchResultDto { Id = x.Id, Winner = x.Winner });
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.MatchResults.CountAsync();
        }

        public async Task<MatchResultDto> GetLatestResultAsync()
        {
                var result = await _context.MatchResults.OrderBy(x => x.Id).LastOrDefaultAsync();

                return (result != null) ? new MatchResultDto()
                {
                    Id = result.Id,
                    MatchId = result.MatchId,
                    Winner = result.Winner,
                    UserId = result.UserId,
                } : null;
        }

        public async Task InsertMatchResult(MatchResultDto dto)
        {
            await _context.AddAsync(new Data.Models.MatchResult { 
                MatchId = dto.MatchId,
                UserId = dto.UserId,
                Winner = dto.Winner,
            });

            await _context.SaveChangesAsync();
        }
    }
}
