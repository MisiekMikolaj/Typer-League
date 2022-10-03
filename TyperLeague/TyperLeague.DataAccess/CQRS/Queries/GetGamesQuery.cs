using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetGamesQuery : QueryBase<List<Game>>
    {
        public override Task<List<Game>> Execute(TyperLeagueStorageContext context)
        {
            return context.Games.ToListAsync();
        }
    }
}
