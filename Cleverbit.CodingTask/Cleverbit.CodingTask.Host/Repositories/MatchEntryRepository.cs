using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Host.Dto;
using Cleverbit.CodingTask.Host.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Repositories
{
    public class MatchEntryRepository : IMatchEntryRepository
    {
        private readonly CodingTaskContext _context;

        public MatchEntryRepository(CodingTaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchEntryDto>> GetEntriesForUserAsync(int userId)
        {
            var result = await _context.MatchEntries.Where(x=>x.Id == userId).ToListAsync();

            return result.Select(x => new MatchEntryDto
            {
                Id = x.Id,
                UserName = x.UserName,
                Score = x.Score
            }).ToList();

        }

        public async Task<MatchEntryDto> CreateMatchEntryForUser(int matchId, int userId, int score)
        {
            var result = await _context.MatchEntries.AddAsync(new Data.Models.MatchEntry()
            {
                MatchId = matchId,
                UserId = userId,
                Score = score
            });

            await _context.SaveChangesAsync();

            return new MatchEntryDto { Id = result.Entity.Id, Score = result.Entity.Score, UserId = result.Entity.UserId };
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.MatchEntries.CountAsync();
        }

        public async Task<MatchEntryDto> GetWinnerEntryForMatch(int matchId)
        {
            var winner = await _context.MatchEntries.Where(x => x.MatchId == matchId).OrderByDescending(x => x.Score).FirstOrDefaultAsync();

            return (winner !=null) ? new MatchEntryDto { Id = winner.Id, MatchId = matchId, Score = winner.Score, UserId = winner.UserId, UserName = winner.UserName } : null;

        }
    }
}
