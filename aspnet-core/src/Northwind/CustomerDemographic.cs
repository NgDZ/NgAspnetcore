using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class CustomerDemographic : IEntity<long>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
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
