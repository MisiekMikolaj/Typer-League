using TyperLeague.DataAccess.CQRS.Queries;

namespace TyperLeague.DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> qyery);
    }
}
