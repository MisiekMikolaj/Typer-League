using TyperLeague.DataAccess.CQRS.Queries;

namespace TyperLeague.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly TyperLeagueStorageContext context;
        public QueryExecutor(TyperLeagueStorageContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> quyery)
        {
            return quyery.Execute(this.context);
        }
    }
}
