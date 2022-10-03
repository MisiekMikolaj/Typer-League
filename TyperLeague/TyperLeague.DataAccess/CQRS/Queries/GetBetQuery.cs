using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetBetQuery : QueryBase<Bet>
    {
        public int Id { get; set; }
        public override async Task<Bet> Execute(TyperLeagueStorageContext context)
        {
            var bet = await context.Bets.FirstOrDefaultAsync(x => x.Id == this.Id );
            return bet;
        }
    }
}
