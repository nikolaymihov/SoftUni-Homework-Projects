using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Data.Models.Enumerations;

namespace P02_FootballBetting.Data.Models
{
    public partial class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
