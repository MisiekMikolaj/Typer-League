namespace TyperLeague.DataAccess.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public string? Result { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public DateTime Date { get; set; }

        public Match()
        {
        }
        public Match(string team1, string team2, DateTime date)
        {
            Team1 = team1;
            Team2 = team2;
            Date = date;
        }
    }
}
