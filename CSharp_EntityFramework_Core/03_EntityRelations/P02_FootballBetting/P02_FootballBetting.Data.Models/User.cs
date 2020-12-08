using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public partial class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
       
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(256)]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
