﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class Product: IEntity<long>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string ProductName { get; set; }
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public byte[] UnitPrice { get; set; }
        public long? UnitsInStock { get; set; }
        public long? UnitsOnOrder { get; set; }
        public long? ReorderLevel { get; set; }
        public string Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
