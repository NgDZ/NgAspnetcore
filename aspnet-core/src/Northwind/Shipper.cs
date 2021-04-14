using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class Shipper
    {
        public Shipper()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
