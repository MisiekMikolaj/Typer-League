using System.Text.Json.Serialization;

namespace TyperLeague.ApplicationServices.API.Domain.Models
{
    public class ModelBase
    {
        [JsonPropertyOrder(-1)]
        public int Id { get; set; }
    }
}
