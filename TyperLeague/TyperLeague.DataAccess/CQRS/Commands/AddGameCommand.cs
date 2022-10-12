using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class AddGameCommand : CommandBase<Game, Game>
    {
        public override async Task<Game> Execute(TyperLeagueStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
