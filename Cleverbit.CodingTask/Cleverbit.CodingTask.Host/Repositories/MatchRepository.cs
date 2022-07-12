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
    public class MatchRepository : IMatchRepository
    {
        private readonly CodingTaskContext _context;

        public MatchRepository(CodingTaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchDto>> GetAllMatchesAsync()
        {
            var result = await _context.Matches.ToListAsync();
            return result.Select(x => new MatchDto
            {
                Id = x.Id,
                Name = x.Name,
                ExpiryDate = x.ExpiryDate
            });
        }

        public async Task<MatchDto> GetCurrentMatchAsync()
        {

            var currentMatch = await _context.Matches.FirstOrDefaultAsync(x=>x.ExpiryDate > DateTime.Now);
            if(currentMatch != null)
            {
                return new MatchDto
                {
                    Id=currentMatch.Id,
                    Name=currentMatch.Name,
                    ExpiryDate=currentMatch.ExpiryDate
                };
            }
            throw new Exception("No active match exists at the moment, please restart the app");
        }

        public async Task<int> GetExpiredCountAsync()
        {
            return await _context.Matches.CountAsync(x=>x.ExpiryDate > DateTime.Now);
        }

        public async Task<IEnumerable<MatchDto>> GetExpiredMatchesAsync()
        {
            var result = await _context.Matches.Where(x=>x.ExpiryDate<=DateTime.Now).ToListAsync();
            return result.Select(x => new MatchDto
            {
                Id = x.Id,
                Name = x.Name,
                ExpiryDate = x.ExpiryDate
            });
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var result = await _context.Matches.FirstOrDefaultAsync(x => x.Id == matchId);
            return new MatchDto { Id = result.Id, ExpiryDate = result.ExpiryDate, Name = result.Name };
        }

        public async Task<IEnumerable<MatchDto>> GetMatchesToScore(DateTime from, DateTime to)
        {
            var result = await _context.Matches.Where(x=> x.ExpiryDate > from && x.ExpiryDate < to).ToListAsync();

            return result.Select(x => new MatchDto { Id = x.Id, ExpiryDate = x.ExpiryDate, Name = x.Name });
        }
    }
}
