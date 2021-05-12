using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class Territory: IEntity<long>, IEntityDto
    {

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string TerritoryCode { get; set; }
        public string Territorydescription { get; set; }
        public long RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
