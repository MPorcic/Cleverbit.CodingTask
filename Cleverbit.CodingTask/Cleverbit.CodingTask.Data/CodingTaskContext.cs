using Cleverbit.CodingTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Data
{
    public class CodingTaskContext : DbContext
    {
        public CodingTaskContext(DbContextOptions<CodingTaskContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEntry> MatchEntries{ get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Match>().ToTable(nameof(Match)).HasMany<MatchEntry>().WithOne(x=>x.Match);
            modelBuilder.Entity<MatchEntry>().ToTable(nameof(MatchEntry));
            modelBuilder.Entity<MatchResult>().ToTable(nameof(MatchResult));
        }
    }
}
