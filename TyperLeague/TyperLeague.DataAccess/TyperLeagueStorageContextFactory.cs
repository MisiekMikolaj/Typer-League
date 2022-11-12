using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TyperLeague.DataAccess
{
    public class TyperLeagueStorageContextFactory : IDesignTimeDbContextFactory<TyperLeagueStorageContext>
    {
        public TyperLeagueStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TyperLeagueStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TyperLeagueStorage;Integrated Security=True");
            return new TyperLeagueStorageContext(optionsBuilder.Options);
        }
    }
}
