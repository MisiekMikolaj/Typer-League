using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class EditGamePointsCommand : CommandBase<Game, Game>
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public async override Task<Game> Execute(TyperLeagueStorageContext context)
        {
            var game = context.Games.Where(x => x.Id == this.Id).FirstOrDefault();
            game.Result = this.Result;

            var bets = context.Bets.Where(x => x.Game.Id == game.Id).Select(x => new Bet 
            {
            UserId = x.UserId,
            RealResult = this.Result,
            User = x.User,
            UserPrediction = x.UserPrediction
            }).ToList();

            foreach (var bet in bets)
            {
                if(bet.RealResult == bet.UserPrediction)
                {
                    bet.User.Points += 1;
                }
            }
            /*foreach(var bet in bets)
            {
                if(bet.GameId == game.Id)
                {
                    bet.RealResult = this.Result;
                }
                
                
            }*/
            
            await context.SaveChangesAsync();

            game = await context.Games.Where(y => y.Id == this.Id).Select(x => new Game
            {
                Result = x.Result,
                FirstTeam = x.FirstTeam,
                SecondTeam = x.SecondTeam,
                Id = x.Id,
                FirstTeamId = x.FirstTeamId,
                SecondTeamId = x.SecondTeamId
            }).FirstOrDefaultAsync();

            return game;
        }
    }
}
