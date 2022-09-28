
using System.ComponentModel.DataAnnotations;

namespace TyperLeague.DataAccess.Entities
{
    public class Team : EntityBase
    {
        public List<Game> Game { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
