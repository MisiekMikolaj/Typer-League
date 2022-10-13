using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class EditUserPredictionBetResultCommand : CommandBase<Bet, Bet>
    {
        public int Id { get; set; }
        public string UserPrediction { get; set; }
        public override async Task<Bet> Execute(TyperLeagueStorageContext context)
        {
            var bet = context.Bets.Where(x => x.Id == this.Id).FirstOrDefault();
            bet.UserPrediction = this.UserPrediction;
            await context.SaveChangesAsync();

            bet = await context.Bets.Where(y => y.Id == this.Id).Select(x => new Bet
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
            }).FirstOrDefaultAsync();

            return bet;
        }
    }
}