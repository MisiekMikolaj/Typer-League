using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class AddTeamCommand : CommandBase<Team, Team>
    {
        public override async Task<Team> Execute(TyperLeagueStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
