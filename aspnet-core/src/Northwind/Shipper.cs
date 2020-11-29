using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class Shipper
    {
        public Shipper()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        public long EntityId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
