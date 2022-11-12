using MediatR;
using System.Text.Json.Serialization;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.ApplicationServices.API.Domain
{
    public class BaseRequest
    {
        [JsonIgnore]
        public string? userNameClaim { get; set; }
        [JsonIgnore]
        public int userIdClaim { get; set; }
    }
}
