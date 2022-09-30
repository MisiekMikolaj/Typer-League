namespace TyperLeague.ApplicationServices.API.Domain.Models
{
    public class Game : ModelBase
    {
        public string Result { get; set; }
        public int? FirstTeamId { get; set; }
        public int? SecondTeamId { get; set; }
    }
}
