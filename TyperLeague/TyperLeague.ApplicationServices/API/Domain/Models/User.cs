using System.ComponentModel.DataAnnotations;

namespace TyperLeague.ApplicationServices.API.Domain.Models
{
    public class User : ModelBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsAdmin { get; set; }

    }
}
