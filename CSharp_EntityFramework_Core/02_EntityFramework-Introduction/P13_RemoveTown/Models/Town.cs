﻿using System.Collections.Generic;

namespace P13_RemoveTown.Models
{
    public partial class Town
    {
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
