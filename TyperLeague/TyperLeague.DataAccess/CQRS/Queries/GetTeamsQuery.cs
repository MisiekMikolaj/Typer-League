using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetTeamsQuery : QueryBase<List<Team>>
    {
        public override Task<List<Team>> Execute(TyperLeagueStorageContext context)
        {
            return context.Teams.ToListAsync();
        }
    }
}
