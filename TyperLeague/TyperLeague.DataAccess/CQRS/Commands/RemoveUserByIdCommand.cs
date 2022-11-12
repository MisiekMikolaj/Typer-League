using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class RemoveUserByIdCommand : CommandBase<User, User>
    {
        public int Id { get; set; }
        public async override Task<User> Execute(TyperLeagueStorageContext context)
        {
            var user = await context.Users.Where(x => x.Id == this.Id).FirstOrDefaultAsync();
            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return user;
        }
    }
}
