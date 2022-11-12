using MediatR;
using System.Text.Json.Serialization;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class AddGameRequest : BaseRequest, IRequest<AddGameResponse>
    {
        [JsonIgnore]
        public int? FirstTeamId { get; set; }
        [JsonIgnore]
        public int? SecondTeamId { get; set; }
        [JsonIgnore]
        public Team? FirstTeam { get; set; }
        [JsonIgnore]
        public Team? SecondTeam { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        [JsonIgnore]
        public string? Result { get; set; }
    }
}
