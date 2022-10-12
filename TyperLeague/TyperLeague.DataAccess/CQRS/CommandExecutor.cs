using TyperLeague.DataAccess.CQRS.Commands;

namespace TyperLeague.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly TyperLeagueStorageContext context;

        public CommandExecutor(TyperLeagueStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
