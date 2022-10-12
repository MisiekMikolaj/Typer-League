using System.Text.Json.Serialization;

namespace TyperLeague.ApplicationServices.API.Domain.Models
{
    public class Game : ModelBase
    {
        public string Result { get; set; }
        public int? FirstTeamId { get; set; }
        public int? SecondTeamId { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
    }
}
