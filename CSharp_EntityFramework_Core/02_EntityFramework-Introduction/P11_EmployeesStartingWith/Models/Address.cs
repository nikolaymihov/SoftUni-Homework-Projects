﻿using System.Collections.Generic;

namespace P11_EmployeesStartingWith.Models
{
    public partial class Address
    {
        public Address()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int AddressId { get; set; }

        public string AddressText { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
