using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public partial class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        public int TownId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
