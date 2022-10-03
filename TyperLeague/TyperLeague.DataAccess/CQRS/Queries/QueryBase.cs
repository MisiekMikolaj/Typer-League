namespace TyperLeague.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(TyperLeagueStorageContext context);
    }
}
