using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class OrderDetail
    {
        public long EntityId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }
        public byte[] Discount { get; set; }

        public virtual SalesOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
