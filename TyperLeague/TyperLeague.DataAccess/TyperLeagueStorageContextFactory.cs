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

//Data Source=.\\SQLEXPRESS;Initial Catalog=TyperLeagueStorage;Integrated Security=True
//"Server=tcp:typerleague.database.windows.net,1433;Initial Catalog=TyperLeagueStorage;Persist Security Info=False;User ID=miki;Password=misiek12@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
