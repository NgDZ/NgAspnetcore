using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class CustomerCustomerDemo : IEntity<string>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        public string Id { get; set; }
        public string CustomerTypeId { get; set; }
    }
}
