using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab4TSP.Model
{
    public partial class Customer
    {
        public Customer() { }

        public int CustomerId { get; set; }
        [MaxLength(20)] 

        public string Name { get; set; }
        [MaxLength(50)]

        public string City { get; set; }
        [MaxLength(50)]

        public ICollection<Order> Orders { get; set; }
    }
}
