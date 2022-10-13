using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetBetQuery : QueryBase<Bet>
    {
        public int Id { get; set; }
        public override async Task<Bet> Execute(TyperLeagueStorageContext context)
        {
            var bet = await context.Bets.Select(x => new Bet
            {
                GameId = x.GameId,
                Game = x.Game,
                UserId = x.UserId,
                User = x.User,
                Name = x.Name,
                Info = x.Info,
                RealResult = x.RealResult,
                UserPrediction = x.UserPrediction,
                Deadline = x.Deadline,
                Id = x.Id
            }).FirstOrDefaultAsync(x => x.Id == this.Id );

            return bet;
        }
    }
}
