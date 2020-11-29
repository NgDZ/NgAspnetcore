using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class CustomerCustomerDemographic
    {
        public long EntityId { get; set; }
        public long CustomerId { get; set; }
        public long CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
