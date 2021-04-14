using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            CustomerCustomerDemographics = new HashSet<CustomerCustomerDemographic>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemographic> CustomerCustomerDemographics { get; set; }
    }
}
