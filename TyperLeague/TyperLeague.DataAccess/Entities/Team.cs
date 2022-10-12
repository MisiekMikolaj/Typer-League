
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TyperLeague.DataAccess.Entities
{
    public class Team : EntityBase
    {
        public List<Game> FirstTeamGames { get; set; }
        public List<Game> SecondTeamGames { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
