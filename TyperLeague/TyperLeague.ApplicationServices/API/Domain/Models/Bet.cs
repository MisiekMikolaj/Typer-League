using System.ComponentModel.DataAnnotations;

namespace TyperLeague.ApplicationServices.API.Domain.Models
{
    public class Bet : ModelBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public string Info { get; set; }
        public int GameId { get; set; }

        [MaxLength(10)]
        public string RealResult { get; set; }

        [MaxLength(10)]
        public string UserPrediction { get; set; }

        [Required]
        public DateTime Deadline { get; set; }
        public User? User { get; set; }
    }
}
