using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string Name { get; set; }
        public override async Task<User> Execute(TyperLeagueStorageContext context)
        {
            return context.Users.Where(x => x.Name == this.Name).FirstOrDefault();
        }
    }
}
