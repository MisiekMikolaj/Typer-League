using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands
{
    public class AddBetsCommand : CommandBase<List<Bet>, List<Bet>>
    {
        public override async Task<List<Bet>> Execute(TyperLeagueStorageContext context)
        {
            foreach(var i in this.Parameter)
            {
                await context.AddAsync(i);
                await context.SaveChangesAsync();
            }
            
            return this.Parameter;
        }
    }
}
