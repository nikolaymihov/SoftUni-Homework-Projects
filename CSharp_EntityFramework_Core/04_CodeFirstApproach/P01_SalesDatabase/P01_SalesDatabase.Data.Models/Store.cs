﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_SalesDatabase.Data.Models
{
    public partial class Store
    {
        public Store()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int StoreId { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
