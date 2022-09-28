
namespace TyperLeague.DataAccess.Entities
{
    public class Game : EntityBase
    {
        public List<Team> Team { get; set; }
        /*public Team team1 { get; set; }
        public Team team2 { get; set; }*/
        public List<Bet> Bet { get; set; }
        public string? Result { get; set; }

    }
}
