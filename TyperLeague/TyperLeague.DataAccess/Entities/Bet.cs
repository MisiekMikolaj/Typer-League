
using System.ComponentModel.DataAnnotations;

namespace TyperLeague.DataAccess.Entities
{
    public class Bet : EntityBase
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public string Info { get; set; }

        [MaxLength(10)]
        public string RealResult { get; set; }

        [MaxLength(10)]
        public string UserPrediction { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

    }
}
