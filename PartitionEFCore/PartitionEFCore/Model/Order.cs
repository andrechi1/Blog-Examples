using System;
using System.Collections.Generic;
using System.Text;

namespace PartitionEFCore.Model
{
    public class Order
    {
        public Guid IdOrder { get; set; }

        public string OrderName { get; set; }

        public decimal Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
