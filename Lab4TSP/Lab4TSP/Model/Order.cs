using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4TSP.Model
{
    public partial class Order
    {
        public Order() {}

        public int OrderId { get; set; }

        public decimal TotalValue { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
    }
}
