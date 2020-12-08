using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public partial class Country
    {
        public int CountryId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
