using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetBetsQuery : QueryBase<List<Bet>>
    {
        public override Task<List<Bet>> Execute(TyperLeagueStorageContext context)
        {
            return context.Bets.Select(x => new Bet
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
            }).ToListAsync();
        }
    }
}
