using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetGamesQuery : QueryBase<List<Game>>
    {
        public string teamName { get; set; }
        public override Task<List<Game>> Execute(TyperLeagueStorageContext context)
        {

            IQueryable<Game> games = context.Games;

            if (teamName != null)
            {
                games = games.Where(x => x.FirstTeam.Name == this.teamName || x.SecondTeam.Name == this.teamName);
            }

            return games.Select(y => new Game
            {
                FirstTeam = y.FirstTeam,
                SecondTeam = y.SecondTeam,
                Result = y.Result,
                FirstTeamId = y.FirstTeamId,
                SecondTeamId = y.SecondTeamId,
                Id = y.Id
            }).ToListAsync();
        }
    }
}
