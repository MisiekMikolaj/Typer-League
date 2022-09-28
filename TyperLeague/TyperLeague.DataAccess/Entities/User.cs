
using System.ComponentModel.DataAnnotations;

namespace TyperLeague.DataAccess.Entities
{
    public class User : EntityBase
    {
        public List<Bet> Bet { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public int Points { get; set; }

        public bool IsAdmin { get; set; }
    }
}
