using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public partial class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public byte SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
