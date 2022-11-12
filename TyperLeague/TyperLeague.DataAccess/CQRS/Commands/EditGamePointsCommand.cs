using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.CQRS.Commands.CommandsExtensions;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class EditGamePointsCommand : CommandBase<Game, Game>
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public async override Task<Game> Execute(TyperLeagueStorageContext context)
        {
            var game = await context.Games.Where(x => x.Id == this.Id).FirstOrDefaultAsync();
            game.Result = this.Result;

            EditGamePointsCommandExtension.UpdateBetsRealResultByGameResult(context, this.Id, this.Result);
            EditGamePointsCommandExtension.UpdateUserPointsBetsPoints(context, this.Id);

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
