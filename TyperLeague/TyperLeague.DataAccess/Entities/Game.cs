
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyperLeague.DataAccess.Entities
{
    public class Game : EntityBase
    {
        public int? FirstTeamId { get; set; }
        public int? SecondTeamId { get; set; }
        public Team? FirstTeam { get; set; }
        public Team? SecondTeam { get; set; }
        public List<Bet> Bet { get; set; }
        public string? Result { get; set; }
    }
}
