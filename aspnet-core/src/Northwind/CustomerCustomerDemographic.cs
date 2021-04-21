using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class CustomerCustomerDemographic : IEntity<long>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        [Column("EntityId")]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
