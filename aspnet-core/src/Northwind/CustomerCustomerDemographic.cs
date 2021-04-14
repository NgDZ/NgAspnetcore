using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class CustomerCustomerDemographic
    {
        [Column("EntityId")]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
