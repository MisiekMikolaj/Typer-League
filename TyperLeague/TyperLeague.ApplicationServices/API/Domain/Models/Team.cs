using System.ComponentModel.DataAnnotations;

namespace TyperLeague.ApplicationServices.API.Domain.Models
{
    public class Team : ModelBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
