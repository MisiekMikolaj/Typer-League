using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace TyperLeague.DataAccess
{
    public class TyperLeagueStorageContext : DbContext
    {
        public TyperLeagueStorageContext(DbContextOptions<TyperLeagueStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Match> Matches { get; set; }
    }
}
