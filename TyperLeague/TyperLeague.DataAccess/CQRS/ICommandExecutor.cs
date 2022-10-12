using TyperLeague.DataAccess.CQRS.Commands;

namespace TyperLeague.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
