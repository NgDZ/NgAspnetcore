using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

#nullable disable

namespace Northwind
{
    public partial class EmployeeTerritory: IEntity<long>, IEntityDto
    {
        public object[] GetKeys()
        {
            return new object[] { Id };
        }
        [Column("EntityId")]
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string TerritoryCode { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory TerritoryCodeNavigation { get; set; }
    }
}
