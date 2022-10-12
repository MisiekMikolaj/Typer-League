using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(TyperLeagueStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
