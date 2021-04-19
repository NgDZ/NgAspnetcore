using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class Customer : IEntity<long>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        public Customer()
        {
            CustomerCustomerDemographics = new HashSet<CustomerCustomerDemographic>();
            SalesOrders = new HashSet<SalesOrder>();
        }


        [Column("EntityId")]
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<CustomerCustomerDemographic> CustomerCustomerDemographics { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
