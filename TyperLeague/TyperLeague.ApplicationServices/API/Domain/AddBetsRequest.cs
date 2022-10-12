using MediatR;
using System.Text.Json.Serialization;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class AddBetsRequest : IRequest<AddBetsResponse>
    {
        [JsonIgnore]
        public int GameId { get; set; }
        [JsonIgnore]
        public string? Name { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        public string Info { get; set; }
        public DateTime Deadline { get; set; }
        [JsonIgnore]
        public User? User { get; set; } 
    }
}
