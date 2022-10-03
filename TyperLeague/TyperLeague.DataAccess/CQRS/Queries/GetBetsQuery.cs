using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetBetsQuery : QueryBase<List<Bet>>
    {
        public override Task<List<Bet>> Execute(TyperLeagueStorageContext context)
        {
            return context.Bets.ToListAsync();
        }
    }
}
