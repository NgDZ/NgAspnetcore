using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            CustomerCustomerDemographics = new HashSet<CustomerCustomerDemographic>();
        }

        public long EntityId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemographic> CustomerCustomerDemographics { get; set; }
    }
}
