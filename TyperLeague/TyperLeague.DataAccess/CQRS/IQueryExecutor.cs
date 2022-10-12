using TyperLeague.DataAccess.CQRS.Queries;

namespace TyperLeague.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
