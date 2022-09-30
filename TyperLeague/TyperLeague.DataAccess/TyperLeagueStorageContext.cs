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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.FirstTeam)
                .WithMany(x => x.FirstTeamGames)
                .HasForeignKey(x => x.FirstTeamId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.SecondTeam)
                .WithMany(x => x.SecondTeamGames)
                .HasForeignKey(x => x.SecondTeamId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
