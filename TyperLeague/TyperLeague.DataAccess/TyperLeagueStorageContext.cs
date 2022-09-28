using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess
{
    public class TyperLeagueStorageContext : DbContext
    {
        public TyperLeagueStorageContext(DbContextOptions<TyperLeagueStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Game>? Games { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<Bet>? Bets { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
