using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class SalesOrder
    {
        public SalesOrder()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Column("EntityId")]         public long Id { get; set; }
        public long CustomerId { get; set; }
        public long? EmployeeId { get; set; }
        public byte[] OrderDate { get; set; }
        public byte[] RequiredDate { get; set; }
        public byte[] ShippedDate { get; set; }
        public long ShipperId { get; set; }
        public byte[] Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
