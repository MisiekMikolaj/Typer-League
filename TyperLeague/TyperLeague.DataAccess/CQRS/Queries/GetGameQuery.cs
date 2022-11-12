using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetGameQuery : QueryBase<Game>
    {
        public int Id { get; set; }
        public override async Task<Game> Execute(TyperLeagueStorageContext context)
        {
            var game = await context.Games.Select(x => new Game
            {
                Id = x.Id,
                FirstTeam = x.FirstTeam,
                SecondTeam = x.SecondTeam,
                Result = x.Result,
                FirstTeamId = x.FirstTeamId,
                SecondTeamId = x.SecondTeamId
            }).FirstOrDefaultAsync(x => x.Id == this.Id);

            return game;
        }
    }
}
