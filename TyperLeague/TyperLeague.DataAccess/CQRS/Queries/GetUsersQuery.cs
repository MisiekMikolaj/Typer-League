using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public override Task<List<User>> Execute(TyperLeagueStorageContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}
