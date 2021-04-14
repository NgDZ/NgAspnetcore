using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class OrderDetail
    {
        [Column("EntityId")]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }
        public byte[] Discount { get; set; }

        public virtual SalesOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
