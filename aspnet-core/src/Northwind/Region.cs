using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class Region: IEntity<long>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string Regiondescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
