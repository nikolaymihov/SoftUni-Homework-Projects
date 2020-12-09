using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_SalesDatabase.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
